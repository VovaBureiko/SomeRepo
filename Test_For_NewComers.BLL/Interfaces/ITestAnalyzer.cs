using System.Collections.Generic;
using System.Threading.Tasks;
using Test_For_NewComers.BLL.DTO;

namespace Test_For_NewComers.BLL.Interfaces
{
    public interface ITestAnalyzer
    {
        Task<List<DisciplesBlocksDTO>> AnalyzeUserChoose(Dictionary<int, float> userChoose, string userId);
    }
}