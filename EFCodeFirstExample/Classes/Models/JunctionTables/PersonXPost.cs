using EFCodeFirstExample.Classes.Models.MainTables;

namespace EFCodeFirstExample.Classes.Models.JunctionTables
{
    public class PersonXPost
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
