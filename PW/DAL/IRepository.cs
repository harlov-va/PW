using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.DAL
{
    public interface IRepository:IDisposable
    {
        #region System
        void Save();
        #endregion
        #region iwn_products
        IQueryable<iwn_products> GetProducts();
        iwn_products GetProduct(int ID);
        int SaveProduct(iwn_products element, bool withSave = true);
        bool DeleteProduct(int ID);
        #endregion
        #region iwn_productType
        IQueryable<iwn_productType> GetProductTypes();
        iwn_productType GetProductType(int ID);
        int SaveProductType(iwn_productType element, bool withSave = true);
        bool DeleteProductType(int ID);
        #endregion
        #region iwn_producers
        IQueryable<iwn_producers> GetProducers();
        iwn_producers GetProducer(int ID);
        int SaveProducer(iwn_producers element, bool withSave = true);
        bool DeleteProducer(int ID);
        #endregion
        #region iwn_orders
        IQueryable<iwn_orders> GetOrders();
        iwn_orders GetOrder(int ID);
        int SaveOrder(iwn_orders element, bool withSave = true);
        bool DeleteOrder(int ID);
        #endregion
        #region iwn_delivery
        IQueryable<iwn_delivery> GetDeliveris();
        iwn_delivery GetDelivery(int ID);
        int SaveDelivery(iwn_delivery element, bool withSave = true);
        bool DeleteDelivery(int ID);
        #endregion  
        #region iwn_buyers
        IQueryable<iwn_buyers> GetBuyers(); 
         iwn_buyers GetBuyer(int ID);
        int SaveBuyer(iwn_buyers element, bool withSave = true);
        bool DeleteBuyer(int ID);
        #endregion  
    }
}
