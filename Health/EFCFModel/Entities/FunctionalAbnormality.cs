using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("FunctionalAbnormalities"), ScaffoldTable(true), DisplayName("�������������� ���������")]
    public class FunctionalAbnormality : IIdentity
    {
        public FunctionalAbnormality()
        {
            ChildFunctionalAbnormalities = new List<FunctionalAbnormality>();
            Patients = new List<Patient>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        [Required, DisplayName("���")]
        public string Name { get; set; }

        [NotDisplay, DisplayName("�������� �������������� ���������")]
        public virtual ICollection<FunctionalAbnormality> ChildFunctionalAbnormalities { get; set; }

        [NotDisplay, DisplayName("������������ �������������� ���������")]
        public virtual FunctionalAbnormality ParentFunctionalAbnormality { get; set; }

        [NotDisplay, DisplayName("��������")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}