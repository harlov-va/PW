using Newtonsoft.Json;
using PW.BLL;
using PW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;

namespace PW.Controllers
{
    
    public class ValuesController : ApiController
    {
        protected IManager mng;
        public ValuesController(IManager _mng)
        {
            this.mng = _mng;
        }
        //public ValuesController()
        //{
        //    this.mng = new Manager(new Repository(new PWEntities()));
        //}
        protected override void Dispose(bool disposing)
        {
            if (mng != null) mng.Dispose();
        }
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        public HttpResponseMessage Get()
        {
            string msg = "";
            var res = mng.Products.GetProducts(out msg);
            var json = JsonConvert.SerializeObject(
                res.Select(x => new
                {
                    id_product = x.id,
                    title = x.name,
                    price = x.price
                })
            );
            return Request.CreateResponse(HttpStatusCode.OK, json);
        }
        public HttpResponseMessage Post()
        {
            string msg = "";
            OrderItemModel parameters = new OrderItemModel();
            try
            {
                var httpContext = (HttpContextBase)Request.Properties["MS_HttpContext"];
                parameters = AjaxModel.GetParameters(httpContext);
            }
            catch (Exception e){
                return Request.CreateResponse(HttpStatusCode.BadRequest, msg, Configuration.Formatters.JsonFormatter);
            };            
            var user = mng.Orders.CreateOrder(parameters, out msg);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, msg, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, msg, Configuration.Formatters.JsonFormatter);
            }
            //return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
