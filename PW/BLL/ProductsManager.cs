using PW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PW.BLL
{
    public class ProductsManager : IProductsManager
    {
        #region System
        private IRepository _db;
        private bool _disposed;
        public ProductsManager(IRepository db)
        {
            _db = db;
            _disposed = false;
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
                    if (_db != null)
                        _db.Dispose();
                _db = null;
                _disposed = true;
            }
        }
        private void _debug(Exception ex, Object parameters = null, string additions = "")
        {
            RDL.Debug.LogError(ex, additions, parameters);
        }
        private bool _canAccesseToItem()
        {
            var res = false;
            //if (_db.GetToken()) res = true;
            //var isAdmin = Product.aspnet_Roles.Any(x => x.RoleName == "admin");
            //var isManager = Product.aspnet_Roles.Any(x => x.RoleName == "guest");
            //if (Product != null && isAdmin || isManager)
            //{
            //    res = true;
            //}
            return true;
        }
        private bool _canManageItem()
        {
            var res = false;
            //var isAdmin = Product.aspnet_Roles.Any(x => x.RoleName == "admin");
            //if (Product != null && isAdmin)
            //{
            //    res = true;
            //}
            //return res;
            return true;
        }
        #endregion
        #region Products
        public List<iwn_products> GetProducts(out string msg)
        {
            msg = "";
            List<iwn_products> res;
            try
            {
                if (!_canAccesseToItem())
                {
                    msg = "Нет прав на получение списка элемента!";
                    res = null;
                }
                else
                {
                    res = _db.GetProducts().ToList();
                }
            }
            catch (Exception e)
            {
                _debug(e, new { }, "Ошибка возникла при получении списка элемента");
                res = null;
            }
            return res;
        }
        public iwn_products GetProduct(int id, out string msg)
        {
            msg = "";
            iwn_products res;
            try
            {
                if (!_canAccesseToItem())
                {
                    msg = "Нет прав на получение элемента по id";
                    res = null;
                }
                else
                {
                    res = _db.GetProduct(id);
                }
            }
            catch (Exception e)
            {
                _debug(e, new { }, "Ошибка возникла при получении элемента по id");
                res = null;
            }
            return res;
        }
        public iwn_products CreateProduct(Dictionary<string, string> parameters, out string msg)
        {
            msg = "";
            iwn_products res;
            try
            {
                    res = new iwn_products();
                    res.guid = Guid.NewGuid();
                    foreach (var key in parameters.Keys)
                        switch (key)
                        {
                            case "articul":
                                res.articul = parameters[key];
                                break;
                            case "price":
                                res.price = RDL.Convert.StrToDecimal(parameters[key],0);
                                break;
                            case "name":
                                res.name = parameters[key];
                                break; 
                            case "currency":
                                res.currency = parameters[key];
                                break;
                            case "producerID":
                                res.producerID = RDL.Convert.StrToInt(parameters[key],1);
                                break;
                            case "productTypeID":
                                res.productTypeID = RDL.Convert.StrToInt(parameters[key], 1);
                                break;
                        }
                    _db.SaveProduct(res);
            }
            catch (Exception e)
            {
                _debug(e, new { }, "Ошибка возникла при создании элемента");
                res = null;
            }
            return res;
        }

        public iwn_products CreateProduct(GoodsGood[] gd, out string msg)
        {
            msg = "";
            iwn_products res = new iwn_products();
            try
            {
                foreach (var good in gd)
                {
                    res = new iwn_products();
                    res.guid = Guid.NewGuid();
                    res.name = good.Name;
                    res.price = good.Value;
                    res.articul = good.Articul;
                    res.currency = good.Currency;
                    var producer = _db.GetProducers().FirstOrDefault(x => x.code == good.Producer.Code);
                    if (producer == null)
                    {
                        iwn_producers newProducer = new iwn_producers();
                        newProducer.name = good.Producer.Name;
                        newProducer.code = good.Producer.Code;
                        int i = _db.SaveProducer(newProducer);
                        res.producerID = i;
                    }
                    else
                    {
                        res.producerID = producer.id;
                    }
                    var type = _db.GetProductTypes().FirstOrDefault(x => x.code == good.GoodType.Code);
                    if (type == null)
                    {
                        iwn_productType newType = new iwn_productType();
                        newType.name = good.Producer.Name;
                        newType.code = good.Producer.Code;
                        int i = _db.SaveProductType(newType);
                        res.productTypeID = i;
                    }
                    else
                    {
                        res.productTypeID = type.id;
                    }
                    _db.SaveProduct(res);
                }
            }
            catch (Exception e)
            {
                _debug(e, new { }, "Ошибка возникла при создании элемента");
                res = null;
            }
            return res;
        }

        public iwn_products EditProduct(Dictionary<string, string> parameters, int id, out string msg)
        {
            msg = "";
            iwn_products res;
            try
            {
                if (!_canManageItem())
                {
                    msg = "Нет прав редактировать элемент";
                    res = null;
                }
                else
                {
                    res = _db.GetProduct(id);
                    foreach (var key in parameters.Keys)
                        switch (key)
                        {
                            case "articul":
                                res.articul = parameters[key];
                                break;
                            case "price":
                                res.price = RDL.Convert.StrToDecimal(parameters[key], 0);
                                break;
                            case "name":
                                res.name = parameters[key];
                                break;
                            case "currency":
                                res.currency = parameters[key];
                                break;
                            case "producerID":
                                res.producerID = RDL.Convert.StrToInt(parameters[key], 1);
                                break;
                            case "productTypeID":
                                res.productTypeID = RDL.Convert.StrToInt(parameters[key], 1);
                                break;
                        }
                    _db.SaveProduct(res);
                }
            }
            catch (Exception e)
            {
                _debug(e, new { }, "Ошибка возникла при изменении элемента");
                res = null;
            }
            return res;
        }
        public bool RemoveProduct(int id, out string msg)
        {
            msg = "";
            bool res = false;
            try
            {
                if (!_canManageItem())
                {
                    msg = "Нет прав на удаление элемента";
                    res = false;
                }
                else
                {
                    _db.DeleteProduct(id);
                    res = true;
                }
            }
            catch (Exception e)
            {
                _debug(e, new { }, "Ошибка возникла при удалении элемента");
                res = false;
            }
            return res;
        }
        #endregion
    }
}