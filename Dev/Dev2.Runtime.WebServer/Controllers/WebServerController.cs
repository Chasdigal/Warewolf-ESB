using System.Collections.Specialized;
using System.Net.Http;
using System.Web.Http;
using Dev2.Runtime.WebServer.Handlers;
using Dev2.Runtime.WebServer.Security;

namespace Dev2.Runtime.WebServer.Controllers
{
    [AuthorizeWeb]
    public class WebServerController : AbstractController
    {
        [HttpGet]
        [Route("{website}/{folder}/{file}")]
        public HttpResponseMessage Get(string website, string folder, string file)
        {
            // DO NOT replace {folder} with {type} in route mapping --> {type} is a query string parameter!
            var requestVariables = new NameValueCollection
            {
                { "website", website }, 
                { "path", string.Format("{0}/{1}", folder, file) }
            };

            return ProcessRequest<WebsiteResourceHandler>(requestVariables);
        }

        [HttpGet]
        [Route("{website}/{path}/{folder}/{*file}")]
        public HttpResponseMessage Get(string website, string path, string folder, string file)
        {
            // DO NOT replace {folder} with {type} in route mapping --> {type} is a query string parameter!
            var requestVariables = new NameValueCollection
            {
                { "website", website }, 
                { "path", path }
            };

            return ProcessRequest<WebsiteResourceHandler>(requestVariables);
        }

        [HttpGet]
        [Route("{website}/views/{*file}")]
        public HttpResponseMessage Get(string website, string file)
        {
            var requestVariables = new NameValueCollection
            {
                { "website", website }, 
                { "path", string.Format("views/{0}", file) }
            };

            return ProcessRequest<WebsiteResourceHandler>(requestVariables);
        }

        [HttpPost]
        [Route("{website}/{path}/Service/{name}/{method}")]
        public HttpResponseMessage InvokeService(string website, string path, string name, string method)
        {
            // DO NOT replace {method} with {action} in route mapping --> {action} is a reserved placeholder!
            var requestVariables = new NameValueCollection
            {
                { "website", website }, 
                { "path", path },
                { "name", name },
                { "action", method },
            };

            return ProcessRequest<WebsiteServiceHandler>(requestVariables);
        }

        [HttpGet]
        [HttpPost]
        [Route("services/{name}")]
        public HttpResponseMessage Execute(string name)
        {
            var requestVariables = new NameValueCollection
            {
                { "servicename", name }
            };

            return Request.Method == HttpMethod.Post
                ? ProcessRequest<WebPostRequestHandler>(requestVariables)
                : ProcessRequest<WebGetRequestHandler>(requestVariables);
        }

        [HttpGet]
        [HttpPost]
        [Route("services/{name}/instances/{instanceid}/bookmarks/{bookmark}")]
        public HttpResponseMessage Bookmark(string name, string instanceid, string bookmark)
        {
            var requestVariables = new NameValueCollection
            {
                { "servicename", name }, 
                { "instanceid", instanceid },
                { "bookmark", bookmark }
            };

            return Request.Method == HttpMethod.Post
                ? ProcessRequest<WebPostRequestHandler>(requestVariables)
                : ProcessRequest<WebGetRequestHandler>(requestVariables);
        }
    }
}