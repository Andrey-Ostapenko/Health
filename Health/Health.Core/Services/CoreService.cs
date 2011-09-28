using Health.Core.API;
using Health.Core.API.Services;

namespace Health.Core.Services
{
    /// <summary>
    /// ������� ������ ����������� ����� ���������� ��� ���� ��������.
    /// </summary>
    public class CoreService : Core, ICoreService
    {
        protected CoreService(IDIKernel di_kernel) : base(di_kernel)
        {
        }

        protected T Get<T>()
        {
            return DIKernel.Get<T>();
        }
    }
}