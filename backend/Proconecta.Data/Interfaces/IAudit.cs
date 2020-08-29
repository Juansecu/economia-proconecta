namespace Proconecta.Data.Interfaces
{
    using System;

    public interface IAduit
    {
        public int Version { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
