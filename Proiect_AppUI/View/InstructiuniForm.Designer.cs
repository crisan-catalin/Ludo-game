using System.ComponentModel;

namespace Proiect_AppUI.View
{
    partial class InstructiuniForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructiuniForm));
            this.scopTitluLbl = new System.Windows.Forms.Label();
            this.scopTextLbl = new System.Windows.Forms.Label();
            this.reguliTitluLbl = new System.Windows.Forms.Label();
            this.reguliTextLbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // scopTitluLbl
            // 
            this.scopTitluLbl.AutoSize = true;
            this.scopTitluLbl.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scopTitluLbl.Location = new System.Drawing.Point(23, 25);
            this.scopTitluLbl.Name = "scopTitluLbl";
            this.scopTitluLbl.Size = new System.Drawing.Size(187, 30);
            this.scopTitluLbl.TabIndex = 0;
            this.scopTitluLbl.Text = "Scopul jocului:";
            // 
            // scopTextLbl
            // 
            this.scopTextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scopTextLbl.Location = new System.Drawing.Point(25, 75);
            this.scopTextLbl.Name = "scopTextLbl";
            this.scopTextLbl.Size = new System.Drawing.Size(638, 78);
            this.scopTextLbl.TabIndex = 1;
            this.scopTextLbl.Text = "Scopul jocului este de a înconjura planşa de joc cu cei patru pioni în direcţia a" +
    "rătată de săgeată pentru a ajunge cu toţi pionii în cerculeţele finale.";
            // 
            // reguliTitluLbl
            // 
            this.reguliTitluLbl.AutoSize = true;
            this.reguliTitluLbl.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reguliTitluLbl.Location = new System.Drawing.Point(23, 153);
            this.reguliTitluLbl.Name = "reguliTitluLbl";
            this.reguliTitluLbl.Size = new System.Drawing.Size(94, 30);
            this.reguliTitluLbl.TabIndex = 2;
            this.reguliTitluLbl.Text = "Reguli:";
            // 
            // reguliTextLbl1
            // 
            this.reguliTextLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.reguliTextLbl1.Location = new System.Drawing.Point(25, 199);
            this.reguliTextLbl1.Name = "reguliTextLbl1";
            this.reguliTextLbl1.Size = new System.Drawing.Size(552, 24);
            this.reguliTextLbl1.TabIndex = 3;
            this.reguliTextLbl1.Text = "– fiecare jucător aruncă pe rând cu zarul o singură dată";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(25, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "– pentru a părăsii casa trebuie să aruncați un zar cu valoarea de 6 puncte";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(25, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(638, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "– în timpul jocului, când nimeriţi cu zarul 6 puncte, aveţi dreptul la încă o aru" +
    "ncare";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(25, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(638, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "– dacă aveți un pion pe căsuța de start sau pe oricare altă căsuță în care urmeaz" +
    "ă să mutați, mutarea este invalidă";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(25, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(638, 40);
            this.label4.TabIndex = 7;
            this.label4.Text = "– când aţi ajuns pe o căsuță ocupată de alt jucător pionul acestuia va fi scos şi" +
    " readus în casă de unde nu va putea fi repus în joc decât printr-o aruncare cu z" +
    "arul de 6 puncte";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(25, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(638, 77);
            this.label5.TabIndex = 8;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(25, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(638, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "🎉 Cine reuşeşte să ajungă primul, cu toţi cei 4 pioni, căsuțele finale este câşt" +
    "igător. 🎉";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox.Image = global::Proiect_AppUI.Properties.Resources.pawn_green;
            this.pictureBox.Location = new System.Drawing.Point(607, 195);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(69, 63);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 10;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Proiect_AppUI.Properties.Resources.pawn_blue;
            this.pictureBox1.Location = new System.Drawing.Point(515, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::Proiect_AppUI.Properties.Resources.pawn_yellow;
            this.pictureBox2.Location = new System.Drawing.Point(611, 111);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = global::Proiect_AppUI.Properties.Resources.pawn_red;
            this.pictureBox3.Location = new System.Drawing.Point(552, 143);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 63);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // InstructiuniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 467);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reguliTextLbl1);
            this.Controls.Add(this.reguliTitluLbl);
            this.Controls.Add(this.scopTextLbl);
            this.Controls.Add(this.scopTitluLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InstructiuniForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instructiuni joc";
            this.TopMost = true;
            this.Closing += new CancelEventHandler(InstructiuniForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scopTitluLbl;
        private System.Windows.Forms.Label scopTextLbl;
        private System.Windows.Forms.Label reguliTitluLbl;
        private System.Windows.Forms.Label reguliTextLbl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}