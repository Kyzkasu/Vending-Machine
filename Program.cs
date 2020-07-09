using System;

namespace LE_MINH_GUY___Vending_Machine_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Client unClient = new Client(10.30); // Instancie le client + Son argent dispo
            Machine uneMachine = new Machine(); // Instancie une machine
            uneMachine.AfficherItems(); // Voir les produits disponibles
            unClient.Achat(); // Le client achète
            unClient.AfficherMonnaie(); // Son argent disponible
          
        }
    }
}
