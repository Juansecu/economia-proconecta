namespace Proconecta.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Review : BaseModel
    {
        #region Properties
        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        [Required]
        [StringLength(8000)]
        public string Description { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(36)]
        public string ProviderId { get; set; }
        public Provider Provider { get; set; }
        #endregion
    }
}
