using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Proyecto_GUI_BancoUTP
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            string rutaArchivo = @"C:\Users\CrafterJe\Documents\Visual Studio 2022\Banco_UTP\Proyecto_GUI_BancoUTP\message.txt";

            if (File.Exists(rutaArchivo))
            {
                richTextBox1.Text = File.ReadAllText(rutaArchivo);
            }
            else
            {
                MessageBox.Show("No se encontró el archivo del aviso de privacidad en la ruta especificada.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }
    }
}
