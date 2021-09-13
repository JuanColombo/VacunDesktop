using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VacunDesktop.Models;

namespace VacunDesktop.Presentation
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void InicioConexionSql()
        {
            using (var db = new VacunWebContext())
            {
                var listaVacunas = db.Vacunas.ToList();
            }

        }
        private void ImpresionDeReportes()
        {
            var reporte = new ReportViewer();
            //abrumos el reporte utilizando la clase FileStream
            using var fs = new FileStream(@"reportes\ReporteVacunas.rdlc", FileMode.Open);

            //asignamos el archivo a la propiedad LocalReport del objeto RepoViewer
            reporte.LocalReport.LoadReportDefinition(fs);

            //buscamos los datos que va a graficar el reporte
            using var db = new VacunWebContext();
            var vacunas = db.Vacunas.ToList();

            //asignamos los datos a la propiedad DataSources de Local Report utilizando un objeto de tipo ReportDataSource
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSetVacunas", vacunas));

            reporte.RefreshReport();
        }

        private void timerInicio_Tick(object sender, EventArgs e)
        {
                PbInicio.Value += 1;
                lblPorcentaje.Text = PbInicio.Value.ToString() + " %";
            if(PbInicio.Value ==100){
                timerInicio.Enabled = false;
                var frmMenuPrincipal = new FrmMenuPrincipal();
                frmMenuPrincipal.ShowDialog();
                this.Close();
            }
        }

        private void FrmInicio_Activated(object sender, EventArgs e)
        {
            InicioConexionSql();
            ImpresionDeReportes();
        }


    }
}
