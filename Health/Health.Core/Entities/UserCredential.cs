using System;
using Health.Core.Entities.POCO;

namespace Health.Core.Entities
{
    /// <summary>
    /// ������ ������������
    /// </summary>
    [Serializable]
    public class UserCredential : Entity
    {
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
    }
}