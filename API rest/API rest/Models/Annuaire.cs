namespace API_rest.Models
{
    public class Annuaire
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Site { get; set; }
        public string Telephone_Fixe { get; set; }
        public string Telephone_Portable { get; set; }

        public string Email { get; set; }
        public string Service { get; set; }

    }
}