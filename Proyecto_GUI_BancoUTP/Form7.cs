using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_GUI_BancoUTP.Usuarios;

namespace Proyecto_GUI_BancoUTP
{
    public partial class Form7 : Form
    {
        public Form7()
        {

            InitializeComponent();
            CargarTransacciones();

        }
        private void CargarTransacciones()
        {
            // Obtener las transacciones del usuario actual
            var transacciones = Usuarios.UsuarioActual.ObtenerTransacciones();

            foreach (var transaccion in transacciones)
            {
                // Agregar las transacciones a la lista
                lbMov.Items.Add($"{transaccion.Fecha}: {transaccion.Tipo} - ${transaccion.Monto}");
            }
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }
    }
}
