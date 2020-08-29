namespace Proconecta.Data.Models
{
    using System;
    using System.Collections.Generic;
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

        public List<Project> Projects { get; set; }
        public List<Provider> Providers { get; set; }
        #endregion
    }
}
