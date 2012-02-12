using System;
using System.ComponentModel;
using PrototypeHM.DB;
using PrototypeHM.DB.Attributes;

namespace PrototypeHM.User
{
    public class UserFullData : QueryStatus, IIdentity
    {
        [DisplayName(@"�������������"), Hide]
        public int Id { get; set; }

        [DisplayName(@"���")]
        public string FirstName { get; set; }

        [DisplayName(@"�������")]
        public string LastName { get; set; }

        [DisplayName(@"��������")]
        public string ThirdName { get; set; }

        [DisplayName(@"�����")]
        public string Login { get; set; }

        [DisplayName(@"������")]
        public string Password { get; set; }

        [DisplayName(@"����")]
        public string Role { get; set; }

        [DisplayName(@"���� ��������")]
        public DateTime Birthday { get; set; }

        [DisplayName(@"�����"), Hide]
        public string Token { get; set; }

        public UserFullData():base()
        {
            foreach (var pI in this.GetType().GetProperties())
            {
                if (pI.PropertyType == typeof(string))
                {
                    pI.SetValue(this, string.Empty, null);
                }

                if (pI.PropertyType == typeof(DateTime))
                {
                    pI.SetValue(this, DateTime.Today, null);
                }
            }
        }

    }
}
