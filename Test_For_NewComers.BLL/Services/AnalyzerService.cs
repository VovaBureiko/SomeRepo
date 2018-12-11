using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_For_NewComers.BLL.DTO;
using Test_For_NewComers.BLL.Interfaces;
using Test_For_NewComers.DAL;
using Test_For_NewComers.Model;

namespace Test_For_NewComers.BLL.Services
{
    public class AnalyzerService : ITestAnalyzer
    {
        private readonly DisciplesContext _discipleContext;
        private readonly ILogger<AnalyzerService> _logger;

        public AnalyzerService(
            DisciplesContext context, 
            ILogger<AnalyzerService> logger)
        {
            _discipleContext = context;
            _logger = logger;
        }

        public async Task<List<DisciplesBlocksDTO>> AnalyzeUserChoose(
            Dictionary<int, float> userChoose, 
            string userId)
        {
            var userValue = await _discipleContext.UserResults.FirstAsync(id => id.UserId == userId);

            if (!userValue.IsSpecializationProcessed)
            {
                return await AnalyzeSelectedSpecialization(userChoose, userValue);
            }

            var academicDisciples = JsonConvert.DeserializeObject<List<AcademicDiscipleDTO>>(userValue.AcademicDisciple);
            var disciples = JsonConvert.DeserializeObject<List<DiscipleDTO>>(userValue.Disciple);
            var blocks = JsonConvert.DeserializeObject<List<DisciplesBlocksDTO>>(userValue.DiscipleBlock);

            var ids = GetDiscplesIds(academicDisciples, userChoose);
            SetDiscipleValue(ids, disciples);
            SetAcademicDiscipline(academicDisciples, disciples);
            RecalculateAcademicDisciples(academicDisciples);
            RecalculateBlocks(academicDisciples, blocks);
            //SetUpCheckedValueForAcademicDisciples(blocks, userChoose.Keys.ToArray());
            //setUpValuesForDisciple(disciples, ids);
            //RecalculateAcademicDisciples(disciples, academicDisciples);
            //RecalculateBlocks(academicDisciples, blocks);

            UpdateBlocks(academicDisciples, disciples, blocks, userValue);

            _discipleContext.SaveChanges();

            return blocks.OrderBy(block => block.Score).Where(value => !value.IsShown).ToList();
        }

        private Task<List<DisciplesBlocksDTO>> AnalyzeSelectedSpecialization(
           Dictionary<int, float> userChoose,
           UserResults userValue)
        {
            var departmaneSpecial = JsonConvert.DeserializeObject<List<DepartSpecialDTO>>(userValue.SpecialityByDepartment);
            var dictionary = GetDisciplesDictionary(departmaneSpecial, userChoose);

            var blocks = JsonConvert.DeserializeObject<List<DisciplesBlocksDTO>>(userValue.DiscipleBlock);

            ProcessSpecial(blocks, dictionary);

            userValue.DiscipleBlock = JsonConvert.SerializeObject(blocks);
            userValue.IsSpecializationProcessed = true;

            _logger.LogCritical(userValue.UserId + userValue.DiscipleBlock);

            _discipleContext.UserResults.Update(userValue);

            _discipleContext.SaveChanges();

            var result = blocks.OrderByDescending(block => block.Score).Where(value => !value.IsShown).ToList();
            return Task.FromResult(result);
        }

        private Dictionary<int, float> GetDiscplesIds(
            List<AcademicDiscipleDTO> academicDisciples,
            Dictionary<int, float> userChoose)
        {
            var idUserChoose = new Dictionary<int, float>();
            foreach (var item in userChoose.Keys)
            {
                var allAcademicDisciples = academicDisciples.Where(academic => academic.BlockId == item).ToList();
                foreach (var academic in allAcademicDisciples)
                {
                    if(idUserChoose.ContainsKey(academic.DiscplId))
                    {
                        if(idUserChoose[academic.DiscplId] < userChoose[item])
                        {
                            idUserChoose[academic.DiscplId] = userChoose[item];
                        }
                    }
                    else
                    {
                        idUserChoose.Add(academic.DiscplId, userChoose[item]);
                    }
                }
            }

            return idUserChoose;
        }
        
        private void setUpValuesForDisciple (
            List<DiscipleDTO> discipleDTOs, 
            Dictionary<int,float>userChoose)
        {
            foreach (var item in userChoose.Keys)
            {
                foreach(var disciples in discipleDTOs)
                {
                    if (disciples.Id == item)
                    {
                        if (disciples.Weight < userChoose[item])
                        {
                            disciples.Weight = userChoose[item];
                        }
                        disciples.IsShown = true;
                    }
                }
            }
        }

