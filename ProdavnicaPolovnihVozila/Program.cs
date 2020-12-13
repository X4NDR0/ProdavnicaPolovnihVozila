using ProdavnicaPolovnihVozila.Services;

namespace ProdavnicaPolovnihVozila
{
    class Program
    {
        static void Main(string[] args)
        {
            ProdavnicaPolovnihVozilaService ppvs = new ProdavnicaPolovnihVozilaService();
            ppvs.Login();
        }
    }
}
