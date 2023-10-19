using System.ComponentModel.DataAnnotations;
namespace ModelsSite
{
    public class Site
    {
        [Required][Key]
        public int Id { get; set; }
        public string Ville { get; set; }
        public string Statut { get; set; }
    }
}
