using System;

namespace Model.Attributes
{
    /// <summary>
    /// ��������� ������� ������� ��� ��������������.
    /// </summary>
    [Flags]
    public enum EditMode
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
        private readonly EditMode _mode;

        public EditModeAttribute(EditMode mode)
        {
            _mode = mode;
        }

        public EditMode GetEditMode()
        {
            return _mode;
        }
    }
}