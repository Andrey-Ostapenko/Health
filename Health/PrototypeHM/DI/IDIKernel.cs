using System;
using System.Collections.Generic;

namespace Prototype.DI
{
    /// <summary>
    /// ��������� ������� � DI ����.
    /// </summary>
    public interface IDIKernel
    {
        /// <summary>
        /// �������� ������ �� ��� ����������.
        /// </summary>
        /// <typeparam name="TObject">��������� �������.</typeparam>
        /// <returns>������ ��������� ����������.</returns>
        TObject Get<TObject>();

        /// <summary>
        /// �������� ������ �� ��� ����������.
        /// </summary>
        /// <param name="type">��������� �������.</param>
        /// <returns>������ ��������� ����������.</returns>
        object Get(Type type);

        /// <summary>
        /// �������� ��� ������� ��������� � ������ ��������.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        IEnumerable<object> GetServices(Type serviceType);

        /// <summary>
        /// �������� ��������� ������� � ������������ ������� ���������� ������������.
        /// </summary>
        /// <param name="type">��� �������.</param>
        /// <param name="constructorArguments">��������� ������������.</param>
        /// <returns>��������� �������.</returns>
        object Get(Type type, params ConstructorArgument[] constructorArguments);
    }
}