using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("Parameters"), DisplayName("��������")]
    public class Parameter : IIdentity
    {
        public Parameter()
        {
            Patients = new List<Patient>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        [Required, DisplayName("���")]
        public string Name { get; set; }

        [NotDisplay, DisplayName("�������� ��-���������")]
        public byte[] DefaultValue { get; set; }

        [NotDisplay, DisplayName("��������")]
        public virtual ICollection<Patient> Patients { get; set; }

        [NotDisplay, DisplayName("����������� ���������")]
        public virtual ICollection<ParameterStorage> ParametersStorages { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    [ScaffoldTable(true), DisplayName("������� ��������")]
    public class BoolParameter : Parameter
    {
        public readonly Type ValueType = typeof(bool);
    }

    [ScaffoldTable(true), DisplayName("����� ��������")]
    public class IntegerParameter : Parameter
    {
        [DisplayName("����������� ��������"), Required]
        public int MinValue { get; set; }
        [DisplayName("������������ ��������"), Required]
        public int MaxValue { get; set; }

        public readonly Type ValueType = typeof(int);
    }

    [ScaffoldTable(true), DisplayName("������� ��������")]
    public class DoubleParameter : Parameter
    {
        [DisplayName("����������� ��������"), Required]
        public double MinValue { get; set; }
        [DisplayName("������������ ��������"), Required]
        public double MaxValue { get; set; }

        public readonly Type ValueType = typeof(double);
    }

    [ScaffoldTable(true), DisplayName("��������� ��������")]
    public class StringParameter : Parameter
    {
        [DisplayName("������������ �����"), Required]
        public int MaxLength { get; set; }
        [DisplayName("����������� �����"), Required]
        public int MinLength { get; set; }
        [DisplayName("Regex �������")]
        public string Pattern { get; set; }

        public readonly Type ValueType = typeof(string);
    }
}