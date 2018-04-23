using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDBDataLayer.Modles
{
    public class Post
    {
        //Scalar Properties
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [ForeignKey("Blog")]
        public int BlogId { get; set; }


        //Navigation Properties
        public Blog Blog { get; set; }

        public ICollection<Comment> Comment { get; set; } //myBlog.Posts




    }
}
