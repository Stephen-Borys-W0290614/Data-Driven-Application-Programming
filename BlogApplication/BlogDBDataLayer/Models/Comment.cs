using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDbDataLayer.Models
{
    public class Comment
    {
        //scalar properties
        [Key]
        public int CoolCommentId { get; set; }

        public string Body { get; set; }

        public string Author { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        //navigation properties
        public Post Post { get; set; }

    }
}
