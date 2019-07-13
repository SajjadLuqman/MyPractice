using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Core;
using MyProject.Models;
using MyProject.DAL.Repositories;

namespace MyProject.BusinessLogic.StudentModuleBL
{
   public class StudentBL
    {
        private SampleDataRepository _repo;
        public StudentBL()
        {
            _repo = new SampleDataRepository();
        }

        public List<Student> GetStudentsByQuery()
        {
            return _repo.GetStudentsByQuery();
        }

        public List<Student> GetStudentsBySP()
        {
            return _repo.GetStudentsBySP();
        }

        public Student GetStudentsSPById(int Id)
        {
            return _repo.GetStudentsSPById(Id);
        }

        public object DeleteStudentById(int Id)
        {
            return _repo.DeleteStudentById(Id);

        }

        public int UpdateWithDynamicParameters(Student obj)
        {
            return _repo.UpdateWithDynamicParameters(obj);
        }

        public int InsertWithDynamicParametersAndReturnValueOutPutParameter(Student obj)
        {
            return _repo.InsertWithDynamicParametersAndReturnValueOutPutParameter(obj);
        }

        public int UpdateWithParameters(Student obj)
        {
            return _repo.UpdateWithParameters(obj);
        }

        public int GetLastGeneratedId(int StudentId)
        {
            return _repo.GetLastGeneratedId(StudentId);
        }
    }
}
