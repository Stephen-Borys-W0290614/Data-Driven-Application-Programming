using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDBDataLayer.Modles
{
    public class Blog
    {
        //Scalar Properties
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        //Navigation Properties
        public ICollection<Post> Posts { get; set; } //myBlog.Posts


    }
}
