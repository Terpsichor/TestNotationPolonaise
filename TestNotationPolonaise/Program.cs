using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Effectue le calcul d'une notation polonaise
        /// </summary>
        /// <param name="formule">la formule à calculer</param>
        /// <returns></returns>
        static float Polonaise(String formule)
        {
            // declarations
            string[] tab = formule.Split(' ');
            int taille = tab.Length;
            float val1, val2, result = 0;

            // Boucle sur le tableau de la formule
            for (int i = (taille - 1); i >= 0; i--)
            {
                try
                {
                    // Ne fait des opérations que si l'élément est un signe
                    if (tab[i] == "+" || tab[i] == "-" || tab[i] == "/" || tab[i] == "*" )
                    {
                        val1 = float.Parse(tab[i + 1]);
                        val2 = float.Parse(tab[i + 2]);

                        // addition
                        if (tab[i] == "+")
                        {
                            result = val1 + val2;
                        }

                        // soustraction
                        if (tab[i] == "-")
                        {
                            result = val1 - val2;
                        }

                        // division
                        if (tab[i] == "/")
                        {
                            result = val1 / val2;
                            // empêche la division par zero
                            if (val2 == 0)
                            {
                                return float.NaN;
                            }
                        }

                        // multiplication
                        if (tab[i] == "*")
                        {
                            result = val1 * val2;
                        }

                        // assignation du resultat à la place du signe
                        tab[i] = result.ToString();

                        // effacage des éléments utilisés
                        tab[i + 1] = " ";
                        tab[i + 2] = " ";

                        // décalage des éléments suivants de deux
                        for (int j = (i + 1); j < taille - 2; j++)
                        {
                            tab[j] = tab[j + 2];
                            tab[j + 2] = " ";
                        }
                    }
                }
                catch
                {
                    return float.NaN;   
                }
            }
            // check si les autres cases du tableaux sont vides
            for (int i = 1; i < taille; i++)
            {
                if (tab[i] != " ")
                {
                    return float.NaN;
                }
            }

            return float.Parse(tab[0]);
        }

        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
