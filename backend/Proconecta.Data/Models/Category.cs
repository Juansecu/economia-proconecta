namespace Proconecta.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseModel
    {
        #region Properties
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(8000)]
        public string Description { get; set; }
        #endregion
    }
}