        private void RecalculateAcademicDisciples(List<DiscipleDTO>disciples, List<AcademicDiscipleDTO> academic)
        {
            foreach (var item in academic)
            {
                var disciple = disciples.First(id => id.Id == item.DiscplId);
                item.NewScore = item.Score * disciple.Weight;
                item.IsShown = disciple.IsShown;
            }
        }

        private void RecalculateBlocks(
            List<AcademicDiscipleDTO> academicDiscipleDTOs, 
            List<DisciplesBlocksDTO> blocksDTOs)
        {
            var groupedBlocks = academicDiscipleDTOs.GroupBy(id => id.BlockId)
                .Select(block => new
                {
                    Score = block.Sum(score => score.NewScore),
                    BlockId = block.Key,
                    IsShown = block.All(status => status.IsShown)
                }).OrderBy(id => id.BlockId);

            foreach (var item in groupedBlocks)
            {
                var block = blocksDTOs.First(id => id.Id == item.BlockId);
                block.Score = item.Score * block.SpecValue;
                block.IsShown = item.IsShown;
            }
        }

        private void UpdateBlocks(
            List<AcademicDiscipleDTO> academicDisciples,
            List<DiscipleDTO> disciples,
            List<DisciplesBlocksDTO> blocksDTOs,
            UserResults userResults)
        {
            var blocksString = JsonConvert.SerializeObject(blocksDTOs);
            var disciplesString = JsonConvert.SerializeObject(disciples);
            var academicString = JsonConvert.SerializeObject(academicDisciples);

            _logger.LogCritical("The UserId: {userId} the results:{results} ", userResults.UserId, blocksString);
            userResults.Disciple = disciplesString;
            userResults.DiscipleBlock = blocksString;
            userResults.AcademicDisciple = academicString;

             _discipleContext.UserResults.Update(userResults);
        }

        private Dictionary<int, float> GetDisciplesDictionary(
            List<DepartSpecialDTO> departSpecialDTOs,
            Dictionary<int, float> userInputs)
        {
            var departSpecial = new Dictionary<int, float>();

            foreach (var item in userInputs.Keys)
            {
                var departamnets = departSpecialDTOs.Where(id => id.SpecialId == item).ToList();
                if (departamnets.Count > 1)
                {
                    foreach (var id in departamnets)
                    {
                        departSpecial.Add(id.Id, userInputs[item]);
                    }
                }

                else
                {
                    departSpecial.Add(departamnets.First().Id, userInputs[item]);
                }
            }

            return departSpecial;
        }

        private void ProcessSpecial(List<DisciplesBlocksDTO> blocks, Dictionary<int, float> userInmputs)
        {
            foreach(var item in userInmputs.Keys)
            {
                foreach(var disciplBlocks in blocks)
                {
                    if (disciplBlocks.SpecialDepartment == item)
                    {
                        disciplBlocks.SpecValue = userInmputs[item];
                        disciplBlocks.Score *= userInmputs[item];
                    }
                }
            }
        }

        private void SetUpCheckedValueForAcademicDisciples(List<DisciplesBlocksDTO> academicDiscipleDTOs, int[]ids)
        {
            foreach(var id in ids)
            {
                academicDiscipleDTOs.First(element => element.Id == id).IsShown = true;
            }
        }

        private void SetUserChoose(List<DisciplesBlocksDTO> blocksDTOs, Dictionary<int, float> userChoose)
        {
            foreach(var key in userChoose.Keys)
            {
                blocksDTOs.First(id => id.Id == key).UserChoose = userChoose[key];
            }
        }

        private void SetDiscipleValue(Dictionary<int, float> discipleValues, List<DiscipleDTO> discipleDTOs)
        {
            foreach (var key in discipleValues.Keys)
            {
                var disciple = discipleDTOs.First(id => id.Id == key);
                if (disciple.Weight < discipleValues[key])
                {
                    disciple.Weight = discipleValues[key];
                }
                disciple.IsShown = true;
            }
        }

        private void SetAcademicDiscipline(List<AcademicDiscipleDTO> academicDiscipleDTOs, List<DiscipleDTO> discipleDTOs)
        {
            foreach(var disciple in discipleDTOs)
            {
                var academicDisciples = academicDiscipleDTOs.Where(id => id.DiscplId == disciple.Id).ToList();
                foreach (var academic in academicDisciples)
                {
                    academic.IsShown = disciple.IsShown;
                    academic.DiscipleValue = disciple.Weight;
                }
            }
        }

        private void RecalculateAcademicDisciples(List<AcademicDiscipleDTO> academicDiscipleDTOs)
        {
            foreach (var academic in academicDiscipleDTOs)
            {
                academic.NewScore = academic.Score * academic.DiscipleValue;
            }
        }
    }
}