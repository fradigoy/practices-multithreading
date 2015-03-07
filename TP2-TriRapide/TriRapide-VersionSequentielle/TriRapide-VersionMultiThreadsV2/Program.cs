using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TriRapideVersionMultiThreadsV2
{
    class Program
    {
        public static void Main (string[] args)
		{
			int tailleTab = 1000000;
			Double[] t = new double[tailleTab];
			Initialiser (t);

			DateTime deb = DateTime.Now; 
			TriRapideSequentiel(t, 0, tailleTab-1);
			DateTime fin = DateTime.Now;

			Console.WriteLine (fin - deb+" ms");
			Afficher(t);
		}

		private static void TriRapideSequentiel(double[] tableau, int debut, int fin) 
        {
			if (debut < fin)
			{
				int indicePivot = Segmenter(tableau, debut, fin);
				Thread threadLeft = new Thread( () => TriRapideSequentiel(tableau, debut, indicePivot - 1) );
				threadLeft.Start ();
				threadLeft.Join ();

				Thread threadRigth = new Thread( () => TriRapideSequentiel(tableau, indicePivot + 1, fin) );
				threadRigth.Start();
				threadRigth.Join ();
			} 
		}

		private static int Segmenter(double[] tableau, int debut, int fin)
		{
			double valeurPivot = tableau[debut];
			int d = debut + 1;
			int f = fin;
			while (d < f) {
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

		public static void Afficher (double[] tableau)
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
