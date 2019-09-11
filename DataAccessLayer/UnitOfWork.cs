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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;
        private List<Action> _actions;

        public UnitOfWork()
        {
            dbContext = new NWContext();

        }


        public void AddAction(Action action)
        {
            if (this._actions==null)
            {
                this._actions =new  List<Action>();
            }
            this._actions.Add(action)
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                this._actions?.ForEach(a => a.Invoke());
                this.dbContext.SaveChanges();
                scope.Complete();
                this._actions = null;
            }
        }
    }
}
