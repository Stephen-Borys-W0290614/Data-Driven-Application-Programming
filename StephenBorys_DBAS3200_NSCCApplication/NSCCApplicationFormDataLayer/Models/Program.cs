using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCApplicationFormDataLayer.Models
{
    [Table("Program")]
    public class Program
    {


        //scalar properties
        [Key]
        public int Id { get; set; }



        [Required]
        [MaxLength(120)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR"), StringLength(120)]
        public string Name { get; set; }
        //In the ERD the length for Name is 50 so i kept it as 50 but
        //In thepictures of how the tables should look it was 120
        //I kept it as 50 because thats what the ERD said. If it need to be 
        //fixed it is an easy fix. I am putting this to show that I saw and
        //was not sure which to keep



        //navigation properties

        public ICollection<Campus> Campuss { get; set; }

        public ICollection<ProgramChoice> ProgramChoice { get; set; }



    }
}
