namespace NSCCApplicationFormDbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProvinceState")]
    public partial class ProvinceState
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProvinceState()
        {
            Applicants = new HashSet<Applicant>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant> Applicants { get; set; }

        public virtual Country Country { get; set; }
    }
}
