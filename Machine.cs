using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace LE_MINH_GUY___Vending_Machine_Test
{
  
   
    class Machine
    {
        private double[] pieces = new double[] {0.01, 0.02, 0.05, 0.10, 0.20, 0.50};
        private int[] montant = new int[6];
        private double total;
        private double totalPanier;
        private double prixItem1;
        private double prixItem2;
        private double prixItem3;

        public double[] Pieces { get => pieces;  }
        public int[] Montant { get => montant;  }

        public Machine() // Constructeur
        {
            var rand = new Random();
            totalPanier = 0;
            for (int i = 0; i <= 5; i++)
            {
                Montant[i] = rand.Next(0, 101);
                this.total += Montant[i] * Pieces[i] + total;
            }    
        }
        
        public double GetItem(Items item) // Obtenir les prix variant + ajout panier 
        {
            var rand = new Random();
            switch (item)
            {
                case Items.Kinder:
                    prixItem1 = rand.NextDouble() * (5-1);
                    return totalPanier += prixItem1;
                case Items.Eau:
                    prixItem2 = rand.NextDouble() * (5 - 1);
                    return totalPanier += prixItem2;
                case Items.Coca:
                    prixItem3 = rand.NextDouble() * (5 - 1);
                    return totalPanier += prixItem3;
            }
            return AfficherTotalPanier();   
        }

        public void AfficherItems() // Afficher les produits dans l'enum    
        {
            int i = 0;
            Console.WriteLine(" |Voici les items disponible |");
            foreach(Items item in (Items[]) Enum.GetValues(typeof(Items)))
            {
                i++;
                Console.WriteLine("     |{0}: {1} |", i, item);
            }
        }

        public double AfficherTotal() // Afficher le montant total de la machine
        {
            Console.WriteLine(String.Format("Le total d'argent dans la machine est de {0:0.##} euros", total));
            return total;
        }

        public double AfficherTotalPanier() // Voir le total du panier
        {
            
            Console.WriteLine(String.Format("\r\nVotre panier est de : {0:0.##} euros", totalPanier));
            Console.WriteLine(String.Format("\r\nLe prix du kinder est de {0:0.##} euros", prixItem1));
            Console.WriteLine(String.Format("\r\nLe prix de l'eau est de {0:0.##} euros", prixItem2));
            Console.WriteLine(String.Format("\r\nLe prix de du coca est de {0:0.##} euros\r\n", prixItem3)); 
            
            return totalPanier;
        }
        public void TotalPieces() // Voir le nombre de pièces dispo dans la machine
        {
            for(int i = 0; i < Pieces.Length; i++)
            {
                Console.WriteLine("Il y a {0} pièces de {1}", Montant[i], Pieces[i]);
            }
        }

    }
}
