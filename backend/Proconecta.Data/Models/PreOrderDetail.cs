namespace Proconecta.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PreOrderDetail : BaseModel
    {
        #region Properties
        [Required]
        public double Quantity { get; set; }

        [Required]
        public double PriceUnit { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        [StringLength(36)]
        public string PreOrderId { get; set; }
        public PreOrder PreOrder { get; set; }

        [Required]
        [StringLength(36)]
        public string ProductId { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
