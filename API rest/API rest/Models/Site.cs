using API_rest.Contexts;
using System.ComponentModel.DataAnnotations;

namespace ModelsSite
{
    public class Site
    {
        [Required][Key]
        public int ID { get; set; }
        public string Ville { get; set; }
        public string Statut_Site { get; set; }
    }
}
