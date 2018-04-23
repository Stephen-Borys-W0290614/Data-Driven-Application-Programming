using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCApplicationFormDataLayer.Models
{
    [Table("Campus")]
    public class Campus
    {


        //scalar properties
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR"), StringLength(120)]
        public string Name { get; set; }
        //Once again the picture shows 120 but the ERD says 50 for the length of the varchar so I kept what
        //The ERD said


        //navigation properties
        public ICollection<Program> Programs { get; set; }

   
        public ICollection<ProgramChoice> ProgramChoice { get; set; }


    }
}
