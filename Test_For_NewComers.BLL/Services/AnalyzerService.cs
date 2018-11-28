﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_For_NewComers.BLL.DTO;
using Test_For_NewComers.DAL;
using Test_For_NewComers.Model;

namespace Test_For_NewComers.BLL.Services
{
    public class AnalyzerService
    {
        private readonly DisciplesContext _discipleContext;

        public AnalyzerService(DisciplesContext context)
        {
            _discipleContext = context;
        }

        public async Task<List<DisciplesBlocksDTO>> AnalyzeSelectedSpecialization(
            string userId,
            Dictionary<int, float> userChoose)
        {
            var userValue = await _discipleContext.UserResults.FirstAsync(id => id.UserId == userId);
            var departmaneSpecial = JsonConvert.DeserializeObject<List<DepartSpecialDTO>>(userValue.SpecialityByDepartment);
            var dictionary = GetDisciplesDictionary(departmaneSpecial, userChoose);

            var blocks = JsonConvert.DeserializeObject<List<DisciplesBlocksDTO>>(userValue.DiscipleBlock);

            ProcessSpecial(blocks, dictionary);

            return blocks.OrderBy(block => block.Score).Where(value => !value.IsShown).ToList();
        }

        public async Task<List<DisciplesBlocksDTO>> AnalyzeUserChoose(
            Dictionary<int, float> userChoose, 
            string userId)
        {
            var userValue = await _discipleContext.UserResults.FirstAsync(id => id.UserId == userId);
            var academicDisciples = JsonConvert.DeserializeObject<List<AcademicDiscipleDTO>>(userValue.DiscipleBlock);
            var disciples = JsonConvert.DeserializeObject<List<DiscipleDTO>>(userValue.Disciple);
            var blocks = JsonConvert.DeserializeObject<List<DisciplesBlocksDTO>>(userValue.DiscipleBlock);

            var ids = GetDiscplesIds(academicDisciples, userChoose);
            setUpValuesForDisciple(disciples, ids);
            RecalculateAcademicDisciples(disciples, academicDisciples);
            RecalculateBlocks(academicDisciples, blocks);

            UpdateBlocks(academicDisciples, disciples, blocks, userValue);

            return blocks.OrderBy(block => block.Score).Where(value => !value.IsShown).ToList();
        }

        private Dictionary<int, float> GetDiscplesIds(
            List<AcademicDiscipleDTO> blocks,
            Dictionary<int, float> userChoose)
        {
            var idUserChoose = new Dictionary<int, float>();
            foreach (var item in userChoose.Keys)
            {
                var discipleId = blocks.First(academic => academic.BlockId == item).DiscplId;
                idUserChoose.Add(discipleId, userChoose[item]);
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
                        if (!disciples.IsShown)
                        {
                            disciples.IsShown = true;
                            disciples.Weight = userChoose[item];
                        }
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
                    Score = block.Sum(score => score.Score),
                    BlockId = block.Key,
                    IsShown = block.All(status => status.IsShown)
                }).OrderBy(id => id.BlockId);

            foreach (var item in groupedBlocks)
            {
                var block = blocksDTOs.First(id => id.Id == item.BlockId);
                block.Score = item.Score * block.SpecValue;
                if (!block.IsShown)
                {
                    block.IsShown = item.IsShown;
                }
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
                var departId = departSpecialDTOs.First(id => id.SpecialId == item).Id;
                departSpecial.Add(departId, userInputs[item]);
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
    }
}
