using Health.API;
using Health.API.Entities;
using Health.API.Repository;
using Health.API.Services;
using Ninject;

namespace Health.Core.Ninject
{
    /// <summary>
    /// ������ ���������� ��� DI ����
    /// </summary>
    public static class NinjectKernelExtension
    {
        /// <summary>
        /// �������� ��������� ������� ��� ����������� � ���������� ������������� ������� �
        /// DI ���� � ������������ ���� �������
        /// </summary>
        /// <typeparam name="T">��������� ������� ��� �����������</typeparam>
        /// <param name="kernel">DI ����</param>
        /// <param name="core_service">����������� ���� �������</param>
        /// <returns>��������� ����������� ��������� T</returns>
        public static T Get<T>(this IKernel kernel, ICoreKernel core_service)
            where T : ICore
        {
            var t = kernel.Get<T>();
            t.SetKernelAndCoreService(kernel, core_service);
            return t;
        }
    }
}