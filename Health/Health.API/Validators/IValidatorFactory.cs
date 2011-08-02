namespace Health.API.Validators
{
    /// <summary>
    /// ������� �����������.
    /// </summary>
    public interface IValidatorFactory
    {
        /// <summary>
        /// ��������� � ����������� ������ �� ������ ��������.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// ��������� �������� �� ���������� �������� ���� ����������.
        /// </summary>
        /// <param name="validator_type">��� ����������.</param>
        /// <param name="value">��������.</param>
        /// <returns>���������� ��������.</returns>
        bool IsValid(string validator_type, object value);
    }
}