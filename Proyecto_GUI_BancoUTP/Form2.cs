using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GUI_BancoUTP
{
    public partial class Form2 : Form
    {
        int index = 1;
        public Form2()
        {
            InitializeComponent();
            txtNombre.ReadOnly = true;
            txtNombre.HideSelection = true;
            // Mostrar el nombre del usuario actual en el TextBox
            txtNombre.Text = Usuarios.UsuarioActual?.Nombre ?? "Usuario no identificado"; // Muestra un mensaje si no hay usuario
        }

        private async void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar sesión al salir
            MessageBox.Show("Cerrando sesión...");
            Usuarios.UsuarioActual = null;

            // Esperar 2 segundos (2000 ms) antes de cerrar
            await Task.Delay(2000);

            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }


        private void btnInformacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Close();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.ShowDialog();
            this.Close();
        }

        private void btnReferencias_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6(index);
            form6.ShowDialog();
            this.Close();
        }
    }
}
