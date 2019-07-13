using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DAL;
using MyProject.DAL.Repositories;
using MyProject.Models;

namespace TestConsoleApp
{
    class Program
    {
        private static SampleDataRepository _repo = new SampleDataRepository();
        
        static void Main(string[] args)
        {
            var students = _repo.GetStudentsByQuery();
            var students2 = _repo.GetStudentsBySP();
            var students3 = _repo.GetStudentsSPById(1);

            _repo.DeleteStudentById(1);
            _repo.UpdateWithDynamicParameters(new Student() { StudentId = 2, Name = "Update Name", Address = "Wasti" });
            _repo.UpdateWithParameters(new Student() { StudentId = 4, Name = "Update Name", Address = "Wasti" });
            var ReturnValue =_repo.InsertWithDynamicParametersAndReturnValueOutPutParameter(new Student() { Name = "Update Name", Address = "Wasti" });
            var LastId = _repo.GetLastGeneratedId(222);
            var LastIds = _repo.GetLastGeneratedId(3);
            var LastId2 = _repo.GetLastGeneratedId(67);
        }
    }
}
