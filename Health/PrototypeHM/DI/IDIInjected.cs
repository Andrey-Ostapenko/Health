namespace Prototype.DI
{
    /// <summary>
    /// ������ ��� �������� � ������� ������������ DI-����.
    /// </summary>
    public interface IDIInjected
    {
        IDIKernel DIKernel { get; }
    }
}