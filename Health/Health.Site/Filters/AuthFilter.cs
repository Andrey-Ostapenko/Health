using System;
using System.Web.Mvc;
using System.Web.Routing;
using Health.Core.API;
using Health.Core.API.Services;
using Health.Core.Entities;

namespace Health.Site.Filters
{
    public class AuthFilter : IAuthorizationFilter
    {
        /// <summary>
        /// ���� ������������ ���� �������� ������
        /// </summary>
        protected readonly RedirectToRouteResult RedirectResult = new RedirectToRouteResult(
            new RouteValueDictionary(new {area = "Account", controller = "Authorization", action = "Login"}));

        protected readonly RedirectToRouteResult RedirectResultForQuickLogin = new RedirectToRouteResult(
            new RouteValueDictionary(new {area = "", controller = "Appointment", action = "Index"}));

        /// <summary>
        /// ����������� ���� (��������� ����, ��� � DenyRoles)
        /// </summary>
        public string AllowRoles;

        /// <summary>
        /// ����������� ����
        /// </summary>
        public string DenyRoles;

        private string _userRole;

        public AuthFilter(IDIKernel diKernel, string allowRoles, string denyRoles)
        {
            DIKernel = diKernel;
            AllowRoles = allowRoles;
            DenyRoles = denyRoles;
        }

        /// <summary>
        /// ���� ������������
        /// </summary>
        private string UserRole
        {
            get
            {
                if (String.IsNullOrEmpty(_userRole))
                {
                    _userRole = DIKernel.Get<IAuthorizationService>().UserCredential.Role;
                }
                return _userRole;
            }
        }

        /// <summary>
        /// ����������� ������
        /// </summary>
        protected IDIKernel DIKernel { get; set; }

        #region IAuthorizationFilter Members

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // ���� � ������������ ������ ��� ���� (������� ?)
            if (String.IsNullOrEmpty(DIKernel.Get<IAuthorizationService>().UserCredential.Role))
            {
                // ���������� ��� ������ �� �����
                DIKernel.Get<IAuthorizationService>().Logout();
            }

            // ���� �� ������ ����� �������
            if (String.IsNullOrEmpty(AllowRoles) & String.IsNullOrEmpty(DenyRoles))
            {
                // ������� ��� ���� �������������� ������������� �������� ������
                if (!DIKernel.Get<IAuthorizationService>().UserCredential.IsAuthorization)
                {
                    filterContext.Result = RedirectResult;
                    return;
                }
            }

            // ���� ������� ������ ����� �� ������ �������
            if (String.IsNullOrEmpty(AllowRoles) & !String.IsNullOrEmpty(DenyRoles))
            {
                filterContext.Result = OnlyDenyPermission(filterContext.Result);
                return;
            }

            // ���� ������� ����� ������ �� ���������� �������
            if (!String.IsNullOrEmpty(AllowRoles) & String.IsNullOrEmpty(DenyRoles))
            {
                filterContext.Result = OnlyAllowPermission(filterContext.Result);
                return;
            }


            if (!String.IsNullOrEmpty(AllowRoles) & !String.IsNullOrEmpty(DenyRoles))
            {
                filterContext.Result = OnlyDenyPermission(filterContext.Result);
                filterContext.Result = OnlyAllowPermission(filterContext.Result);
            }
        }

        #endregion

        /// <summary>
        /// ���� ������ ���� ����������� ����������
        /// </summary>
        /// <param name="default">��������� �������� � ����������� ��-���������</param>
        /// <returns>��������� �������� � �����������</returns>
        private ActionResult OnlyDenyPermission(ActionResult @default)
        {
            string[] roles = DenyRoles.Split(',');

            foreach (string role in roles)
            {
                if (role == UserRole || role == DefaultRoles.All)
                {
                    return RedirectResult;
                }
            }

            return @default;
        }

        /// <summary>
        /// ���� ������ ���� ����������� ����������
        /// </summary>
        /// <param name="default">��������� �������� � ����������� ��-���������</param>
        /// <returns>��������� �������� � �����������</returns>
        private ActionResult OnlyAllowPermission(ActionResult @default)
        {
            string[] roles = AllowRoles.Split(',');

            bool isQuick = false;
            foreach (string role in roles)
            {
                if (role == DefaultRoles.QuickLogin) isQuick = true;
                if (role == UserRole) return @default;
            }
            return  isQuick ? RedirectResultForQuickLogin : RedirectResult;
        }
    }
}