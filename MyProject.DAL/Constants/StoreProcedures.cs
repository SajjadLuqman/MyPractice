using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL.Constants
{
    public enum StoreProcedures
    {
        spGetStudents,
        spGetStudentById,
        spDeleteStudent,
        spUpdateStudent,
        spInsertStudent,
        spGetLastId,
        spDeleteTracking,
        spDeleteUser,
        spInsertTracking,
        spInsertUser,
        spOrderDelete,
        spOrderInsert,
        spOrderShow,
        spOrderTrackingShow,
        spOrderUpdate,
        spShowUser,
        spUpdateTracking,
        spUpdateUser,
        spOrderTrackingByOrderId,
        spOrderTrackingByTrackId,
        spOrderById
    }
}
