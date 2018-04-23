using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCApplicationFormDataLayer.Models
{
    [Table("ProvinceState")]
    public class ProvinceState
    {


        //scalar properties
        [Key]
        [MaxLength(2)]
        [MinLength(2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "char", Order = 0), StringLength(2)]
        public string Code { get; set; }

        [Key]
        [ForeignKey("Country")]
        [MaxLength(2)]
        [MinLength(2)]
        [Column(TypeName = "char", Order = 1), StringLength(2)]
        public string CountryCode { get; set; }


        [Required]
        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR"), StringLength(50)]
        public string Name { get; set; }




        //navigation properties
        public Country Country { get; set; }


        public ICollection<Applicant> Applicants { get; set; }

    }
}
