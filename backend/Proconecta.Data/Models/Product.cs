namespace Proconecta.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseModel
    {
        #region Properties
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(8000)]
        public string Description { get; set; }

        public double? Price { get; set; }
        #endregion
    }
}
