using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VacunDesktop.Core;
using VacunDesktop.ExtensionMethods;
using VacunDesktop.Models;

namespace VacunDesktop.Presentation
{
    public partial class FrmNuevoEditarPaciente : Form
    {
        public int? IdEditar { get; set; }
        //Creamos una propiedad de tipo web cam
        WebCam webCam;
        Paciente paciente = new Paciente();

        //Nuevo paciente desde el formulario FrmTutores

        public FrmNuevoEditarPaciente(Tutor tutor)
        {
            InitializeComponent();
            //inicializamos la webCam pasandole el picture box, la activacion en falso y el "this" para saber el formulario actual
            webCam = new WebCam(this, AutoActivate : false, PbxImagen);
            CargarCboTutor();
            LlenarComboSexo();
            LlenarComboCalendario();
            CboTutor.Enabled = false;
            CboTutor.SelectedValue = tutor.Id;
            
        }
        // editar paciente existente desde el formulario FrmTutores

        public FrmNuevoEditarPaciente(Tutor tutor, int idPacienteSeleccionado)
        {
            InitializeComponent();
            webCam = new WebCam(this, AutoActivate: false, PbxImagen);
            CargarCboTutor();
            LlenarComboSexo();
            LlenarComboCalendario();
            CboTutor.Enabled = false;
            CboTutor.SelectedValue = tutor.Id;
            if (idPacienteSeleccionado != 0)
            {
                IdEditar = idPacienteSeleccionado;
                //llamamos al metodo de carga datos
                CargarDatosDelPaciente();
            }
        }
        //Nuevo paciente ejecutado desde el FrmPacientes
        public FrmNuevoEditarPaciente()
        {
            InitializeComponent();
            webCam = new WebCam(this, AutoActivate: false, PbxImagen);
            CargarCboTutor();
            LlenarComboSexo();
            LlenarComboCalendario();
        }
            
           //Editando un paciente desde FrmPacientes
        public FrmNuevoEditarPaciente(int idSeleccionado )
        {
            InitializeComponent();
            webCam = new WebCam(this, AutoActivate: false, PbxImagen);
            CargarCboTutor();
            LlenarComboSexo();
            LlenarComboCalendario();
            if (idSeleccionado != 0)
            {
                IdEditar = idSeleccionado;
                //llamamos al metodo de carga datos
                CargarDatosDelPaciente();
            }
        }

        private void CargarDatosDelPaciente()
        {
            using (var db=new VacunWebContext())
            {
                paciente =db.Pacientes.Find(IdEditar);
                TxtApellido.Text = paciente.Apellido;
                TxtNombre.Text = paciente.Nombre;
                TxtDomicilio.Text = paciente.Domicilio;
                CboSexo.SelectedItem = paciente.Sexo;
                CboTutor.SelectedValue = paciente.TutorId;
                CboCalendario.SelectedValue = paciente.CalendarioId;
                ChkPrematuro.Checked = paciente.Prematuro;
                NUpDownDni.Value = paciente.Dni;
                DtpFechaNacimiento.Value = paciente.FechaNacimiento;
                NudPeso.Value = (decimal)paciente.Peso;
                if (paciente.Imagen!= null)
                    PbxImagen.Image = Helper.convertirBytesAImagen(paciente.Imagen);
            }
        }

