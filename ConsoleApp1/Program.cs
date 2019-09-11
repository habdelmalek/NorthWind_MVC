using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var emps = unitOfWork.EmployeeRepository.GetAll().Select(emp => emp.FirstName + " " + emp.LastName);

                foreach (var item in emps)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();

            }

        }
    }
}
