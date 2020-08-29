namespace Proconecta.Data
{
    using System.ComponentModel.DataAnnotations;

    public static class Roles
    {
        [Display(Name = "Provider")]
        public const string Provider = "Provider";

        [Display(Name = "Entrepreneur")]
        public const string Entrepreneur = "Entrepreneur";
    }
}
