using System;
using System.Collections.Generic;
using System.Text;

namespace LE_MINH_GUY___Vending_Machine_Test
{
    
    class Client
    {
        private double argent;
        private double[] pieces = new double[] { 0.01, 0.02, 0.05, 0.10, 0.20, 0.50 };
        private double[] monnaie = new double[6];
        Machine uneMachine = new Machine();
        
        public Client (double argent) // Constructeur
        {
            this.argent = argent;
        }
        
        public void AfficherMonnaie() // Pouvoir voir sa monnaie 
        {
            for (int o = 0; o < monnaie.Length; o++)
            {
                Console.WriteLine("J'ai {0} pieces de {1} centimes\r\n", monnaie[o],pieces[o]);
            }

            Console.WriteLine("Total restant de mon argent : {0} euros", argent);
        }

        public void Achat() // Achats des produits.
        {
            Console.WriteLine();
            Console.WriteLine("Votre solde est de {0} euros", argent);

            int choix = 1;
            Items unItem = new Items();

            while (choix != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Choissiez un item : ");
                Console.WriteLine("1 : Kinder");
                Console.WriteLine("2 : Eau");
                Console.WriteLine("3 : Coca");
                Console.WriteLine("0 : Fin de l'achat");
                Console.WriteLine();
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix == 1)
                {
                    Console.WriteLine("Vous avez choisi Kinder ! Autre chose?");
                    unItem = Items.Kinder;
                    uneMachine.GetItem(unItem);
                }

                else if (choix == 2)
                {
                    Console.WriteLine("Vous avez choisi Eau ! Autre chose?");
                    unItem = Items.Eau;
                    uneMachine.GetItem(unItem);
                }

                else if (choix == 3)
                {
                    Console.WriteLine("Vous avez choisi Eau ! Autre chose?");
                    unItem = Items.Coca;
                    uneMachine.GetItem(unItem);
                }
                
            }

           double total = Math.Round(uneMachine.AfficherTotalPanier(),2);
           double resultat = 0;

            if (argent > total) // Vérifie si on peux payer.
            {
                resultat = Math.Round(argent - total,2);
                argent = Math.Round(argent - total,2);
                total = 0;

                while (resultat != 0.00) // On veux avoir la monnaie jusqu'a qu'il y'ai 0.00
                {
                    for (int j = uneMachine.Pieces.Length - 1; j > 0; j--)
                    {
                        while (resultat >= uneMachine.Pieces[j] && uneMachine.Montant[j] > 1) // Prends une pièce tant que le résultat est inférieur aux pieces de 0.50 à 0.01, vérifie si les pièces sont dispo dans la machine.
                        {
                            resultat = Math.Round(resultat - uneMachine.Pieces[j], 2);
                            monnaie[j] = monnaie[j] + 1;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("You can't buy");
            }

        }             
    }
}
