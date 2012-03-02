using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EFCFModel.Attributes;

namespace EFCFModel.Entities
{
    [Table("Surveys"), ScaffoldTable(true), DisplayName("������������� ��������")]
    public class Survey : IIdentity
    {
        public Survey()
        {
            SurveysStorages = new List<SurveyStorage>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Hide]
        public int Id { get; set; }

        [Required, DisplayName("���")]
        public string Name { get; set; }

        [Required, DisplayName("��������"), EditMode(EditMode.Multiline)]
        public string Description { get; set; }

        [NotDisplay, DisplayName("��������� ��������")]
        public virtual ICollection<SurveyStorage> SurveysStorages { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}