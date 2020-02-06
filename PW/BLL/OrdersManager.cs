using PW.DAL;
using PW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PW.BLL
{
    public class OrdersManager : IOrdersManager
    {
        #region System
        private IRepository _db;
        private bool _disposed;
        public OrdersManager(IRepository db)
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
        #endregion
        #region iwn_orders
        public iwn_orders CreateOrder(OrderItemModel parameters, out string msg)
        {
            msg = "";
            iwn_orders res = new iwn_orders();
            try
            {
                iwn_buyers buyer = new iwn_buyers();
                int deliveryId = 1;
                int buyersId;
                foreach (var key in parameters.person.Keys)
                {
                    switch (key)
                    {
                        case "Full Name":
                            buyer.fullName = parameters.person[key];
                            break;
                        case "Phone":
                            buyer.phone = parameters.person[key];
                            break;
                        case "Email":
                            buyer.email = parameters.person[key];
                            break;
                        case "Delivery":
                            deliveryId = RDL.Convert.StrToInt(parameters.person[key], 1);
                            break;
                    }
                }
                buyersId = _db.SaveBuyer(buyer);
                foreach (var key in parameters.order.Keys)
                {
                    iwn_orders currentOrder = new iwn_orders();
                    int productsId = RDL.Convert.StrToInt(key, 1);
                    currentOrder.amount = RDL.Convert.StrToInt(parameters.order[key], 1);
                    currentOrder.total = currentOrder.amount * _db.GetProduct(productsId).price;
                    currentOrder.buyersID = buyersId;
                    currentOrder.deliveryID = deliveryId;
                    currentOrder.productsID = productsId;
                    res = currentOrder;
                    _db.SaveOrder(res);
                }
            }
            catch (Exception e)
            {
                _debug(e, new { }, "Ошибка возникла при создании нового документа");
                res = null;
            }
            return res;
        }
        #endregion

    }
}