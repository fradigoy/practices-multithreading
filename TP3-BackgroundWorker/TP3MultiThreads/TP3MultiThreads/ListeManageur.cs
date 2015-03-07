using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3MultiThreads
{
    class ListeManageur
    {


        public  int nombreDeRandom;
        private System.Windows.Forms.ListView listViewNonTrier;
        private System.Windows.Forms.ListView listViewTrier;
        private int[] tableauValeurs;
       
        public int progression;
        public bool Cancel;

        public ListeManageur(System.Windows.Forms.ListView listViewNonTrier, System.Windows.Forms.ListView listViewTrier)
        {
            // TODO: Complete member initialization
            this.listViewNonTrier = listViewNonTrier;
            this.listViewTrier = listViewTrier;
            this.nombreDeRandom=0;
            this.progression = 0;
            this.Cancel = false;
        }


        public void ValoriserListeNonTrier(int nombreEntree)
        {
            this.listViewNonTrier.Items.Clear();
            this.nombreDeRandom = nombreEntree;
            Random rand = new Random();
            this.tableauValeurs= new int [nombreDeRandom];
            for (int compteurNombre = 0; compteurNombre < nombreDeRandom; compteurNombre++)
            {
                this.tableauValeurs[compteurNombre] = rand.Next(nombreDeRandom);
            }

            this.ValoriserListe(this.listViewNonTrier, tableauValeurs);

           

        }




        public void AfficherProgressBar()
        {
            ProgressForm formProgressBar = new ProgressForm(this);
            formProgressBar.Show();
        }

        public void TrierListe(BackgroundWorker backgroundWorker)
        {
            
            int i, iRech, iMin;
            int N = this.tableauValeurs.Length - 1;
             this.progression = 0;
            int tmp;

            for (i = 0; i < N; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    this.Cancel = true;
                    break;
                }
                    for (iRech = iMin = i; iRech < N; iRech++)
                    if (this.tableauValeurs[iRech] < this.tableauValeurs[iMin])
                        iMin = iRech;

                if (iMin != i)
                {

                    tmp = this.tableauValeurs[iMin];

                    this.tableauValeurs[iMin] = this.tableauValeurs[i];

                    this.tableauValeurs[i] = tmp;

                }

                try
                {

                    double report = (i *100) / N;
                    double round = Math.Round(report);
                    this.progression = (int)round;
                }
                catch (Exception)
                {

                     this.progression  = 0;
                }
                backgroundWorker.ReportProgress(this.progression);



            }

           
        }

        public void ValoriserListeTrier()
        {
            this.ValoriserListe(this.listViewTrier, this.tableauValeurs);
        }

        public void ValoriserListe(ListView listView, int[] valeurs)
        {
            ListViewItem[] itemsCollection = new ListViewItem[valeurs.Length - 1];
            for (int compteurNombre = 0; compteurNombre < valeurs.Length - 1; compteurNombre++)
            {
                itemsCollection[compteurNombre] = new ListViewItem(valeurs[compteurNombre].ToString());
            }

            listView.Items.AddRange(itemsCollection);

        }

    }
}
