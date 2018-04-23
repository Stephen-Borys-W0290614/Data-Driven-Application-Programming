namespace NSCCApplicationFormDbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application")]
    public partial class Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            ProgramChoices = new HashSet<ProgramChoice>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicantId { get; set; }

        [Column(TypeName = "date")]
        public DateTime SubmissionDate { get; set; }

        [Column(TypeName = "money")]
        public decimal ApplicationFee { get; set; }

        public bool Paid { get; set; }

        public virtual Applicant Applicant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProgramChoice> ProgramChoices { get; set; }
    }
}
