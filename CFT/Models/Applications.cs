namespace CFT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Applications
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Applications()
        {
            BugTrackers = new List<BugTrackers>();
        }

        [Key]
        public int ApplicationId { get; set; }

        [Required]
        [StringLength(30)]
        public string NameApplication { get; set; }

        //public virtual Applications Applications1 { get; set; }

        //public virtual Applications Applications2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugTrackers> BugTrackers { get; set; }
    }
}
