using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDbDataLayer.Models
{
    public class Post
    {

        //scalar properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Body { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }

        //navigation properties
        public Blog Blog { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Tag> Tags { get; set; }



    }
}
