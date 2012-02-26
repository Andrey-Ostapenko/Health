using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("Roles"), ScaffoldTable(true), DisplayName("����")]
    public class Role : IIdentity
    {
        public Role()
        {
            Users = new List<User>();
        }

        [StringLength(255), DisplayName("���")]
        public string Name { get; set; }

        [NotDisplay, DisplayName("������������")]
        public virtual ICollection<User> Users { get; set; }

        #region IIdentity Members

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}