using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_For_NewComers.BLL.DTO;

namespace Test_For_NewComers.BLL.Interfaces
{
    public interface ITestPreparationService
    {
        Task<TestPreparationDTO>GetAllSpecializations();
    }
}
