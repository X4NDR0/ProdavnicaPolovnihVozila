using ProdavnicaPolovnihVozila.Enums;
namespace ProdavnicaPolovnihVozila.Models
{
    public class Vozilo
    {
        public int ID;
        public string Naslov;
        public double Cena;
        public Kategorija Kategorija;
        public StanjeProdaje StanjeProdaje;
        public string Opis;
    }
}
