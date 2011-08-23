using System;

namespace Health.Core.Entities.POCO
{
    /// <summary>
    /// 
    /// </summary>
    public class Candidate : Entity
    {
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
        public Role Role { get; set; }

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
    }
}