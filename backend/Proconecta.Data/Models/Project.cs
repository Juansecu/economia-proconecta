namespace Proconecta.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Project : BaseModel
    {
        #region Properties
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(8000)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Tags { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(255)]
        public string State { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(36)]
        public string UserId { get; set; }
        public User User { get; set; }
        #endregion
    }
}
