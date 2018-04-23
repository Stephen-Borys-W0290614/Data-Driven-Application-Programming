using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCApplicationFormDataLayer.Models
{
    [Table("Application")]
    public class Application
    {

        //scalar properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }


        [Required]
        [Column(TypeName = "Date")]
        public DateTime SubmissionDate { get; set; }


        [Column(TypeName = "Money")]
        public decimal ApplicationFee { get; set; }


        [Required]
        public bool Paid { get; set; }




        //navigation properties

        public Applicant Applicant { get; set; }

        public ICollection<ProgramChoice> ProgramChoice { get; set; }


    }
}
