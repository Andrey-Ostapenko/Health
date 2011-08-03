using Health.Site.Areas.Account.Models.Forms;
using Health.Site.Models;

namespace Health.Site.Areas.Account.Models
{
    /// <summary>
    /// ������ ������������� AccountController
    /// </summary>
    public class AccountViewModel : CoreViewModel
    {
        /// <summary>
        /// ����� �����
        /// </summary>
        public LoginFormModel LoginForm { get; set; }

        /// <summary>
        /// ����� ����������� ����������
        /// </summary>
        public RegistrationFormModel RegistrationForm { get; set; }

        /// <summary>
        /// ����� ������ ������������ ��� ������ ����� � �������
        /// </summary>
        public InterviewFormModel InterviewForm { get; set; }
    }
}