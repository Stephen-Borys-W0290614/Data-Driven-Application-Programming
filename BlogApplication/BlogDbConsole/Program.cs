using BlogDbDataLayer;
using BlogDbDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDbConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Blog newBlog = new Blog();
            newBlog.Title = "My Cool new Blog";

            BlogDbContext context = new BlogDbContext();
            context.Blogs.Add(newBlog);

            context.SaveChanges();


        }
    }
}
