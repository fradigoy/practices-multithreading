using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriRapideV3
{
    class Program
    {
        public static void Main(string[] args)
        {
            int tailleTab = 1000000;
            int retourTriRapide = 0;
            Double[] t = new double[tailleTab];
            Initialiser(t);

            DateTime deb = DateTime.Now;
            retourTriRapide = TriRapideSequentiel(t, 0, tailleTab - 1);
            DateTime fin = DateTime.Now;

            Console.WriteLine(fin - deb + " ms");
            Console.WriteLine(retourTriRapide);
            Afficher(t);
        }

        private static int TriRapideSequentiel(double[] tableau, int debut, int fin)
        {
            int totResultsTask = 0;
            if (debut < fin)
            {
                int indicePivot = Segmenter(tableau, debut, fin);
                int leftReturn = 0;
                int rightReturn = 0;

                Task<int> leftTask = new Task<int>(() => TriRapideSequentiel(tableau, debut, indicePivot - 1));
                leftTask.Start();
                leftReturn = leftTask.Result;

                Task<int> rightTask = new Task<int>(() => TriRapideSequentiel(tableau, indicePivot + 1, fin));
                rightTask.Start();
                rightReturn = rightTask.Result;

                totResultsTask = leftReturn + rightReturn;
                //Le fait de retourner la somme des tâches oblige les pools à s'attendre
                // et reproduit l'effet d'un join sur un Thread classique. 
                // Le problème de synchronisation de la question 1 est donc résolu. 
            }
            return totResultsTask;
        }

        private static int Segmenter(double[] tableau, int debut, int fin)
        {
            double valeurPivot = tableau[debut];
            int d = debut + 1;
            int f = fin;
            while (d < f)
            {
                while (d < f && tableau[f] > valeurPivot)
                    f--;
                while (d < f && tableau[d] <= valeurPivot)
                    d++;
                double temp = tableau[d];
                tableau[d] = tableau[f];
                tableau[f] = temp;
            }
            if (tableau[d] > valeurPivot)
                d--;
            tableau[debut] = tableau[d];
            tableau[d] = valeurPivot;
            return d;
        }

        public static void Afficher(double[] tableau)
        {
            for (int i = 0; i < tableau.Length; i++)
                Console.WriteLine("T[{0}] = {1}", i, tableau[i]);
        }

        public static void Initialiser(double[] tableau)
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < tableau.Length; i++)
                tableau[i] = r.NextDouble();
        }
    }
}
