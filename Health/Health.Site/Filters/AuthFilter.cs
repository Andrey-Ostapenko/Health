using System;
using System.Web.Mvc;
using System.Web.Routing;
using Health.Core.API;
using Health.Core.API.Services;

namespace Health.Site.Filters
{
    public class AuthFilter : IAuthorizationFilter
    {
        /// <summary>
        /// ���� ������������ ���� �������� ������
        /// </summary>
        protected readonly RedirectToRouteResult RedirectResult = new RedirectToRouteResult(
            new RouteValueDictionary(new {area = "Account", controller = "Authorization", action = "Login"}));

        /// <summary>
        /// ����������� ���� (��������� ����, ��� � DenyRoles)
        /// </summary>
        public string AllowRoles;

        /// <summary>
        /// ����������� ����
        /// </summary>
        public string DenyRoles;

        private string _userRole;

        public AuthFilter(IDIKernel di_kernel, string allow_roles, string deny_roles)
        {
            DIKernel = di_kernel;
            AllowRoles = allow_roles;
            DenyRoles = deny_roles;
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

        public void OnAuthorization(AuthorizationContext filter_context)
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
                if (!DIKernel.Get<IAuthorizationService>().UserCredential.IsAuthirization)
                {
                    filter_context.Result = RedirectResult;
                    return;
                }
            }

            // ���� ������� ������ ����� �� ������ �������
            if (String.IsNullOrEmpty(AllowRoles) & !String.IsNullOrEmpty(DenyRoles))
            {
                filter_context.Result = OnlyDenyPermission(filter_context.Result);
                return;
            }

            // ���� ������� ����� ������ �� ���������� �������
            if (!String.IsNullOrEmpty(AllowRoles) & String.IsNullOrEmpty(DenyRoles))
            {
                filter_context.Result = OnlyAllowPermission(filter_context.Result);
                return;
            }


            if (!String.IsNullOrEmpty(AllowRoles) & !String.IsNullOrEmpty(DenyRoles))
            {
                filter_context.Result = OnlyDenyPermission(filter_context.Result);
                filter_context.Result = OnlyAllowPermission(filter_context.Result);
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
                if (role == UserRole || role == DIKernel.Get<IAuthorizationService>().DefaultRoles.All.Name)
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

            foreach (string role in roles)
            {
                if (role == UserRole)
                {
                    return @default;
                }
            }
            return RedirectResult;
        }
    }
}