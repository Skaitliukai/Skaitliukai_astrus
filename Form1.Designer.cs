﻿namespace Skaitliukai_astrus
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mi_new = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_newGas = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_newElec = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_crop = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd_image = new System.Windows.Forms.OpenFileDialog();
            this.mi_size = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_save = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_saveOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_new,
            this.mi_crop});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mi_new
            // 
            this.mi_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_newGas,
            this.mi_newElec});
            this.mi_new.Name = "mi_new";
            this.mi_new.Size = new System.Drawing.Size(55, 20);
            this.mi_new.Text = "Naujas";
            // 
            // mi_newGas
            // 
            this.mi_newGas.Name = "mi_newGas";
            this.mi_newGas.Size = new System.Drawing.Size(172, 22);
            this.mi_newGas.Text = "Dujų skaitliukas";
            this.mi_newGas.Click += new System.EventHandler(this.mi_newGas_Click);
            // 
            // mi_newElec
            // 
            this.mi_newElec.Name = "mi_newElec";
            this.mi_newElec.Size = new System.Drawing.Size(172, 22);
            this.mi_newElec.Text = "Elektros skaitliukas";
            this.mi_newElec.Click += new System.EventHandler(this.mi_newElec_Click);
            // 
            // mi_crop
            // 
            this.mi_crop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_size,
            this.mi_save,
            this.mi_saveOriginal});
            this.mi_crop.Name = "mi_crop";
            this.mi_crop.Size = new System.Drawing.Size(61, 20);
            this.mi_crop.Text = "Apkirpti";
            // 
            // ofd_image
            // 
            this.ofd_image.Filter = "png (*.png)|*.png|jpg (*.jpg)|*.jpg";
            this.ofd_image.Title = "Pasirinkite skaitliuko nuotrauką";
            // 
            // mi_size
            // 
            this.mi_size.Name = "mi_size";
            this.mi_size.Size = new System.Drawing.Size(185, 22);
            this.mi_size.Text = "Pasirinkti dydį";
            this.mi_size.Click += new System.EventHandler(this.mi_size_Click);
            // 
            // mi_save
            // 
            this.mi_save.Name = "mi_save";
            this.mi_save.Size = new System.Drawing.Size(185, 22);
            this.mi_save.Text = "Išsaugoti pasirinkimą";
            this.mi_save.Click += new System.EventHandler(this.mi_save_Click);
            // 
            // mi_saveOriginal
            // 
            this.mi_saveOriginal.Name = "mi_saveOriginal";
            this.mi_saveOriginal.Size = new System.Drawing.Size(185, 22);
            this.mi_saveOriginal.Text = "Dirbti su originalu";
            this.mi_saveOriginal.Click += new System.EventHandler(this.mi_saveOriginal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Skaitliukai";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_new;
        private System.Windows.Forms.ToolStripMenuItem mi_newGas;
        private System.Windows.Forms.ToolStripMenuItem mi_newElec;
        private System.Windows.Forms.ToolStripMenuItem mi_crop;
        private System.Windows.Forms.OpenFileDialog ofd_image;
        private System.Windows.Forms.ToolStripMenuItem mi_size;
        private System.Windows.Forms.ToolStripMenuItem mi_save;
        private System.Windows.Forms.ToolStripMenuItem mi_saveOriginal;
    }
}

