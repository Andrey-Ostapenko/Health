using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("Appointments"), ScaffoldTable(true), DisplayName("����� � �����")]
    public class Appointment : IIdentity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        [DisplayName("���� ������")]
        public DateTime Date { get; set; }

        [DisplayName("������")]
        public virtual Doctor Doctor { get; set; }

        [DisplayName("�������")]
        public virtual Patient Patient { get; set; }

        public override string ToString()
        {
            return string.Format("{0} � {1} �� {2}", Patient, Doctor, Date);
        }
    }
}