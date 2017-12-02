using System.Windows.Forms;

namespace Casuta.UserControl
{
    partial class Casuta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PictureBox ImaginePion
        {
            get { return imaginePion; }
            set { imaginePion = value; }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imaginePion = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imaginePion)).BeginInit();
            this.SuspendLayout();
            // 
            // imaginePion
            // 
            this.imaginePion.BackColor = System.Drawing.Color.Transparent;
            this.imaginePion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imaginePion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imaginePion.Location = new System.Drawing.Point(0, 0);
            this.imaginePion.Name = "imaginePion";
            this.imaginePion.Size = new System.Drawing.Size(150, 150);
            this.imaginePion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imaginePion.TabIndex = 0;
            this.imaginePion.TabStop = false;
            this.imaginePion.Click += new System.EventHandler(this.imaginePion_Click);
            this.imaginePion.MouseEnter += new System.EventHandler(this.imaginePion_MouseEnter);
            this.imaginePion.MouseLeave += new System.EventHandler(this.imaginePion_MouseLeave);
            // 
            // Casuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.imaginePion);
            this.Name = "Casuta";
            ((System.ComponentModel.ISupportInitialize)(this.imaginePion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imaginePion;
    }
}
