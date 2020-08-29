namespace Proconecta.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Proconecta.Data.Interfaces;

    public abstract class BaseModel : IIsDeleted
    {
        #region Properties
        [Required]
        [StringLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
        #endregion

        #region Constructors
        public BaseModel() { }
        #endregion
    }
}
