using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCApplicationFormDataLayer.Models
{
    [Table("Gender")]
    public class Gender
    {

        //scalar properties
        [Key]
        [MaxLength(2)]
        //[MinLength(2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "VARCHAR"), StringLength(2)]
        public string Code { get; set; }



        [Required]
        [MaxLength(100)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public string Description { get; set; }
        //Once again the picture shows 100 but the ERD says 50 for the length of the varchar so I kept what
        //The ERD said



        //navigation properties

        public ICollection<Applicant> Applicants { get; set; }


    }
}
