using System.Web.Mvc;

namespace Health.Site.Attributes
{
    /// <summary>
    /// ������� �������� ������� � ������������
    /// </summary>
    public class Auth : ActionFilterAttribute
    {
        /// <summary>
        /// ����������� ���� (��������� ����, ��� � DenyRoles)
        /// </summary>
        public string AllowRoles;

        /// <summary>
        /// ����������� ����
        /// </summary>
        public string DenyRoles;

        public override void OnActionExecuting(ActionExecutingContext filter_context)
        {
        }
    }
}