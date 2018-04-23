using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDbDataLayer.Models
{
    public class Blog
    {
        //scalar properties
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        //navigation properties
        public ICollection<Post> Posts { get; set; } //myBlog.Posts



    }
}
