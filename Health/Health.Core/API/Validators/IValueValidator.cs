namespace Health.Core.API.Validators
{
    /// <summary>
    /// ��������� ����������.
    /// </summary>
    public interface IValueValidator
    {
        /// <summary>
        /// ��������� � ����������� ������ �� ������ ��������.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// ����� ��������� �������� �� ����������.
        /// </summary>
        /// <param name="value">��������.</param>
        /// <returns>��������� ��������.</returns>
        bool IsValid(object value);
    }
}