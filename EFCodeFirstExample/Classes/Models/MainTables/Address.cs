using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstExample.Classes.Models.MainTables
{
    public class Address
    {
        public Address()
        {
            Person = new HashSet<Person>();
        }

        [Key]
        public int AddressId { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(255)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(10)]
        public string StreetNumber { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
