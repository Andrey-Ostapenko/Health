using Health.Core.API;
using Health.Core.API.Services;

namespace Health.Core.Services
{
    /// <summary>
    /// ������� ������ ����������� ����� ���������� ��� ���� ��������.
    /// </summary>
    public class CoreService : Core, ICoreService
    {
        protected CoreService(IDIKernel diKernel) : base(diKernel)
        {
        }

        /// <summary>
        /// �������� ��������� �� ����������.
        /// </summary>
        /// <typeparam name="T">���������.</typeparam>
        /// <returns>���������.</returns>
        protected T Get<T>()
        {
            return DIKernel.Get<T>();
        }
    }
}