using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityManager
{
    public class OrderManager
    {
        private UnitOfWork unitOfWork;

        public OrderManager(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork as UnitOfWork;
        }


    }
}
