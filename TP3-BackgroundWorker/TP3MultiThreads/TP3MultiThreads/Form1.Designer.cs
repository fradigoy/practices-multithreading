namespace TP3MultiThreads
{
    partial class TP3
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstViewNonTrier = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstViewTrier = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtbxNombre = new System.Windows.Forms.TextBox();
            this.btnTrier = new System.Windows.Forms.Button();
            this.btnValoriser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstViewNonTrier
            // 
            this.lstViewNonTrier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstViewNonTrier.Location = new System.Drawing.Point(78, 65);
            this.lstViewNonTrier.Name = "lstViewNonTrier";
            this.lstViewNonTrier.Size = new System.Drawing.Size(272, 417);
            this.lstViewNonTrier.TabIndex = 5;
            this.lstViewNonTrier.UseCompatibleStateImageBehavior = false;
            this.lstViewNonTrier.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre non trié";
            this.columnHeader1.Width = 132;
            // 
            // lstViewTrier
            // 
            this.lstViewTrier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lstViewTrier.Location = new System.Drawing.Point(704, 65);
            this.lstViewTrier.Name = "lstViewTrier";
            this.lstViewTrier.Size = new System.Drawing.Size(272, 417);
            this.lstViewTrier.TabIndex = 6;
            this.lstViewTrier.UseCompatibleStateImageBehavior = false;
            this.lstViewTrier.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre triés";
            this.columnHeader2.Width = 163;
            // 
            // txtbxNombre
            // 
            this.txtbxNombre.Location = new System.Drawing.Point(473, 39);
            this.txtbxNombre.Name = "txtbxNombre";
            this.txtbxNombre.Size = new System.Drawing.Size(100, 20);
            this.txtbxNombre.TabIndex = 9;
            this.txtbxNombre.Text = "1000";
            // 
            // btnTrier
            // 
            this.btnTrier.Location = new System.Drawing.Point(485, 115);
            this.btnTrier.Name = "btnTrier";
            this.btnTrier.Size = new System.Drawing.Size(75, 23);
            this.btnTrier.TabIndex = 8;
            this.btnTrier.Text = "Trier";
            this.btnTrier.UseVisualStyleBackColor = true;
            // 
            // btnValoriser
            // 
            this.btnValoriser.Location = new System.Drawing.Point(485, 65);
            this.btnValoriser.Name = "btnValoriser";
            this.btnValoriser.Size = new System.Drawing.Size(75, 23);
            this.btnValoriser.TabIndex = 7;
            this.btnValoriser.Text = "Valoriser";
            this.btnValoriser.UseVisualStyleBackColor = true;
            // 
            // TP3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 520);
            this.Controls.Add(this.lstViewNonTrier);
            this.Controls.Add(this.lstViewTrier);
            this.Controls.Add(this.txtbxNombre);
            this.Controls.Add(this.btnTrier);
            this.Controls.Add(this.btnValoriser);
            this.Name = "TP3";
            this.Text = "TP3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstViewNonTrier;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstViewTrier;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtbxNombre;
        private System.Windows.Forms.Button btnTrier;
        private System.Windows.Forms.Button btnValoriser;

    }
}

