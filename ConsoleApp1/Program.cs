using ApplicationLayer;
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
            IFacade facade = new Facade();
            var employees = facade.GetAllEmployees();
            foreach (var item in employees)
            {
                Console.WriteLine(item.FirstName);
            }

            Console.ReadKey();

        }
    }
}
