using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Salarie
{
    public class Salarie
    {

        
       [Key][Required]
       public int ID { get; set; }
       public string Nom { get; set; }
       public string Prenom { get; set; }
       public int Telephone_fixe { get; set; }
       public int Telephone_portable { get; set; }
       public string Email { get; set; }
        [ForeignKey("IDService")]
       public string IDservice { get; set; }
        [ForeignKey("IDSite")]
        public string IDsite { get; set; }
    }
}
