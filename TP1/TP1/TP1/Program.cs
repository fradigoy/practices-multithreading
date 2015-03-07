using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Program
    {

        static void Main(string[] args)
        {
            #region init value
            int nombreEntree = 0;
            int nombreThread = 0;
            Console.WriteLine("Number entry ?");
            nombreEntree = int.Parse(Console.ReadLine());
            // Console.WriteLine("Number thread ?");
            // numberThread = int.Parse(Console.ReadLine());
            #endregion

            long startTime = DateTime.Now.Millisecond;
            Double[] monTab = new Double[nombreEntree];
            Function.Initialiser(monTab);
            Function.Trier(monTab);
            //   Function.Afficher(monTab);
            long endTime = DateTime.Now.Millisecond;

            long timeAction = endTime - startTime;
            Console.WriteLine("execution time for  " + nombreEntree + " entry = " + timeAction + " ms");

            Console.WriteLine("min");
            Console.WriteLine(monTab[0]);
            Console.WriteLine(monTab[monTab.Length - 1]);
            Console.WriteLine("max");
            Console.ReadLine();
        }
    }
    class Function
    {
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

        public static void Trier(double[] tableau)
        {
            TriRapideSequentiel(tableau, 0, tableau.Length - 1);
        }
        private static void TriRapideSequentiel(double[] tableau, int debut, int fin)
        {

            if (debut < fin)
            {

                int indicePivot = Segmenter(tableau, debut, fin);

                TriRapideSequentiel(tableau, debut, indicePivot - 1);

                TriRapideSequentiel(tableau, indicePivot + 1, fin);

            }

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
    }

}
