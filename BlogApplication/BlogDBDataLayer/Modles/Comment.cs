using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDBDataLayer.Modles
{
    public class Comment
    {

        //Scalar Properties
        public int CommentId { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }


        //Navigation Properties
        public Post Post { get; set; }


    }
}
