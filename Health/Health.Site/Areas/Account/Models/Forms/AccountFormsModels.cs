using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Health.API;
using Health.API.Entities;
using Health.Data.Validators;

namespace Health.Site.Areas.Account.Models.Forms
{
    /// <summary>
    /// ������ ����� ����������� �� �����
    /// </summary>
    public class LoginFormModel
    {
        /// <summary>
        /// ����� ������������
        /// </summary>
        [Required(ErrorMessage = "�������, ����������, �����")]
        public string Login { get; set; }

        /// <summary>
        /// ������ ������������
        /// </summary>
        [Required(ErrorMessage = "�������, ����������, ������")]
        public string Password { get; set; }

        /// <summary>
        /// ���������� ���������� ������������?
        /// </summary>
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// ������ ����� ����������� ����������
    /// </summary>
    public class RegistrationFormModel : ICandidate
    {
        #region ICandidate Members

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ThirdName { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        public IRole Role { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [NotMapped]
        public string Token { get; set; }

        [Required]
        public string Policy { get; set; }

        [Required]
        public string Card { get; set; }

        #endregion
    }

    /// <summary>
    /// ����� ������ ������������ ��� ������ ����� � �������
    /// </summary>
    public class InterviewFormModel : IValidatableObject
    {
        public InterviewFormModel(IDIKernel di_kernel)
        {
            DIKernel = di_kernel;
        }

        public IDIKernel DIKernel { get; protected set; }

        public IEnumerable<IParameter> Parameters { get; set; }

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validation_context)
        {
            var result = new List<ValidationResult>();
            var validator_factory = DIKernel.Get<IValidatorFactory>();
            if (!validator_factory.IsValid(typeof (RequiredValidator).ToString(), Parameters.ToList()[0].Value))
            {
                result.Add(new ValidationResult(validator_factory.Message, new[]
                                                                               {
                                                                                   "Parameters[0].Value"
                                                                               }));
            }
            return result;
        }

        #endregion
    }
}