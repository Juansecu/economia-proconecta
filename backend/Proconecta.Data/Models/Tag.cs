namespace Proconecta.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag : BaseModel
    {
        #region Properties
        [Required]
        [StringLength(120)]
        public string Title { get; set; }
        #endregion
    }
}
