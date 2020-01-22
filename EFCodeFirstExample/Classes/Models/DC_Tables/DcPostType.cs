using EFCodeFirstExample.Classes.Models.MainTables;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstExample.Classes.Models.DC_Tables
{
    public class DcPostType
    {
        public DcPostType()
        {
            Post = new HashSet<Post>();
        }

        [Key]
        public int DcPostTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string DcPostTypeName { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
