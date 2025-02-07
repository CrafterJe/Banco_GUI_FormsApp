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
    public partial class Form8 : Form
    {
        private Usuarios usuarios = new Usuarios();

        public Form8()
        {
            InitializeComponent();
            txtPassword.MaxLength = 6;
            txtUsername.MaxLength = 10; // Limitar el tamaño a 10 caracteres
            txtUsername.TextChanged += new EventHandler(txtUsername_TextChanged); // Agregar el evento
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void BtnCrearCuenta_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string nombre = txtNombre.Text;

            // Validar que no haya campos vacíos
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return; // Salir del método si hay campos vacíos
            }

            // Validar que el PIN tenga exactamente 6 caracteres y que contenga solo dígitos
            if (password.Length != 6 || !password.All(char.IsDigit))
            {
                MessageBox.Show("El PIN debe ser de exactamente 6 dígitos numéricos.");
                return; // Salir del método si la validación falla
            }

            try
            {
                usuarios.CrearUsuario(username, password, nombre);
                MessageBox.Show("Cuenta creada exitosamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Validar que el texto ingresado comience con "UTP" y tenga una longitud total de 10 caracteres
            if (txtUsername.Text.Length > 10)
            {
                // Limitar a 10 caracteres
                txtUsername.Text = txtUsername.Text.Substring(0, 10);
                txtUsername.SelectionStart = txtUsername.Text.Length; // Colocar el cursor al final
            }

            // Verificar que solo se permitan caracteres válidos
            if (txtUsername.Text.Length > 3)
            {
                string validPart = txtUsername.Text.Substring(3); // Parte que sigue a "UTP"
                if (!validPart.All(char.IsDigit)) // Comprobar si todos son dígitos
                {
                    MessageBox.Show("El username debe empezar con 'UTP' seguido de 7 dígitos.");
                    txtUsername.Text = "UTP"; // Reiniciar el campo a solo "UTP"
                    txtUsername.SelectionStart = txtUsername.Text.Length; // Colocar el cursor al final
                }
            }

            // Validar que comience con "UTP" y que el resto sean solo dígitos
            if (txtUsername.Text.Length == 10 && !txtUsername.Text.StartsWith("UTP"))
            {
                MessageBox.Show("El username debe empezar con 'UTP'.");
                txtUsername.Text = "UTP"; // Reiniciar el campo a solo "UTP"
                txtUsername.SelectionStart = txtUsername.Text.Length; // Colocar el cursor al final
            }
        }

        private void LimpiarCampos()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtNombre.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
