using System;
using Health.API.Entities;

namespace Health.Data.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Candidate : ICandidate
    {
        #region ICandidate Members

        /// <summary>
        /// ��� ������������.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// ������� ������������.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// �������� �����������.
        /// </summary>
        public string ThirdName { get; set; }

        /// <summary>
        /// ����� ������������.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// ������ ������������.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// ���� ������������.
        /// </summary>
        public IRole Role { get; set; }

        /// <summary>
        /// ���� ��������.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// ����� ������������ (��� ����������� ����������� ������).
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// ����� ������.
        /// </summary>
        public string Policy { get; set; }

        /// <summary>
        /// ����� ���������� �����.
        /// </summary>
        public string Card { get; set; }

        #endregion
    }
}