using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCRM.Models.Campaign
{
    /// <summary>
    /// Campaign Model
    /// </summary>
    [Table("DevTest")]
    public class Campaign
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name of Compaign")]
        [StringLength(255, ErrorMessage = "Name cannot be greater than 255 Characters ")]
        public string CampaignName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int? Clicks { get; set; }

        public int? Conversions { get; set; }

        public int? Impressions { get; set; }

        [Display(Name = "Name of Affiliate")]
        [StringLength(255, ErrorMessage = "Name cannot be greater than 255 Characters ")]
        public string AffiliateName { get; set; }
    }
}
