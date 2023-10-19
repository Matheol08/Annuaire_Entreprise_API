using System.ComponentModel.DataAnnotations;

namespace Models.Service
{
    public class Service
    {
        [Required][Key]
        public int Id { get; set; }
        public string Nom_Service { get; set; }
    }
}
