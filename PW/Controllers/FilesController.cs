using Newtonsoft.Json;
using PW.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;

namespace PW.Controllers
{
    public class FilesController : ApiController
    {
        protected IManager mng;
        public FilesController(IManager _mng)
        {
            this.mng = _mng;
        }
        // GET: api/users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/users/5
        public string Get(int id)
        {
            return "value";
        }

        public async Task<IHttpActionResult> Post()
        {

            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            bool res = false;
            string msg;
            var file = provider.Contents[0];
            
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var buffer = await file.ReadAsByteArrayAsync();
            XmlSerializer ser = new XmlSerializer(typeof(Goods));
            Goods goods;
            using (XmlReader reader = XmlReader.Create(new MemoryStream(buffer)))
            {
                goods = (Goods)ser.Deserialize(reader);
            }
            var newProduct = mng.Products.CreateProduct(goods.Good, out msg);
            if (newProduct == null) { res = false; }
            else
            {
                res = true;
            }

            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }


            

            //var httpContext = (HttpContextBase)Request.Properties["MS_HttpContext"];
            //var doc = httpContext.Request.Form["file"];
            //string password = httpContext.Request.Form["password"];
            //string email = httpContext.Request.Form["email"];
            //var msg = "";
            //var user = mng.Users.CreateUser(username, email, password, out msg);
            //if (user == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, msg, Configuration.Formatters.JsonFormatter);
            //}
            //else
            //{
            //    AuthenticationModule authentication = new AuthenticationModule();
            //    string token = authentication.GenerateTokenForUser(user.userName, user.id);
            //    var json = JsonConvert.SerializeObject(
            //    new
            //    {
            //        id_token = token

            //    }
            //    );
            //    return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);
            //}
            //return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/users/5
        public void Delete(int id)
        {
        }
    }
}
