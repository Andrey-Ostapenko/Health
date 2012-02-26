using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("DiagnosisClasses"), ScaffoldTable(true), DisplayName("����� ��������")]
    public class DiagnosisClass : IIdentity
    {
        public DiagnosisClass()
        {
            Diagnosis = new List<Diagnosis>();
            ChildDiagnosisClasses = new List<DiagnosisClass>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }
        [Required, DisplayName("���")]
        public string Name { get; set; }
        [Required, DisplayName("���")]
        public string Code { get; set; }
        [DisplayName("��������"), NotDisplay]
        public virtual ICollection<Diagnosis> Diagnosis { get; set; }
        [DisplayName("�������� ������ ���������"), NotDisplay]
        public virtual ICollection<DiagnosisClass> ChildDiagnosisClasses { get; set; }
        [DisplayName("������������ ����� ��������"), NotDisplay]
        public virtual DiagnosisClass ParentDiagnosisClass { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}", Name, Code);
        }
    }
}