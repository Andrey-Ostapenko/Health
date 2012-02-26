using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("Surveys"), ScaffoldTable(true), DisplayName("������������� ��������")]
    public class Survey : IIdentity
    {
        public Survey()
        {
            Patients = new List<Patient>();
        }

        [Required, DisplayName("���")]
        public string Name { get; set; }

        [Required, DisplayName("��������")]
        public string Description { get; set; }

        [NotDisplay, DisplayName("��������")]
        public virtual ICollection<Patient> Patients { get; set; }

        #region IIdentity Members

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        #endregion
    }
}