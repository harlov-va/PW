using PW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PW.BLL
{
    public class Manager : IManager
    {
        #region System
        private IRepository _db;
        private bool _disposed;
        public Manager(IRepository db)
        {
            _db = db;
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_db != null) _db.Dispose();
                }
                _db = null;
                _disposed = true;
            }
        }
        #endregion
        IProductsManager _Products;
        public IProductsManager Products
        {
            get
            {
                if (_Products == null)
                    _Products = new ProductsManager(_db);
                return _Products;
            }
            set
            {
                _Products = value;
            }
        }
        IDeliverisManager _Deliveris;
        public IDeliverisManager Deliveris
        {
            get
            {
                if (_Deliveris == null)
                    _Deliveris = new DeliverisManager(_db);
                return _Deliveris;
            }
            set
            {
                _Deliveris = value;
            }
        }

        IOrdersManager _Orders;
        public IOrdersManager Orders
        {
            get
            {
                if (_Orders == null)
                    _Orders = new OrdersManager(_db);
                return _Orders;
            }
            set
            {
                _Orders = value;
            }
        }
    }
}