using Dapper;
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

        public object DeleteStudentById(int Id)
        {
            return QueryExecutor.Execute(StoreProcedures.spDeleteStudent.ToString(), new { StudentId = Id }, CommandType.StoredProcedure);
        }

        public int UpdateWithDynamicParameters(Student obj)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@StudentId", obj.StudentId);
            param.Add("@Name", obj.Name);
            param.Add("@Address", obj.Address);
            return QueryExecutor.ExecuteWithParameter(StoreProcedures.spUpdateStudent.ToString(),param);
        }

        public int InsertWithDynamicParametersAndReturnValueOutPutParameter(Student obj)
        {
            string ReturnValue = "ReturnValue";

            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", obj.Name);
            param.Add("@Address", obj.Address);
            param.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return QueryExecutor.ExecuteWithReturnValue<int>(StoreProcedures.spInsertStudent.ToString(), ReturnValue, param);
        }

        public int UpdateWithParameters(Student obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spUpdateStudent.ToString(),new { StudentId = obj.StudentId, Name = obj.Name, Address = obj.Address });
        }

        public int GetLastGeneratedId(int StudentId)
        {
            var Result = QueryExecutor.ExecuteScalar(StoreProcedures.spGetLastId.ToString(),new { StudentId = StudentId });
            if (Result != null)
                return Convert.ToInt32(Result);
            else
                return 0;
        }
    }
}
