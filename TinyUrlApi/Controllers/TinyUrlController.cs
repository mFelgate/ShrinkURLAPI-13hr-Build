using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TinyURL.service;

namespace TinyURL.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TinyUrlController : ApiController
    {
        private TinyUrlService service = new TinyUrlService();


        [HttpPost]
        [Route("short")]
        public UrlModel Get(TinyUrl url)
        {
            try
            {
                return service.getUrl(url.tinyUrl);
            }
            // on error, return failed http response with the exception
            catch(Exception x)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format(x.InnerException.ToString())),
                };
                throw new HttpResponseException(resp);
            }
          
        }
        [Route("long")]
        [HttpPost]
        public UrlModel Add(FullUrl url)
        {
            
            try
            {
                return service.addUrl(url.fullUrl);
            }
            // on error, return failed http response with the exception
            catch (Exception x)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format(x.InnerException.ToString())),
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
