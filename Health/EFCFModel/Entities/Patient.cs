using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [ScaffoldTable(true), DisplayName("�������")]
    public class Patient : User
    {
        public Patient()
        {
            Appointments = new List<Appointment>();
            FunctionalAbnormalities = new List<FunctionalAbnormality>();
            Parameters = new List<Parameter>();
            Diagnosis = new List<Diagnosis>();
            Surveys = new List<Survey>();
        }

        [Required, DisplayName("�����")]
        public string Policy { get; set; }

        [Required, DisplayName("����� �����")]
        public string Card { get; set; }

        [Required, DisplayName("����"), NotDisplay]
        public string Mother { get; set; }

        [Required, DisplayName("���� ������ ������������")]
        public DateTime StartDateOfObservation { get; set; }

        [Required, DisplayName("�������� �������")]
        public string Phone1 { get; set; }

        [NotDisplay, DisplayName("������� �������")]
        public string Phone2 { get; set; }

        [Required, NotDisplay, DisplayName("������")]
        public Doctor Doctor { get; set; }

        [NotDisplay, DisplayName("������ � �����")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        [NotDisplay, DisplayName("�������������� �����")]
        public virtual FunctionalClass FunctionalClass { get; set; }

        [NotDisplay, DisplayName("�������������� ���������")]
        public virtual ICollection<FunctionalAbnormality> FunctionalAbnormalities { get; set; }

        [NotDisplay, DisplayName("���������")]
        public virtual ICollection<Parameter> Parameters { get; set; }

        [NotDisplay, DisplayName("��������")]
        public virtual ICollection<Diagnosis> Diagnosis { get; set; }

        [NotDisplay, DisplayName("������������� ��������")]
        public virtual ICollection<Survey> Surveys { get; set; }

        [NotDisplay, DisplayName("����������� ���������")]
        public virtual ICollection<ParameterStorage> ParametersStorages { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2}:{3})", FirstName, LastName, Policy, Card);
        }
    }
}