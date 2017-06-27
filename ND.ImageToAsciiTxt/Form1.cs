using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ND.ImageToAsciiTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 打开图片
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true; 
            fileDialog.Title = "请选择图片";
            fileDialog.Filter = "所有图片(*.*)|*.gif;*.png;*.jpg;*.jpeg;;*.ico;*.GIF;*.PNG;*.JPG;*.JPEG;;*.ICO;";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file=fileDialog.FileName;
                Image image=Image.FromFile(file);
                this.pictureBox1.Image = image;
                ImageController controller = new ImageController(new ImageOptions(){ImageInstance = image,ImageFilePath = file});
                controller.ProcessImage(new Action<Image>((image2) =>
                {
                    this.pictureBox1.Image = image2;

                }), new Action<string>((str) =>
                {
                    this.label1.Text = str;

                }));

            } 
        
        } 
        #endregion
    }
}
