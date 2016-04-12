using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversorPNGparaICO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "png files (*.png)|*.png"; //define o tipo de arquivo q pode ser selecionado
            openFileDialog1.FilterIndex = 1; //define qual das opções é padrão
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string x = openFileDialog1.FileName; //path inteiro do png
                    string x2 = openFileDialog1.SafeFileName; //nome e extensão do arquivo
                    x2 = x2.Remove(x2.Length - 4);
                    string y = folderBrowserDialog1.SelectedPath; //path do diretório de saída
                    using (System.IO.FileStream stream = System.IO.File.OpenWrite(y + "\\" + x2 + ".ico"))
                    {
                        Bitmap bitmap = (Bitmap)Image.FromFile(x);
                        Icon.FromHandle(bitmap.GetHicon()).Save(stream);
                    }
                    pictureBox1.ImageLocation = x;
                    MessageBox.Show("Imagem convertida com sucesso.");
                }
            }
        }
    }
}
