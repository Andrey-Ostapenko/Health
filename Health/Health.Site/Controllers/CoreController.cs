using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Health.API;
using Health.API.Entities;
using Health.Core;
using Health.Site.Models;

namespace Health.Site.Controllers
{
    /// <summary>
    /// ������� ����� ������������.
    /// </summary>
    public abstract class CoreController : Controller
    {
        protected ICoreKernel _coreKernel;

        /// <summary>
        /// ����������� ���� �������.
        /// </summary>
        public ICoreKernel CoreKernel
        {
            get { return _coreKernel ?? (_coreKernel = DIKernel.Get<ICoreKernel>()); }
        }

        /// <summary>
        /// DI ���� �������.
        /// </summary>
        public IDIKernel DIKernel { get; private set; }

        /// <summary>
        /// ������.
        /// </summary>
        protected ILogger Logger { get; set; }

        protected CoreController(IDIKernel di_kernel)
        {
            DIKernel = di_kernel;
            Logger = DIKernel.Get<ILogger>();
        }

        /// <summary>
        /// ��������.
        /// </summary>
        /// <typeparam name="T">��� �����������.</typeparam>
        /// <param name="action">�������� �����������.</param>
        /// <returns>��������� ���������. </returns>
        protected ActionResult RedirectTo<T>(Expression<Action<T>> action)
            where T : IController
        {
            var act = (MethodCallExpression) action.Body;
            string name = act.Method.Name;
            return RedirectToAction(name);
        }

        /// <summary>
        /// ��������.
        /// </summary>
        /// <typeparam name="T">��� �����������.</typeparam>
        /// <param name="action">�������� �����������.</param>
        /// <param name="model">������ ��� ���������� � ���������.</param>
        /// <returns>��������� ���������. </returns>
        protected ActionResult RedirectTo<T>(Expression<Action<T>> action, object model)
            where T : IController
        {
            TempData["model"] = model;
            return RedirectTo(action);
        }

        /// <summary>
        /// ������� ��������� �������� �� ����������.
        /// </summary>
        /// <typeparam name="TInstance">��������� ��������.</typeparam>
        /// <returns>��������� ��������.</returns>
        public TInstance Instance<TInstance>()
            where TInstance : IEntity
        {
            Logger.Debug(String.Format("��������� �������� ��� ���������� - {0}.", typeof(TInstance).Name));
            return DIKernel.Get<TInstance>();
        }

        /// <summary>
        /// ������� ��������� �������� �� ����������.
        /// </summary>
        /// <typeparam name="TInstance">��������� ��������.</typeparam>
        /// <param name="init">������������� ��������.</param>
        /// <returns>��������� ��������.</returns>
        public TInstance Instance<TInstance>(Action<TInstance> init) 
            where TInstance : IEntity
        {
            Logger.Debug(String.Format("��������� �������� ��� ���������� - {0}.", typeof(TInstance).Name));
            var obj = DIKernel.Get<TInstance>();
            init.Invoke(obj);
            return obj;
        }
    }
}