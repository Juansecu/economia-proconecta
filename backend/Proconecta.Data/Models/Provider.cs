namespace Proconecta.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Provider : BaseModel
    {
        #region Properties
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(8000)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(255)]
        public string State { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        #endregion
    }
}
