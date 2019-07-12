using System;
using ZILDING_CORE.Models;

namespace ZILDING_CORE
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ZildingDBContext _context = null;
        private GenericRepository<Owner> _owner;
        private GenericRepository<Account> _account;
        private GenericRepository<User> _user;

        public UnitOfWork(ZildingDBContext context)
        {
            _context = context;
        }
        public GenericRepository<User> User
        {
            get
            {
                if (_user == null)
                {
                    _user = new GenericRepository<User>(_context);
                }
                return _user;
            }
        }
        public GenericRepository<Owner> Owner
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new GenericRepository<Owner>(_context);
                }
                return _owner;
            }
        }
        public GenericRepository<Account> Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new GenericRepository<Account>(_context);
                }
                return _account;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
