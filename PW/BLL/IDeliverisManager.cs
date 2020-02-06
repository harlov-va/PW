using PW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.BLL
{
    public interface IDeliverisManager : IDisposable
    {
        #region iwn_delivery
        List<iwn_delivery> GetDeliveris(out string msg);
         #endregion
    }
}