        private void LlenarComboCalendario()
        {
            using (var db = new VacunWebContext())
            {
                var listaCalendarios = from calendario in db.Calendarios
                                   select new { id = calendario.Id, nombre = calendario.Nombre};
                //cargamos el combo de Calendarios con los existentes en la base de datos
                CboCalendario.DataSource = listaCalendarios.ToList();
                CboCalendario.DisplayMember = "nombre";
                CboCalendario.ValueMember = "id";
            }

        }
        private void LlenarComboSexo()
        {
            CboSexo.DataSource = Enum.GetValues(typeof(SexoEnum));
        }
        private void CargarCboTutor()
        {
            using (var db=new VacunWebContext())
            {
                var listaTutores = from tutor in db.Tutores
                                   select new { id = tutor.Id, nombre = tutor.Apellido + " " + tutor.Nombre };
                //cargamos el combo de tutores con los existentes en la base de datos
                CboTutor.DataSource = listaTutores.ToList();
                CboTutor.DisplayMember = "nombre";
                CboTutor.ValueMember = "id";
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            using (var db = new VacunWebContext())
            {

                //le asignamos a sus propiedades el valor de cada uno de los cuadros de texto
                paciente.Nombre = TxtNombre.Text;
                paciente.Apellido = TxtApellido.Text;
                paciente.Domicilio = TxtDomicilio.Text;
                paciente.Sexo = (SexoEnum)CboSexo.SelectedValue;
                paciente.Prematuro = ChkPrematuro.Checked;
                paciente.TutorId = (int)CboTutor.SelectedValue;
                paciente.CalendarioId = (int)CboCalendario.SelectedValue;
                paciente.Dni = (int)NUpDownDni.Value;
                paciente.Peso = (double)NudPeso.Value;
                paciente.FechaNacimiento = DtpFechaNacimiento.Value.Date;
                // si hay una imagen definida la almcenamos en la propiedad correspondiente
                if (PbxImagen == null)
                    paciente.Imagen = Helper.convertirImagenABytes(PbxImagen.Image);
                BtnCapturarFoto.Enabled = true;
                //si el id del Paciente a editar es nulo agregamos un Calendario a la tabla
                if (IdEditar == null)
                    //lo agregamos al objeto Paciente al objeto DbContext
                    db.Pacientes.Add(paciente);
                else //configuramos el almacenamiento de la modificacion si el id de Paciente es distinto de nulo
                {
                    BtnCapturarFoto.Enabled = false;
                    db.Entry(paciente).State = EntityState.Modified;
                }

                //guardamos los cambios
                db.SaveChanges();
            }
            //cerramos el formulario
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.MensajeDeAdvertenciaDeSalida();
        }


        private void BtnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdAbrirArchivo = new OpenFileDialog();
            string filtro = "Todas las imágenes|*.jpg;*.gif;*.png;*.bmp;*.jpeg";
            filtro += "|JPG (*.jpg)|*.jpg";
            filtro += "|JPEG (*.jpeg)|*.jpeg";
            filtro += "|GIF (*.gif)|*.gif";
            filtro += "|PNG (*.png)|*.png";
            filtro += "|BMP (*.bmp)|*.bmp";

            ofdAbrirArchivo.Filter = filtro;
            ofdAbrirArchivo.ShowDialog();

            if (ofdAbrirArchivo.FileName != "")
            {
                PbxImagen.Image = new Bitmap(ofdAbrirArchivo.FileName);
                //TxtImagen.Text = ofdAbrirArchivo.FileName;
            }
        }

        private void BtnIniciarDetenerCamara_Click(object sender, EventArgs e)
        {
            if (BtnIniciarDetenerCamara.Text == "Iniciar cámara")
            {
                InicializarCamara();
            }
            else
            {
                DetenerCamara();
            }
        }
        private void InicializarCamara()
        {
            webCam.Initalize();
            BtnIniciarDetenerCamara.Text = "Detener cámara";
            BtnCapturarFoto.Text = "Capturar Foto";
            //RefrescarPaneles();
            BtnCapturarFoto.Enabled = true;
        }
        private void DetenerCamara()
        {
            webCam.Deinitalize();
            BtnIniciarDetenerCamara.Text = "Iniciar cámara";
            BtnCapturarFoto.Text = "Borrar Foto";
            BtnCapturarFoto.Enabled = false;
        }

        private void BtnCapturarFoto_Click(object sender, EventArgs e) {
            if (BtnCapturarFoto.Text == "Borrar Foto")
                PbxImagen.Image = null;
            else
            {
                DetenerCamara();
            } 
        }
    }
}
