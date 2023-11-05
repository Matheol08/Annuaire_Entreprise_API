using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace ModelsSalarie
{
    public class Salaries
    {

        
       [Key][Required]
       public int ID { get; set; }
       public string Nom { get; set; }
       public string Prenom { get; set; }
       public int Telephone_fixe { get; set; }
       public int Telephone_portable { get; set; }
       public string Email { get; set; }
        [ForeignKey("Service")]
       public string IDservice { get; set; }
        [ForeignKey("Site")]
        public string IDsite { get; set; }
    }
}
