using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [ScaffoldTable(true), DisplayName("������")]
    public class Doctor : User
    {
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }

        [NotDisplay, DisplayName("������ � �����")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        [NotDisplay, DisplayName("��������")]
        public virtual ICollection<Patient> Patients { get; set; }

        [Required, DisplayName("�������������"), NotDisplay]
        public Specialty Specialty { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}