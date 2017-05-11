using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ElektraDLL;

namespace Skaitliukai_astrus
{
    public partial class Form1 : Form
    {
        private Skaitliukas skaitliukas = null;
        private Rectangle selection;
        private bool down;
        private OpenFileDialog filedialog = new OpenFileDialog();
        private Bitmap imageBitmap;
        private Color selectionColour = Color.Black;
        private int borderSize = 2;

        public Form1()
        {
            this.selectionColour = Color.Black;
            this.borderSize = 2;
            InitializeComponent();
            Utility.checkForFolders();
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
                this.imageBitmap = new Bitmap(ofd_image.FileName);
                this.BackgroundImage = this.imageBitmap;
                this.BackgroundImageLayout = ImageLayout.None;
                base.Invalidate();
            }
        }

        public Color ChangeAlpha(Color Colour, int Value) =>
            Color.FromArgb(Value, Colour);
        public Bitmap CropImage(Bitmap Image) =>
            Image.Clone(this.selection, Image.PixelFormat);

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(this.ChangeAlpha(this.selectionColour, 100)), this.selection);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(this.selectionColour), (float)this.borderSize), this.selection);
            e.Graphics.DrawString((selection.Width + ("x" + selection.Height)), new Font("Arial", 10, FontStyle.Regular), Brushes.White, selection.X, selection.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.selection = new Rectangle(new Point(0, 0), new Size(100, 100));
            base.Invalidate();
        }

        private void mi_size_Click(object sender, EventArgs e)
        {
            this.selection = new Rectangle(new Point(this.selection.X, this.selection.Y), new Size(Conversions.ToInteger(Interaction.InputBox("Width", "", Conversions.ToString(this.selection.Width), -1, -1)), Conversions.ToInteger(Interaction.InputBox("Height", "", Conversions.ToString(this.selection.Height), -1, -1))));
            base.Invalidate();
        }

        private void mi_save_Click(object sender, EventArgs e)
        {
            if (skaitliukas == null || skaitliukas.FullImagePath == null)
                return;

            if (skaitliukas.TypeId == 0)
                Utility.Negate(this.imageBitmap);
            this.CropImage(this.imageBitmap).Save(skaitliukas.CroppedImagePath, ImageFormat.Png);
            finishProccessing();
        }

        private void mi_saveOriginal_Click(object sender, EventArgs e)
        {
            if (skaitliukas == null || skaitliukas.FullImagePath == null)
                return;

            if (skaitliukas.TypeId == 0)
                Utility.Negate(this.imageBitmap);
            this.imageBitmap.Save(skaitliukas.CroppedImagePath, ImageFormat.Png);
            finishProccessing();          
        }

        private void finishProccessing()
        {
            Utility.saveTempImage(skaitliukas.CroppedImagePath);
            if (skaitliukas.TypeId == 0)
                skaitliukas.Number = DujosDLL.Rodmenys.getRodmenis();
            else
                skaitliukas.Number = ElektraDLL.Rodmenys.getRodmenis();
            Utility.deleteTempImage();
            Console.WriteLine(skaitliukas.Number);

            DataLayer.insertRecord(skaitliukas);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.down = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.down = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.down)
            {
                this.selection = new Rectangle(e.Location, this.selection.Size);
                base.Invalidate();
            }
        }
    }
}
