using System;

namespace EFCFModel.Attributes
{
    /// <summary>
    /// ��������� ������� ������� ��� ��������������.
    /// </summary>
    [Flags]
    public enum EditModeEnum
    {
        Multiline = 1
    }

    /// <summary>
    /// �������� ���������� ������ �������� ��� ��������������.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class EditModeAttribute : Attribute, IDisplayAttribute
    {
        /// <summary>
        /// ������ �������� ��� ��������������.
        /// </summary>
        public EditModeEnum Mode { get; set; }
    }

    /// <summary>
    /// ���������� �������� � ������������ ���������� ������.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SingleSelectEditModeAttribute : Attribute, IDisplayAttribute
    {
        /// <summary>
        /// ��� ��������� ��������.
        /// </summary>
        public Type OperationContext;

        /// <summary>
        /// �������� �������� �������� ��� ��������.
        /// </summary>
        public string SourceProperty;

        public SingleSelectEditModeAttribute(Type operationContext, string sourceProperty)
        {
            OperationContext = operationContext;
            SourceProperty = sourceProperty;
        }
    }

    /// <summary>
    /// ���������� ��������-��������� � ������������ ����������� ������������ � ��� ���������
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DinamicCollectionModelAttribute : Attribute, IDisplayAttribute
    {
        /// <summary>
        /// ��� ������ ��������� ���������
        /// </summary>
        public Type TypeOfCollectionElement;

        public DinamicCollectionModelAttribute()
        {
        }

        public DinamicCollectionModelAttribute(Type typeOfCollectionElement)
        {
            TypeOfCollectionElement = typeOfCollectionElement;
        }
    }
}