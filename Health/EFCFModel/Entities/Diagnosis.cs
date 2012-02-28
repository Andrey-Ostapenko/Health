using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("Diagnosis"), ScaffoldTable(true), DisplayName("�������")]
    public class Diagnosis : IIdentity
    {
        public Diagnosis()
        {
            Patients = new List<Patient>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        [Required, DisplayName("���")]
        public string Name { get; set; }

        [Required, DisplayName("���")]
        public string Code { get; set; }

        [Required, NotDisplay, DisplayName("����� ��������")]
        public virtual DiagnosisClass DiagnosisClass { get; set; }

        [NotDisplay, DisplayName("�������� � ����� ���������")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}