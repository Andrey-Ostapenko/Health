using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("FunctionalClasses"), ScaffoldTable(true), DisplayName("�������������� �����")]
    public class FunctionalClass : IIdentity
    {
        public FunctionalClass()
        {
            Patients = new List<Patient>();
        }

        [Required, DisplayName("���")]
        public string Code { get; set; }

        [Required, DisplayName("��������")]
        public string Description { get; set; }

        [DisplayName("��������")]
        public virtual ICollection<Patient> Patients { get; set; }

        #region IIdentity Members

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        #endregion
    }
}