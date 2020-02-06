using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PW.DAL
{
    public class Repository : IDisposable, IRepository
    {
        #region System
        private PWEntities _db;
        public PWEntities db
        {
            get
            {
                if (_db == null)
                    _db = new PWEntities();
                return _db;
            }
            set
            {
                _db = value;
            }
        }
        private bool _disposed = false;
        public Repository(PWEntities db)
        {
            if (db == null) this.db = new PWEntities();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                   if (db != null) Dispose(true);
                }
                db = null;
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        #endregion
        #region iwn_products
        public IQueryable<iwn_products> GetProducts()
        {
            var res = db.iwn_products;
            return res;
        }
        public iwn_products GetProduct(int ID)
        {
            var res = db.iwn_products.FirstOrDefault(x => x.id == ID);
            return res;
        }
        public int SaveProduct(iwn_products element, bool withSave = true)
        {
            if (element.id == 0)
            {
                db.iwn_products.Add(element);
                if (withSave) Save();
            }
            else
            {
                db.Entry(element).State = System.Data.Entity.EntityState.Modified;
                if (withSave) Save();
            }
            return element.id;
        }
        public bool DeleteProduct(int ID)
        {
            bool res = false;
            var item = db.iwn_products.SingleOrDefault(x => x.id == ID);
            if (item != null)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                Save();
                res = true;
            }
            return res;
        }
        #endregion
        #region iwn_productType
        public IQueryable<iwn_productType> GetProductTypes()
        {
            var res = db.iwn_productType;
            return res;
        }
        public iwn_productType GetProductType(int ID)
        {
            var res = db.iwn_productType.FirstOrDefault(x => x.id == ID);
            return res;
        }
        public int SaveProductType(iwn_productType element, bool withSave = true)
        {
            if (element.id == 0)
            {
                db.iwn_productType.Add(element);
                if (withSave) Save();
            }
            else
            {
                db.Entry(element).State = System.Data.Entity.EntityState.Modified;
                if (withSave) Save();
            }
            return element.id;
        }
        public bool DeleteProductType(int ID)
        {
            bool res = false;
            var item = db.iwn_productType.SingleOrDefault(x => x.id == ID);
            if (item != null)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                Save();
                res = true;
            }
            return res;
        }
        #endregion
        #region iwn_producers
        public IQueryable<iwn_producers> GetProducers()
        {
            var res = db.iwn_producers;
            return res;
        }
        public iwn_producers GetProducer(int ID)
        {
            var res = db.iwn_producers.FirstOrDefault(x => x.id == ID);
            return res;
        }
        public int SaveProducer(iwn_producers element, bool withSave = true)
        {
            if (element.id == 0)
            {
                db.iwn_producers.Add(element);
                if (withSave) Save();
            }
            else
            {
                db.Entry(element).State = System.Data.Entity.EntityState.Modified;
                if (withSave) Save();
            }
            return element.id;
        }
        public bool DeleteProducer(int ID)
        {
            bool res = false;
            var item = db.iwn_producers.SingleOrDefault(x => x.id == ID);
            if (item != null)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                Save();
                res = true;
            }
            return res;
        }
        #endregion
        #region iwn_orders
        public IQueryable<iwn_orders> GetOrders()
        {
            var res = db.iwn_orders;
            return res;
        }
        public iwn_orders GetOrder(int ID)
        {
            var res = db.iwn_orders.FirstOrDefault(x => x.id == ID);
            return res;
        }
        public int SaveOrder(iwn_orders element, bool withSave = true)
        {
            if (element.id == 0)
            {
                db.iwn_orders.Add(element);
                if (withSave) Save();
            }
            else
            {
                db.Entry(element).State = System.Data.Entity.EntityState.Modified;
                if (withSave) Save();
            }
            return element.id;
        }
        public bool DeleteOrder(int ID)
        {
            bool res = false;
            var item = db.iwn_orders.SingleOrDefault(x => x.id == ID);
            if (item != null)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                Save();
                res = true;
            }
            return res;
        }
        #endregion        
        #region iwn_delivery        
        public IQueryable<iwn_delivery> GetDeliveris()
        {
            var res = db.iwn_delivery;
            return res;
        }
        public iwn_delivery GetDelivery(int ID)
        {
            var res = db.iwn_delivery.FirstOrDefault(x => x.id == ID);
            return res;
        }
        public int SaveDelivery(iwn_delivery element, bool withSave = true)
        {
            if (element.id == 0)
            {
                db.iwn_delivery.Add(element);
                if (withSave) Save();
            }
            else
            {
                db.Entry(element).State = System.Data.Entity.EntityState.Modified;
                if (withSave) Save();
            }
            return element.id;
        }
        public bool DeleteDelivery(int ID)
        {
            bool res = false;
            var item = db.iwn_delivery.SingleOrDefault(x => x.id == ID);
            if (item != null)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                Save();
                res = true;
            }
            return res;
        }
        #endregion 
        #region iwn_buyers        
        public IQueryable<iwn_buyers> GetBuyers()
        {
            var res = db.iwn_buyers;
            return res;
        }
        public iwn_buyers GetBuyer(int ID)
        {
            var res = db.iwn_buyers.FirstOrDefault(x => x.id == ID);
            return res;
        }
        public int SaveBuyer(iwn_buyers element, bool withSave = true)
        {
            if (element.id == 0)
            {
                db.iwn_buyers.Add(element);
                if (withSave) Save();
            }
            else
            {
                db.Entry(element).State = System.Data.Entity.EntityState.Modified;
                if (withSave) Save();
            }
            return element.id;
        }
        public bool DeleteBuyer(int ID)
        {
            bool res = false;
            var item = db.iwn_buyers.SingleOrDefault(x => x.id == ID);
            if (item != null)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                Save();
                res = true;
            }
            return res;
        }
        #endregion 
    }
}