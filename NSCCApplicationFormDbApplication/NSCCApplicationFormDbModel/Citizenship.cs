namespace NSCCApplicationFormDbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Citizenship")]
    public partial class Citizenship
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Citizenship()
        {
            Applicants = new HashSet<Applicant>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
