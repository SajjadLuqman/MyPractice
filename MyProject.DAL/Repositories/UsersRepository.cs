using Dapper;
using MyProject.DAL.Constants;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyProject.DAL.Repositories
{
   public class UsersRepository : BaseRepository
    {
        public List<Users> Get()
        {
            return QueryExecutor.Query<Users>(StoreProcedures.spShowUser.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public Users GetById(string UserId)
        {
            return QueryExecutor.Query<Users>(StoreProcedures.spShowUserById.ToString(), new { UserId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int UserId)
        {
            return QueryExecutor.Execute(StoreProcedures.spDeleteUser.ToString(), new { UserId }, CommandType.StoredProcedure);
        }

        public int Update(Users obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spUpdateUser.ToString(), new { obj.UserId, obj.UserName, obj.Type, obj.Password });
        }

        public int Insert(Users obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spInsertUser.ToString(), new { obj.UserName, obj.Type, obj.Password });
        }

    }
}
