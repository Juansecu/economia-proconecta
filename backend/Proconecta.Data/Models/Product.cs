﻿namespace Proconecta.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseModel
    {
        #region Properties
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(8000)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(36)]
        public string ProviderId { get; set; }
        public Provider Provider { get; set; }
        #endregion
    }
}
