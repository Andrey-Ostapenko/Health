namespace PrototypeHM.DI
{
    /// <summary>
    /// ������ ��� �������� � ������� ������������ DI-����.
    /// </summary>
    public interface IDIInjected
    {
        IDIKernel DIKernel { get; }
    }
}