using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace solr.Verify.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {   
        private readonly ISolrIndexService<PostModel> solrIndexService;
        private readonly PostDbContext postDbContext;

        public PostController(ISolrIndexService<PostModel> solrIndexService,PostDbContext postDbContext)
        {
            this.solrIndexService = solrIndexService;
            this.postDbContext = postDbContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Post post)
        {
            postDbContext.Add(post);
            int id=postDbContext.SaveChanges();
            var postModel= new PostModel
            {
                Id = id.ToString(),
                IsActive = post.IsActive,
                Description = post.Description,
                Price = post.Price,
                Title = post.Title
            };
            solrIndexService.AddUpdate(postModel); ;
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
