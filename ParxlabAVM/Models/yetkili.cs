namespace ParxlabAVM.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("yetkili")]
    public partial class yetkili
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public yetkili()
        {
            firma = new HashSet<firma>();
        }

        [Required]
        [StringLength(45)]
        public string yetkiliadi { get; set; }

        public int yetkiid { get; set; }

        public int yetkiliid { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<firma> firma { get; set; }
        [JsonIgnore]
        public virtual yetki yetki { get; set; }
    }
}
