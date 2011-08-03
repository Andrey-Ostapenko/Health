using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Health.API;
using Health.Site.Models;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Health.Site.Helpers
{
    /// <summary>
    /// ������ ��� ������ �������� ���� �����
    /// </summary>
    public static class MainMenuHelper
    {
        /// <summary>
        /// �������� ����
        /// </summary>
        private static IList<MenuElement> _elements;

        /// <summary>
        /// ����������� ������
        /// </summary>
        [Inject]
        public static ICoreKernel CoreServ { get; set; }

        /// <summary>
        /// �������� �������� ����
        /// </summary>
        private static void GetMainMenuElements()
        {
            // ��-��������� ������ �� ������ ��������
            var elements = new List<MenuElement> {new MenuElement("�������", "Index", "Home")};
            string role = CoreServ.AuthServ.UserCredential.Role;
            switch (role)
            {
                case "Guest":
                    {
                        elements.Add(new MenuElement("����", "Login", "Authorization", "Account"));
                        elements.Add(new MenuElement("�����������", "Registration", "Registration", "Account"));
                        break;
                    }
                case "Admin":
                    {
                        elements.Add(new MenuElement("������ �������", "Index", "Home", "Admin"));
                        break;
                    }
            }
            if (role != "Guest")
            {
                elements.Add(new MenuElement("�����", "Logout", "Authorization", "Account"));
            }

            _elements = elements;
        }

        /// <summary>
        /// ����������� ������ ��������� � html ���
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        private static MvcHtmlString GetHtmlString(HtmlHelper helper)
        {
            string menu = string.Format("<li>���������, {0}</li>", CoreServ.AuthServ.UserCredential.Login);
            foreach (MenuElement element in _elements)
            {
                menu += "<li>" + helper.ActionLink(element.Title, element.Action, element.Controller, new { area = element.Area }, null) + "</li>";
            }

            return MvcHtmlString.Create(menu);
        }

        /// <summary>
        /// ����� ����� � ������
        /// </summary>
        /// <param name="helper">����������� ����� ��������</param>
        /// <param name="core_kernel"></param>
        /// <returns>Html ��� ��� ����</returns>
        public static MvcHtmlString MainMenu(this HtmlHelper helper, ICoreKernel core_kernel)
        {
            //TODO: ������ ���� �������
            //CoreServ = ServiceLocator.Current.GetInstance<ICoreKernel>();
            CoreServ = core_kernel;
            GetMainMenuElements();
            return GetHtmlString(helper);
        }
    }
}