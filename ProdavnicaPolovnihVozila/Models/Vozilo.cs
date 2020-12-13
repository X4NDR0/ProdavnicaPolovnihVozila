namespace ProdavnicaPolovnihVozila.Models
{
    public class Vozilo
    {
        public int ID;
        public string Naslov;
        public double Cena;
        public Kategorija Kategorija;
        //Stanje prodaje enum
        public string Opis;
    }
}
