using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VacunDesktop.Presentation
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void mnuItemTutores_Click(object sender, EventArgs e)
        {
            //MECANISMO PARA LLAMAR A UN FORMULARIO Y MOSTRARLO EN PANTALLA
            var frmTutores = new FrmTutores();
            frmTutores.ShowDialog();
            
        }

        private void mnuItemVacuna_Click(object sender, EventArgs e)
        {
            var frmVacuna = new FrmVacuna();
            frmVacuna.ShowDialog();
        }

        private void mnuItemSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta Luego");
            this.Close();
        }

        private void mnuCalendarios_Click(object sender, EventArgs e)
        {
            var frmCalendarios = new FrmCalendarios();
            frmCalendarios.ShowDialog();
        }

        private void MnuItemPacientes_Click(object sender, EventArgs e)
        {
            var frmPacientes = new FrmPacientes();
            frmPacientes.ShowDialog();
        }

        private void BtnTutores_Click(object sender, EventArgs e)
        {
            //MECANISMO PARA LLAMAR A UN FORMULARIO Y MOSTRARLO EN PANTALLA
            var frmTutores = new FrmTutores();
            frmTutores.ShowDialog();
        }

        private void BtnCalendarios_Click(object sender, EventArgs e)
        {
            var frmCalendarios = new FrmCalendarios();
            frmCalendarios.ShowDialog();
        }

        private void mnuListadoDeVacunas_Click(object sender, EventArgs e)
        {
            var frmListadoVacunas = new FrmListadoVacunas();
            frmListadoVacunas.ShowDialog();
        }

        private void mnuListadoCalendarios_Click(object sender, EventArgs e)
        {
            var frmListadoCalendarios = new FrmListadoCalendarios();
            frmListadoCalendarios.ShowDialog();
        }

        private void mnuCalendariosYVacunas_Click(object sender, EventArgs e)
        {
            var frmListadoCalendariosYVacunas = new FrmListadoCalendariosVacunas();
            frmListadoCalendariosYVacunas.ShowDialog();

        }
    }
}
