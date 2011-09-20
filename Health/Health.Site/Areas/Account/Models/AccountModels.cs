﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Health.Core.Entities.POCO;
using Health.Site.Models;

namespace Health.Site.Areas.Account.Models
{
    /// <summary>
    /// Модель формы авторизации на сайте
    /// </summary>
    [DisplayName("Вход на сайт")] 
    public class LoginForm : CoreViewModel
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(ErrorMessage = "Введите, пожалуйста, логин.")]
        [DisplayName("Логин")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage = "Введите, пожалуйста, пароль.")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Необходимо запоминать пользователя?
        /// </summary>
        [DisplayName("Запомнить?")]
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// Модель формы регистрации кандидатов
    /// </summary>
    public class RegistrationForm : CoreViewModel
    {
        public Candidate Candidate { get; set; }
    }

    /// <summary>
    /// Форма опроса пользователя при первом входе в систему
    /// </summary>
    public class InterviewForm : CoreViewModel
    {
        public IList<Parameter> Parameters { get; set; }
    }
}