using System;
using System.Collections.Generic;
using ProdavnicaPolovnihVozila.Models;
using ProdavnicaPolovnihVozila.Enums;
using System.Linq;

namespace ProdavnicaPolovnihVozila.Services
{
    public class ProdavnicaPolovnihVozilaService
    {
        private List<Korisnik> ListaKorisnika = new List<Korisnik>();
        private List<Kategorija> ListaKategorija = new List<Kategorija>();
        private List<Vozilo> ListaVozila = new List<Vozilo>();

        public void Login()
        {
            LoadData();

            Console.WriteLine("Dobrodosli,molimo vas da popunite polja za nastavak");

            Console.Write("Unesite korisnicko ime:");
            string username = Console.ReadLine();

            Console.Write("Unesite vasu lozinku:");
            string lozinka = Console.ReadLine();

            foreach (Korisnik korisnik in ListaKorisnika)
            {
                if (korisnik.Username.ToLower().Equals(username.ToLower()) && korisnik.Password.Equals(lozinka))
                {
                    Console.Clear();
                    Console.WriteLine("Uspesna prijava!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }
            }
        }

        public void TextMenu()
        {
            Console.WriteLine("1.Unos entitija");
            Console.WriteLine("2.Brisanje entitija");
            Console.Write("Opcija:");
        }

        public void Menu()
        {
            Options opcije;
            do
            {
                TextMenu();
                Enum.TryParse(Console.ReadLine(), out opcije);

                switch (opcije)
                {
                    case Options.UnosEntitija:

                        break;

                    case Options.BrisanjeEntitija:

                        break;

                    case Options.Exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opcija koju ste izabrali ne postoji!");
                        break;
                }
            } while (opcije != 0);
        }

        public void AddEntity()
        {
            Console.WriteLine("1.Dodaj putnicko vozilo");
            Console.WriteLine("2.Dodaj motocikl");
            Console.WriteLine("3.Dodaj bicikl");
            Console.WriteLine("4.Dodaj kategoriju");
            Console.Write("Opcija:");

            int.TryParse(Console.ReadLine(), out int opcija);

            switch (opcija)
            {
                case 1:
                    DodajPutnickoVozilo();
                    break;

                case 2:
                    DodajMotocikl();
                    break;

                case 3:
                    DodajBicikl();
                    break;

                case 4:
                    DodajKategoriju();
                    break;

                default:
                    Console.WriteLine("Izabrana opcija ne postoji!");
                    break;
            }
        }

        public void DodajPutnickoVozilo()
        {
            FuelType fuelType;

            Console.Write("Unesite id oglasa:");
            int.TryParse(Console.ReadLine(), out int idOglasa);

            Console.Write("Unesite naslov oglasa:");
            string naslovOglasa = Console.ReadLine();

            Console.Write("Unesite cenu vozila:");
            double.TryParse(Console.ReadLine(), out double cenaVozila);

            Console.Write("Unesite id kategorije:");
            int.TryParse(Console.ReadLine(), out int idKategorije);

            Console.Write("Unesite opis vozila:");
            string opisVozila = Console.ReadLine();

            Console.Write("Unesite marku vozila:");
            string markaVozila = Console.ReadLine();

            Console.Write("Unesite model vozila:");
            string modelVozila = Console.ReadLine();

            Console.Write("Unesite broj vrata od vozila:");
            int.TryParse(Console.ReadLine(), out int brojVrata);

            Console.Write("Unesite kubikazu motora:");
            int.TryParse(Console.ReadLine(), out int kubikazaMotora);

            Console.Write("Unesite snagu motora:");
            int.TryParse(Console.ReadLine(), out int snagaMotora);

            Console.Write("Unesite tip goriva(Dizel,Benzin,Gas):");
            Enum.TryParse(Console.ReadLine(), out fuelType);

            string unosOpreme = string.Empty;

            Console.WriteLine("Sada unesite opremu vozila,a kada zavrsite upisite 0");
            do
            {
                Console.Write("Unos:");
                unosOpreme = Console.ReadLine() + ",";

            } while (unosOpreme != "0");

            unosOpreme = unosOpreme.Remove(unosOpreme.Length - 1);

            List<string> listaOpreme = new List<string>();
            listaOpreme.Add(unosOpreme);

            Kategorija kategorijaAdd = ListaKategorija.Where(x => x.ID == idKategorije).FirstOrDefault();

            if (kategorijaAdd == null)
            {
                Console.WriteLine("Izabrana kategorija ne postoji!");
                return;
            }

            PutnickoVozilo putnickoVoziloAdd = new PutnickoVozilo
            {
                ID = idOglasa,
                Naslov = naslovOglasa,
                Cena = cenaVozila,
                Kategorija = kategorijaAdd,
                Opis = opisVozila,
                Marka = markaVozila,
                BrojVrata = brojVrata,
                Model = modelVozila,
                Motor = new Motor
                {
                    Snaga = snagaMotora,
                    Kubikaza = kubikazaMotora,
                    FuelType = fuelType

                },
                StanjeProdaje = StanjeProdaje.NijeProdato,
                ListaOpreme = listaOpreme
            };

            ListaVozila.Add(putnickoVoziloAdd);
        }

        public void DodajMotocikl()
        {
            FuelType fuelType;

            Console.Write("Unesite id oglasa:");
            int.TryParse(Console.ReadLine(), out int idOglasa);

            Console.Write("Unesite naslov oglasa:");
            string naslovOglasa = Console.ReadLine();

            Console.Write("Unesite cenu vozila:");
            double.TryParse(Console.ReadLine(), out double cenaVozila);

            Console.Write("Unesite id kategorije:");
            int.TryParse(Console.ReadLine(), out int idKategorije);

            Console.Write("Unesite opis vozila:");
            string opisVozila = Console.ReadLine();

            Console.Write("Unesite kubikazu motora:");
            int.TryParse(Console.ReadLine(), out int kubikazaMotora);

            Console.Write("Unesite snagu motora:");
            int.TryParse(Console.ReadLine(), out int snagaMotora);

            Console.Write("Unesite tip goriva(Dizel,Benzin,Gas)L");
            Enum.TryParse(Console.ReadLine(), out fuelType);

            Kategorija kategorija = ListaKategorija.Where(x => x.ID == idKategorije).FirstOrDefault();

            if (kategorija == null)
            {
                Console.WriteLine("Izabrana kategorija ne postoji.");
                return;
            }


            Motocikl motociklAdd = new Motocikl
            {
                ID = idOglasa,
                Naslov = naslovOglasa,
                Cena = cenaVozila,
                Kategorija = kategorija,
                Opis = opisVozila,
                Motor = new Motor
                {
                    Kubikaza = kubikazaMotora,
                    Snaga = snagaMotora,
                    FuelType = fuelType,
                },
                StanjeProdaje = StanjeProdaje.NijeProdato,
            };

            ListaVozila.Add(motociklAdd);
        }

        public void DodajBicikl()
        {
            Console.Write("Unesite id oglasa:");
            int.TryParse(Console.ReadLine(), out int idOglasa);

            Console.Write("Unesite naslov oglasa:");
            string naslovOglasa = Console.ReadLine();

            Console.Write("Unesite cenu vozila:");
            double.TryParse(Console.ReadLine(), out double cenaVozila);

            Console.Write("Unesite id kategorije:");
            int.TryParse(Console.ReadLine(), out int idKategorije);

            Console.Write("Unesite opis vozila:");
            string opisVozila = Console.ReadLine();

            Console.Write("Unesite broj brzina:");
            int.TryParse(Console.ReadLine(), out int brojBrzina);

            Kategorija kategorija = ListaKategorija.Where(x => x.ID == idKategorije).FirstOrDefault();

            if (kategorija == null)
            {
                Console.WriteLine("Kategorija koju ste izabrali ne postoji!");
                return;
            }

            Bicikl biciklAdd = new Bicikl
            {
                ID = idOglasa,
                Naslov = naslovOglasa,
                Cena = cenaVozila,
                Kategorija = kategorija,
                Opis = opisVozila,
                BrojBrzina = brojBrzina,
                StanjeProdaje = StanjeProdaje.NijeProdato,
            };

            ListaVozila.Add(biciklAdd);
        }

        public void DodajKategoriju()
        {
            Console.Write("Unesite ID:");
            int.TryParse(Console.ReadLine(), out int idKategorije);

            Console.Write("Unesite naziv:");
            string nazivKategorije = Console.ReadLine();

            Console.Write("Unesite opis:");
            string opisKategorije = Console.ReadLine();

            Kategorija kategorijaAdd = new Kategorija
            {
                ID = idKategorije,
                Naziv = nazivKategorije,
                Opis = opisKategorije,
            };

            ListaKategorija.Add(kategorijaAdd);
        }

        public void LoadData()
        {
            Korisnik korisnik1 = new Korisnik { Ime = "Aleksandar", Prezime = "Ilijevski", Username = "1", Password = "1" };
            Korisnik korisnik2 = new Korisnik { Ime = "Milos", Prezime = "Ristic", Username = "2", Password = "2" };

            ListaKorisnika.Add(korisnik1);
            ListaKorisnika.Add(korisnik2);
        }
    }
}
