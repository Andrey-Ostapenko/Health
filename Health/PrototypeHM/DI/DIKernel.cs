using System;
using System.Collections.Generic;
using Ninject;

namespace Prototype.DI
{
    public class ConstructorArgument
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class DIKernel : IDIKernel
    {
        public DIKernel(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected IKernel Kernel { get; set; }

        #region IDIKernel Members

        /// <summary>
        /// �������� ������ �� ��� ����������.
        /// </summary>
        /// <typeparam name="TObject">��������� �������.</typeparam>
        /// <returns>������ ��������� ����������.</returns>
        public TObject Get<TObject>()
        {
            return Kernel.Get<TObject>();
        }

        /// <summary>
        /// �������� ������ �� ��� ����������.
        /// </summary>
        /// <param name="type">��������� �������.</param>
        /// <returns>������ ��������� ����������.</returns>
        public object Get(Type type)
        {
            return Kernel.Get(type);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        /// <summary>
        /// �������� ��������� ������� � ������������ ������� ���������� ������������.
        /// </summary>
        /// <param name="type">��� �������.</param>
        /// <param name="constructorArguments">��������� ������������.</param>
        /// <returns>��������� �������.</returns>
        public object Get(Type type, params ConstructorArgument[] constructorArguments)
        {
            var parameters = new Ninject.Parameters.ConstructorArgument[constructorArguments.Length];
            for (int i = 0; i < parameters.Length; i++)
                parameters[i] = new Ninject.Parameters.ConstructorArgument(constructorArguments[i].Name,
                                                                           constructorArguments[i].Value);
            return Kernel.Get(type, parameters);
        }

        #endregion
    }
}