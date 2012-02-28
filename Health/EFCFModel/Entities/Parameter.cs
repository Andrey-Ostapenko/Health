using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("Parameters"), DisplayName("��������")]
    public abstract class Parameter : IIdentity
    {
        protected Parameter()
        {
            Patients = new List<Patient>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        [Required, DisplayName("���")]
        public string Name { get; set; }

        [NotDisplay, DisplayName("�������� ��-���������"), ByteType("ValueType")]
        public byte[] DefaultValue { get; set; }

        [NotDisplay, DisplayName("��������")]
        public virtual ICollection<Patient> Patients { get; set; }

        [NotDisplay, DisplayName("����������� ���������")]
        public virtual ICollection<ParameterStorage> ParametersStorages { get; set; }

        [NotMapped, NotDisplay]
        public abstract Type ValueType { get; }

        public override string ToString()
        {
            return Name;
        }
    }

    [ScaffoldTable(true), DisplayName("������� ��������")]
    public class BoolParameter : Parameter
    {
        [NotDisplay]
        public override Type ValueType { get { return typeof (bool); } }
    }

    [ScaffoldTable(true), DisplayName("����� ��������")]
    public class IntegerParameter : Parameter
    {
        [DisplayName("����������� ��������"), Required]
        public int MinValue { get; set; }
        [DisplayName("������������ ��������"), Required]
        public int MaxValue { get; set; }

        [NotDisplay]
        public override Type ValueType { get { return typeof (int); } }
    }

    [ScaffoldTable(true), DisplayName("������� ��������")]
    public class DoubleParameter : Parameter
    {
        [DisplayName("����������� ��������"), Required]
        public double MinValue { get; set; }
        [DisplayName("������������ ��������"), Required]
        public double MaxValue { get; set; }

        [NotDisplay]
        public override Type ValueType { get { return typeof (double); } }
    }

    [ScaffoldTable(true), DisplayName("��������� ��������")]
    public class StringParameter : Parameter
    {
        [DisplayName("������������ �����"), Required]
        public int MaxLength { get; set; }
        [DisplayName("����������� �����"), Required]
        public int MinLength { get; set; }

        [NotDisplay]
        public override Type ValueType { get { return typeof (string); } }
    }

    [ScaffoldTable(true), DisplayName("��������-����")]
    public class DateTimeParameter : Parameter
    {
        [DisplayName("����������� ����"), Required]
        public DateTime MinDate { get; set; }
        [DisplayName("������������ ����"), Required]
        public DateTime MaxDate { get; set; }

        [NotDisplay]
        public override Type ValueType { get { return typeof(DateTime); } }
    }

    public class ListParameter : Parameter
    {
        private readonly ObservableCollection<string> _collection;

        public ListParameter()
        {
            _collection = new ObservableCollection<string>();
            _collection.CollectionChanged += CllectionChanged;
        }

        private void CllectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }

        #region Overrides of Parameter

        public override Type ValueType { get { return typeof (ObservableCollection<string>); } }

        #endregion
    }
}