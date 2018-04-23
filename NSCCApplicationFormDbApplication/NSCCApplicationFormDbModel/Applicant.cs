namespace NSCCApplicationFormDbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Applicant")]
    public partial class Applicant
    {
        public int ApplicantId { get; set; }

        [StringLength(10)]
        public string SIN { get; set; }

        [StringLength(50)]
        public string Prefix { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstNamePreferred { get; set; }

        [StringLength(50)]
        public string LaseNamePrevious { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(2)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string GenderOther { get; set; }

        [Required]
        [StringLength(50)]
        public string StreetAddress1 { get; set; }

        [StringLength(50)]
        public string StreetAddress2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        public string ProvinceStateCode { get; set; }

        [StringLength(50)]
        public string ProvinceStateOther { get; set; }

        [Required]
        [StringLength(2)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneHome { get; set; }

        [StringLength(20)]
        public string PhoneCell { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(7)]
        public string NSCCStudentId { get; set; }

        public bool IsEnglishFirstLanguage { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstLanguageOther { get; set; }

        public int Citizenship { get; set; }

        [StringLength(2)]
        public string CitizenshipOther { get; set; }

        public bool HasCriminalConvicition { get; set; }

        public bool IsIndigenous { get; set; }

        public bool IsAfricanCanadian { get; set; }

        public bool HasDisability { get; set; }

        public virtual Citizenship Citizenship1 { get; set; }

        public virtual Country Country { get; set; }

        public virtual Country Country1 { get; set; }

        public virtual Gender Gender1 { get; set; }

        public virtual ProvinceState ProvinceState { get; set; }

        public virtual Application Application { get; set; }
    }
}
