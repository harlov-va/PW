using PW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.BLL
{
    public interface IProductsManager:IDisposable
    {
        #region iwn_products
        List<iwn_products> GetProducts(out string msg);
        iwn_products GetProduct(int id, out string msg);
        iwn_products CreateProduct(Dictionary<string, string> parameters, out string msg);
        iwn_products CreateProduct(GoodsGood[] goods, out string msg);
        iwn_products EditProduct(Dictionary<string, string> parameters, int id, out string msg);
         bool RemoveProduct(int id, out string msg);
        #endregion

    }
}
