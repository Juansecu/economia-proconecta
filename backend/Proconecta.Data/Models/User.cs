namespace Proconecta.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User : BaseModel
    {
        #region Properties
        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(128)]
        public string Salt { get; set; }

        [StringLength(128)]
        public string PwdHashed { get; set; }

        [StringLength(15)]
        public string Type { get; set; }
        #endregion
    }
}
