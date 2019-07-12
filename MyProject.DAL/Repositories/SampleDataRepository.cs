using MyProject.DAL.Constants;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL.Repositories
{
   public  class SampleDataRepository : BaseRepository
    {
        public List<Student> GetStudentsByQuery()
        {
            return QueryExecutor.Query<Student>(SQLs.GetStudents, null, CommandType.Text).ToList();
        }

        public List<Student> GetStudentsBySP()
        {
            return QueryExecutor.Query<Student>(StoreProcedures.spGetStudents.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public Student GetStudentsSPById(int Id)
        {
            return QueryExecutor.Query<Student>(StoreProcedures.spGetStudentById.ToString(), new { StudentId = Id }, CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
