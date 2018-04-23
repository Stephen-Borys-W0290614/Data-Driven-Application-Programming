using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDbDataLayer.Models;

namespace BlogDbDataLayer
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("name=BlogDb")
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BlogDbContext>());

        }

        //define the collections of object
        //in the database....tables
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }


    }
}
