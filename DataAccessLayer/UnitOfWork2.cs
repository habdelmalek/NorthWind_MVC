using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace DataAccessLayer
{
    public partial class UnitOfWork : IUnitOfWork
    {
        //repositories

        private IRepository<Category> _CategoryRepo;
        public IRepository<Category> CategoryRepository
        {
            get { return _CategoryRepo?? (_CategoryRepo = new Repository<Category>(this.dbContext)); }
        }

        
        private IRepository<Customer> _CustomerRepo;
        public IRepository<Customer> CustomerRepository
        {
            get { return _CustomerRepo ?? (_CustomerRepo = new Repository<Customer>(this.dbContext)); }
        }


        private IRepository<Employee> _EmployeeRepo;
        public IRepository<Employee> EmployeeRepository
        {
            get { return _EmployeeRepo ?? (_EmployeeRepo = new Repository<Employee>(this.dbContext)); }
        }


        private IRepository<Order> _OrderRepo;
        public IRepository<Order> OrderRepository
        {
            get { return _OrderRepo ?? (_OrderRepo = new Repository<Order>(this.dbContext)); }
        }


        private IRepository<Order_Detail> _OrderDetailsRepo;
        public IRepository<Order_Detail> OrderDetailsRepository
        {
            get { return _OrderDetailsRepo ?? (_OrderDetailsRepo = new Repository<Order_Detail>(this.dbContext)); }
        }

        private IRepository<Product> _ProductRepo;
        public IRepository<Product> ProductRepository
        {
            get { return _ProductRepo ?? (_ProductRepo = new Repository<Product>(this.dbContext)); }
        }

        private IRepository<Region> _RegionRepo;
        public IRepository<Region> RegionRepository
        {
            get { return _RegionRepo ?? (_RegionRepo = new Repository<Region>(this.dbContext)); }
        }


        private IRepository<Shipper> _ShipperRepo;
        public IRepository<Shipper> ShipperRepository
        {
            get { return _ShipperRepo ?? (_ShipperRepo = new Repository<Shipper>(this.dbContext)); }
        }

        private IRepository<Supplier> _SupplierRepo;
        public IRepository<Supplier> SupplierRepository
        {
            get { return _SupplierRepo ?? (_SupplierRepo = new Repository<Supplier>(this.dbContext)); }
        }

        private IRepository<Territory> _TerritoryRepo;
        public IRepository<Territory> TerritoryRepository
        {
            get { return _TerritoryRepo ?? (_TerritoryRepo = new Repository<Territory>(this.dbContext)); }
        }

    }
}
