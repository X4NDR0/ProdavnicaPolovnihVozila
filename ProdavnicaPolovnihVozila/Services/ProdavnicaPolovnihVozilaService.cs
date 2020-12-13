using System;
using System.Collections.Generic;
using ProdavnicaPolovnihVozila.Models;

namespace ProdavnicaPolovnihVozila.Services
{
    public class ProdavnicaPolovnihVozilaService
    {
        private List<Korisnik> ListaKorisnika = new List<Korisnik>();

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

        public void Menu()
        {
            Console.WriteLine("Menu method after login");
        }

        public void LoadData()
        {
            Korisnik korisnik1 = new Korisnik { Ime = "Aleksandar", Prezime = "Ilijevski",Username = "1",Password = "1"};
            Korisnik korisnik2 = new Korisnik { Ime = "Milos", Prezime = "Ristic",Username = "2",Password = "2"};

            ListaKorisnika.Add(korisnik1);
            ListaKorisnika.Add(korisnik2);
        }
    }
}
