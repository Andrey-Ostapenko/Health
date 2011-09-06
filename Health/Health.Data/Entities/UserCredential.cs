using System;
using Health.API.Entities;

namespace Health.Data.Entities
{
    /// <summary>
    /// ������ ������������
    /// </summary>
    [Serializable]
    public class UserCredential : IUserCredential
    {
        #region IUserCredential Members

        /// <summary>
        /// ����� ������������
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// ���� ������������
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// ����������� �� ������������
        /// </summary>
        public bool IsAuthirization { get; set; }

        /// <summary>
        /// �������� �� ������������
        /// </summary>
        public bool IsRemember { get; set; }

        #endregion
    }
}