using System;
using Microsoft.EntityFrameworkCore;

namespace solr.Verify
{
    public class PostDbContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public PostDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }
    }
}
