using EFCodeFirstExample.Classes.Models.DC_Tables;
using EFCodeFirstExample.Classes.Models.JunctionTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstExample.Classes.Models.MainTables
{
    public class Post
    {
        public Post()
        {
            PersonXPost = new HashSet<PersonXPost>();
        }

        [Key]
        public int PostId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DatePublished { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength]
        public string Body { get; set; }

        public int DcPostTypeId { get; set; }
        public virtual DcPostType DcPostType { get; set; }

        public virtual ICollection<PersonXPost> PersonXPost { get; set; }
    }
}
