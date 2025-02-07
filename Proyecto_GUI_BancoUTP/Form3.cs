using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Proyecto_GUI_BancoUTP
{
    
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LBName.Text = Usuarios.UsuarioActual?.Nombre ?? "Usuario no identificado";
            double saldo = Usuarios.UsuarioActual?.ConsultarSaldo() ?? 0; // Obtiene el saldo
            lbSaldo.Text = "Saldo: " + saldo.ToString("C");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void btnMov_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.ShowDialog();
            this.Close();
        }
    }
}
