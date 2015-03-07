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

namespace V2HorlogeTP
{
    public partial class Form1 : Form
    {

            private TypeDate m_leFormatDate = TypeDate.DateEtHeure;

            private Thread timeUpdate;

            public Form1()
            {
                InitializeComponent();
            }

            private void timerRefreshTime_Tick(object sender, EventArgs e)
            {
                UpdateTimeUi();

            }


            private void RadioFull_CheckedChanged(object sender, EventArgs e)
            {
                this.m_leFormatDate = TypeDate.DateEtHeure;
                this.ForceRefreshTime();
            }

            private void InvokeUpdateTimeUi()
            {
                MethodInvoker invoke = delegate
                {
                    this.UpdateTimeUi();
                };
                this.Invoke(invoke);
            }

            private void ForceRefreshTime()
            {

                this.timeUpdate = new Thread(InvokeUpdateTimeUi);
                this.timeUpdate.Start();
            }

            private void radioDay_CheckedChanged(object sender, EventArgs e)
            {
                this.m_leFormatDate = TypeDate.Date;
                this.ForceRefreshTime();
            }

            private void radioTime_CheckedChanged(object sender, EventArgs e)
            {
                this.m_leFormatDate = TypeDate.Heure;
                this.ForceRefreshTime();
            }

            private void Fermeture(object sender, FormClosingEventArgs e)
            {
                this.timeUpdate.Abort();
                Application.ExitThread();
            }


            private void UpdateTimeUi()
            {
                this.LblHorloge.Text = this.GenererDate();
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

        }


        public enum TypeDate
        {
            Date,
            DateEtHeure,
            Heure
        }

}
