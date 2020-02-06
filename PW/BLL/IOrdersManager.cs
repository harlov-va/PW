using PW.DAL;
using PW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.BLL
{
    public interface IOrdersManager : IDisposable
    {
        #region iwn_orders
        iwn_orders CreateOrder(OrderItemModel parameters, out string msg);
        #endregion
       
    }
}
