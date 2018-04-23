using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCApplicationFormDataLayer.Models
{
    [Table("ProgramChoice")]
    public class ProgramChoice
    {

        //scalar properties
        [Key]
        public int Id { get; set; }


        [Required]
        [ForeignKey("Application")]
        public int ApplicantId { get; set; }



        [Required]
        [ForeignKey("Program")]
        public int ProgramId { get; set; }



        [Required]
        [ForeignKey("Campus")]
        public int CampusId { get; set; }


        [Required]
        public int Preference { get; set; }



        //navigation properties 
        
        public Application Application { get; set; }

        public Campus Campus { get; set; }

        public Program Program { get; set; }




    }
}
