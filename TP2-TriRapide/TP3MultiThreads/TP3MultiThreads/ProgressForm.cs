using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3MultiThreads
{
    public partial class ProgressForm : Form
    {
        private ListeManageur listeManageur;

        public ProgressForm()
        {
            InitializeComponent();
        }

        public ProgressForm(ListeManageur listeManageur)
        {
            // TODO: Complete member initialization
            this.listeManageur = listeManageur;
        }
    }
}
