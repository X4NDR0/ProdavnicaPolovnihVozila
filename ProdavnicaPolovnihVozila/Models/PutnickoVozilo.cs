using System.Collections.Generic;

namespace ProdavnicaPolovnihVozila.Models
{
    public class PutnickoVozilo:Vozilo
    {
        public Motor Motor;
        public string Marka;
        public string Model;
        public int BrojVrata;
        public List<string> ListaOpreme = new List<string>();
    }
}
