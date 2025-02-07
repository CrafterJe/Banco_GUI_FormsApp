using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GUI_BancoUTP
{
    public partial class Form5 : Form
    {

        public Form5()
        {
            InitializeComponent();
            txtRetirar.ReadOnly = true;
            txtRetirar.HideSelection = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el monto a retirar del TextBox
                double monto;
                if (double.TryParse(txtRetirar.Text.Trim(), out monto) && monto > 0)
                {
                    // Verificar que el usuario tenga suficiente saldo
                    double saldoActual = Usuarios.UsuarioActual.ConsultarSaldo();
                    if (monto <= saldoActual)
                    {
                        // Actualizar el saldo del usuario actual
                        Usuarios.UsuarioActual.RetirarSaldo(monto);

                        // Registrar la transacción en la base de datos
                        Usuarios.UsuarioActual.RegistrarTransaccion(-monto, "Retiro");

                        // Mensaje de éxito
                        MessageBox.Show("Retiro realizado con éxito.");

                        // Limpiar el campo de entrada
                        txtRetirar.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Saldo insuficiente para realizar el retiro.");
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa una cantidad válida y positiva.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn1 = (Button)sender;  // convierte el objeto sender en un botón
            string numero = btn1.Text;     // obtiene el número del botón

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;  // si el cuadro de texto contiene un 0, lo reemplaza con el número del botón
            }
            else
            {
                txtRetirar.Text += numero;  // concatena el número al final del saldo existente
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Button btn2 = (Button)sender;
            string numero = btn2.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Button btn3 = (Button)sender;
            string numero = btn3.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Button btn4 = (Button)sender;
            string numero = btn4.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button btn5 = (Button)sender;
            string numero = btn5.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Button btn6 = (Button)sender;
            string numero = btn6.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Button btn7 = (Button)sender;
            string numero = btn7.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Button btn8 = (Button)sender;
            string numero = btn8.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Button btn9 = (Button)sender;
            string numero = btn9.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void btnCorregir_Click(object sender, EventArgs e)
        {
            txtRetirar.Clear();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Button btn0 = (Button)sender;
            string numero = btn0.Text;

            if (txtRetirar.Text == "0")
            {
                txtRetirar.Text = numero;
            }
            else
            {
                txtRetirar.Text += numero;
            }
        }

        private void txtRetirar_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
