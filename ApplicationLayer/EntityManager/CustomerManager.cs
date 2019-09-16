using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityManager
{
    public class CustomerManager
    {


        private UnitOfWork unitOfWork;

        public CustomerManager(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork as UnitOfWork;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = unitOfWork.CustomerRepository.GetAll();
            return customers.ToList();
        }

    }
}
