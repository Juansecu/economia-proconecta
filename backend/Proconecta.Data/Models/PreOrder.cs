namespace Proconecta.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PreOrder : BaseModel
    {
        #region Properties
        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [Required]
        [StringLength(8000)]
        public string Description { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public List<PreOrderDetail> Details { get; set; }

        [Required]
        [StringLength(36)]
        public string ProviderId { get; set; }
        public Provider Provider { get; set; }

        [Required]
        [StringLength(36)]
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        #endregion
    }
}
