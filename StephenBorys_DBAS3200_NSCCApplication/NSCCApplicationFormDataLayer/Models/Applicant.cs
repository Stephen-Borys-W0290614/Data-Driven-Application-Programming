using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCApplicationFormDataLayer.Models
{
    [Table("Applicant")]
    public class Applicant
    {

        //scalar properties
        [Key]
        [Column(Order = 0)]
        public int ApplicantId { get; set; }


        [MaxLength(10)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR", Order = 1), StringLength(10)]
        public string SIN { get; set; }


        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 2), StringLength(50)]
        public string Prefix { get; set; }

        [Required]
        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR",Order = 3), StringLength(50)]
        public string FirstName { get; set; }


        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 4), StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 5), StringLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 6), StringLength(50)]
        public string FirstNamePreferred { get; set; }


        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 7), StringLength(50)]
        public string LaseNamePrevious{ get; set; }


        [Required]
        [Column(Order = 8, TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }


        [MaxLength(2)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR", Order = 9), StringLength(2)]
        public string Gender { get; set; }


        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 10), StringLength(50)]
        public string GenderOther { get; set; }


        [Required]
        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 11), StringLength(50)]
        public string StreetAddress1 { get; set; }


        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 12), StringLength(50)]
        public string StreetAddress2 { get; set; }

    
        [Required]
        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 13), StringLength(50)]
        public string City { get; set; }


        [MaxLength(2)]
        [MinLength(2)]
        [Column(TypeName = "char", Order = 14), StringLength(2)]
        public string ProvinceStateCode { get; set; }


        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 15), StringLength(50)]
        public string ProvinceStateOther { get; set; }

        [Required]
        //[ForeignKey("Country")] //This has to be here. 
        [MaxLength(2)]
        //[MinLength(2)]
        [Column(TypeName = "char", Order = 16), StringLength(2)]
        public string CountryCode { get; set; }


        [Required]
        [MaxLength(20)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR", Order = 17), StringLength(20)]
        public string PhoneHome { get; set; }


        [MaxLength(20)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR", Order = 18), StringLength(20)]
        public string PhoneCell { get; set; }


        [Required]
        [MaxLength(50)]
        //[MinLength(1)]
        [Column(TypeName = "VARCHAR", Order = 19), StringLength(50)]
        public string EmailAddress { get; set; }


        [MaxLength(7)]
        [MinLength(7)]
        [Column(TypeName = "char", Order = 20), StringLength(7)]
        public string NSCCStudentId { get; set; }



        [Required]
        [Column(Order = 21)]
        public bool IsEnglishFirstLanguage { get; set; }


        [Required]
        [MaxLength(20)]
        //[MinLength(1)]
        [Column(TypeName = "NVARCHAR", Order = 22), StringLength(20)]
        public string FirstLanguageOther { get; set; }


        [Required]
        [Column(Order = 23)]
        public int Citizenship { get; set; }


        //[ForeignKey("Country")] //This has to be here. If it is not it will create a second country_code
        [MaxLength(2)]
        //[MinLength(2)]
        [Column(TypeName = "char", Order = 24), StringLength(2)]
        public string CitizenshipOther { get; set; }


        [Required]
        [Column(Order = 25)]
        public bool HasCriminalConvicition { get; set; }


        [Required]
        [Column(Order = 26)]
        public bool IsIndigenous { get; set; }


        [Required]
        [Column(Order = 27)]
        public bool IsAfricanCanadian { get; set; }


        [Required]
        [Column(Order = 28)]
        public bool HasDisability { get; set; }



        //navigation properties
        //There Are also forign keys being made here aswell

        [ForeignKey("CountryCode")]
        public Country Country { get; set; }

        [ForeignKey("CitizenshipOther")]
        public Country CitizenshipOtherForApplicant { get; set; }

        [ForeignKey("Gender")]
        public Gender ApplicationtGender { get; set; } 


        [ForeignKey("Citizenship")]
        public Citizenship TheCitizenship { get; set; }

        [ForeignKey("ProvinceStateCode, CountryCode")]
        public ProvinceState ProvinceState { get; set; }




        //You do not need this because it is a one to one relashionship
        //public ICollection<Application> Application { get; set; }





    }
}
