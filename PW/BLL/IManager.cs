using PW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.BLL
{
    public interface IManager:IDisposable
    {
        IProductsManager Products { get; set; }
        IDeliverisManager Deliveris { get; set; }
        IOrdersManager Orders { get; set; }
    }
}
