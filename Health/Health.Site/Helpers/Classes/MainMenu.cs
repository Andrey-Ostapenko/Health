using System.Collections.Generic;
using Health.Core.API;
using Health.Site.Models;

namespace Health.Site.Helpers.Classes
{
    /// <summary>
    /// ������ ��� ������ �������� ���� �����
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// ����� ����� � ������
        /// </summary>
        /// <param name="core_kernel"></param>
        /// <returns>Html ��� ��� ����</returns>
        public MainMenu(ICoreKernel core_kernel)
        {
            CoreKernel = core_kernel;
        }

        protected ICoreKernel CoreKernel { get; set; }

        /// <summary>
        /// �������� �������� ����
        /// </summary>
        public List<MenuElement> GetMainMenuElements()
        {
            // ��-��������� ������ �� ������ ��������
            var elements = new List<MenuElement> {new MenuElement("�������", "Index", "Home")};
            string role = CoreKernel.AuthServ.UserCredential.Role;
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
            return elements;
        }
    }
}