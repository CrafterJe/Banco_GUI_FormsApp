using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_GUI_BancoUTP
{
    public partial class Form1 : Form
    {
        // Definir variables necesarias
        int attempts = 3; // Intentos permitidos

        public Form1()
        {
            InitializeComponent();
            txtUser.MaxLength = 10; // Limitar longitud del usuario
            txtUser.Text = "UTP";
            txtPassword.MaxLength = 6; // Limitar longitud de la contraseña
            txtPassword.UseSystemPasswordChar = true; // Ocultar la contraseña
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicialización adicional si es necesario
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUser.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Verificar que los campos no estén vacíos
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Debe llenar todos los campos");
                    return;
                }

                // Crear una nueva instancia de Usuarios para verificar credenciales
                Usuarios usuario = new Usuarios(username, password);

                // Verificar credenciales
                if (usuario.VerificarCredenciales(username, password))
                {
                    // Si las credenciales son correctas, guardar el usuario actual
                    Usuarios.UsuarioActual = usuario;

                    // Mostrar mensaje de acceso concedido
                    MessageBox.Show("Acceso concedido. Bienvenido " + Usuarios.UsuarioActual.Nombre);

                    // Abrir Form2 y ocultar Form1
                    Form2 form2 = new Form2(); // Puedes pasar el usuario actual si es necesario
                    this.Hide();
                    form2.ShowDialog();
                    this.Close();
                }
                else
                {
                    attempts--; // Reducir el número de intentos restantes
                    MessageBox.Show("Usuario o contraseña incorrectos.\nTe quedan " + attempts + " intentos.");

                    // Deshabilitar el botón de login si se han agotado los intentos
                    if (attempts == 0)
                    {
                        btnlogin.Enabled = false; // Deshabilitar botón de inicio de sesión
                        MessageBox.Show("Ya no te quedan más intentos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Lógica adicional si es necesario
        }

        private void BtnCrearCuenta_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de creación de cuenta
            Form8 form8 = new Form8();
            this.Hide();
            form8.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Llb1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form9 form9 = new Form9();
            this.Hide();
            form9.ShowDialog();
            this.Close();

        }
    }
}

