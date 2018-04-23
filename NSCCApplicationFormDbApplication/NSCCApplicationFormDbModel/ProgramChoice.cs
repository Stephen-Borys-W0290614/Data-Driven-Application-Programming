namespace NSCCApplicationFormDbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramChoice")]
    public partial class ProgramChoice
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public int ProgramId { get; set; }

        public int CampusId { get; set; }

        public int Preference { get; set; }

        public virtual Application Application { get; set; }

        public virtual Campu Campu { get; set; }

        public virtual Program Program { get; set; }
    }
}
