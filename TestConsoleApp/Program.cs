using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DAL;
using MyProject.DAL.Repositories;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new SampleDataRepository().GetStudentsByQuery();
            var students2 = new SampleDataRepository().GetStudentsBySP();
            var students3 = new SampleDataRepository().GetStudentsSPById(1);
        }
    }
}
