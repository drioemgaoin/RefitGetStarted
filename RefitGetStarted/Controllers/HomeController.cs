using System.Net;
using System.Web.Http;
using RefitGetStarted.Models;
using RefitGetStarted.Services;
using Swashbuckle.Swagger.Annotations;

namespace RefitGetStarted.Controllers
{
    [RoutePrefix("post")]
    [SwaggerResponseRemoveDefaults]
    public class HomeController : ApiController
    {
        private readonly IJsonPlaceHolderApiService jsonPlaceHolderApiService;

        public HomeController(
            IJsonPlaceHolderApiService jsonPlaceHolderApiService)
        {
            this.jsonPlaceHolderApiService = jsonPlaceHolderApiService;
        }

        [HttpGet]
        [Route("get/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, "Post exists", typeof(PostResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Post does not exists", typeof(ErrorResponse))]
        public IHttpActionResult Get(int id)
        {
            return Content(HttpStatusCode.OK, jsonPlaceHolderApiService.GetPost(id));
        }

        [HttpPost]
        [Route("create")]
        [SwaggerResponse(HttpStatusCode.OK, "Post created", typeof(PostResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Post ha not been created", typeof(ErrorResponse))]
        public IHttpActionResult Create([FromBody] Post post)
        {
            return Content(HttpStatusCode.OK, jsonPlaceHolderApiService.CreatePost(post));
        }

        [HttpPut]
        [Route("update/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, "Post updated", typeof(PostResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Post ha not been updated", typeof(ErrorResponse))]
        public IHttpActionResult Update(int id, [FromBody] Post post)
        {
            return Content(HttpStatusCode.OK, jsonPlaceHolderApiService.UpdatePost(id, post));
        }
    }
}
