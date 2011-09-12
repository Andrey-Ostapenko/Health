﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Health.Core.Entities.POCO;

namespace Health.Site.Models.Metadata
{
    public class UserMetadata
    {
        [DisplayName("Идентификатор пользователя")]
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Отчество")]
        public string ThirdName { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        [DisplayName("Роль")]
        public Role Role { get; set; }

        [DisplayName("День рождения")]
        public DateTime Birthday { get; set; }

        [DisplayName("Токен")]
        public string Token { get; set; }
    }
}