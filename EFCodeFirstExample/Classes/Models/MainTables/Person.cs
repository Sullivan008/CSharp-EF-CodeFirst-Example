using EFCodeFirstExample.Classes.Models.JunctionTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstExample.Classes.Models.MainTables
{
    public class Person
    {
        public Person()
        {
            PersonXPost = new HashSet<PersonXPost>();
        }

        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength(255)]
        public string PersonName { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime PersonBirthDate { get; set; }
    
        public int AddressId { get; set; }
        public virtual Address Address { get; set; } 

        public virtual ICollection<PersonXPost> PersonXPost { get; set; }
    }
}
