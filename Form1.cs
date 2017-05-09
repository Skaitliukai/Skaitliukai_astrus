using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skaitliukai_astrus
{
    public partial class Form1 : Form
    {
        private Skaitliukas skaitliukas;

        public Form1()
        {
            InitializeComponent();
            Utility.checkForFolders();
        }

        private void mi_crop_Click(object sender, EventArgs e)
        {
            //Manviaus kodas

            var image = new Bitmap(skaitliukas.FullImagePath, true);
            if (skaitliukas.TypeId == 0)
                Utility.Negate(image);
            image.Save(skaitliukas.CroppedImagePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void mi_newGas_Click(object sender, EventArgs e)
        {
            createNew(0);
        }

        private void mi_newElec_Click(object sender, EventArgs e)
        {
            createNew(1);
        }

        private void createNew(int type)
        {
            if (ofd_image.ShowDialog() == DialogResult.OK)
            {
                string path = ofd_image.FileName;
                skaitliukas = new Skaitliukas(path, type);
            }
        }
    }
}
