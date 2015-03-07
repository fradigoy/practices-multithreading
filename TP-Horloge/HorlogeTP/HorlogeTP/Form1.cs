using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorlogeTP
{
    public partial class Form1 : Form
    {
        public static int TIC_TAC_HORLOGE = 500;
        private TypeDate m_leFormatDate;
        private Thread m_timeUpdate;

        public Form1()
        {
            InitializeComponent();

        }

        #region Radio_CheckChanged
        private void RadioFull_CheckedChanged(object sender, EventArgs e)
        {
            this.m_leFormatDate = TypeDate.DateEtHeure;
            this.RefreshTimeUI();
        }

        private void radioDay_CheckedChanged(object sender, EventArgs e)
        {
            this.m_leFormatDate = TypeDate.Date;
            this.RefreshTimeUI();
        }

        private void radioTime_CheckedChanged(object sender, EventArgs e)
        {
            this.m_leFormatDate = TypeDate.Heure;
            this.RefreshTimeUI();
        }
        #endregion

        
        private void updateTime()
        {
            while (true)
            {
                this.RefreshTimeUI();
                System.Threading.Thread.Sleep(TIC_TAC_HORLOGE);
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            this.m_timeUpdate = new Thread(updateTime);
            this.m_timeUpdate.IsBackground = true;
            this.m_timeUpdate.Start();

        }

        private void RefreshTimeUI()
        {
            MethodInvoker invoker = delegate
            {
                this.LabelHorloge.Text = this.GenererDate();
            };

            this.Invoke(invoker);
        }

        private string GenererDate()
        {
            string date = null;
            switch (this.m_leFormatDate)
            {
                case TypeDate.Date:
                    date = DateTime.Now.ToShortDateString();
                    break;
                case TypeDate.DateEtHeure:
                    date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                    break;
                case TypeDate.Heure:
                    date = DateTime.Now.ToLongTimeString();
                    break;
            }
            return date;
        }

        private void Fermeture(object sender, FormClosingEventArgs e)
        {
            this.m_timeUpdate.Abort();
            Application.ExitThread();
        }
    }

    /// <summary>
    /// enumération des choix du radio group
    /// </summary>
    public enum TypeDate
    {
        Date,
        DateEtHeure,
        Heure
    }
    
}
