﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Health.API.Entities
{
    /// <summary>
    /// Интерфейс валидатора
    /// </summary>
    public interface IValueValidator
    {
        /// <summary>
        /// Метод проверяет значение на валидность
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Результат проверки</returns>
        bool IsValid(object value);
    }
}