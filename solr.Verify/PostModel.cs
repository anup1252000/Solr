using System;
using SolrNet.Attributes;

namespace solr.Verify
{
    public class PostModel
    {
        public PostModel() { }

        public PostModel(Post model)
        {
            this.Id = model.Id;

            this.Description = model.Description;
            this.IsActive = model.IsActive;
            this.Price = model.Price;
            this.Title = model.Title;
        }

        [SolrUniqueKey("id")]
        public string Id { get; set; }
        [SolrField("title")]
        public string Title { get; set; }
        [SolrField("description")]
        public string Description { get; set; }
        [SolrField("price")]
        public double Price { get; set; }
        [SolrField("isActive")]
        public bool IsActive { get; set; }
    }
}
