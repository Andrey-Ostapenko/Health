using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("Users"), ScaffoldTable(true), DisplayName("������������")]
    public class User : IIdentity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        [Required, DisplayName("���")]
        public string FirstName { get; set; }

        [Required, DisplayName("�������")]
        public string LastName { get; set; }

        [DisplayName("��������")]
        public string ThirdName { get; set; }

        [Required, DisplayName("�����")]
        public string Login { get; set; }

        [Required, DisplayName("������")]
        public string Password { get; set; }

        [Required, DisplayName("���� ��������")]
        public DateTime Birthday { get; set; }

        [NotDisplay, DisplayName("����")]
        public virtual Role Role { get; set; }
    }
}