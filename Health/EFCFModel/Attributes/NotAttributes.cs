using System;

namespace EFCFModel.Attributes
{
    /// <summary>
    /// �������� ��� �������� �� ����� ��������.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NotMapAttribute : Attribute, IMapAttribute
    {
    }

    /// <summary>
    /// �������� ��� �������� �� ����� ������������ ������������ ��� ���������/��������������/����������.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NotDisplayAttribute : Attribute, IDisplayAttribute
    {
    }

    /// <summary>
    /// �������� ��� �������� ����� ������ �� ������������ ��� ���������/��������������/����������.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class HideAttribute : Attribute, IDisplayAttribute
    {
    }

    /// <summary>
    /// �������� ��� �������� �� ����� �������� ��� ��������� ��� ��������������/����������.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NotEditAttribute : Attribute, IDisplayAttribute
    {
    }
}