using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace proyecto_APP_0._1._0

{
    public partial class Frmagregardiscos : Form
    {
        private disco disco = null;
        public Frmagregardiscos()
        {
            InitializeComponent();
        }
        public Frmagregardiscos(disco disco)
        {
            InitializeComponent();
            this.disco = disco;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //al darle click en aceptar y el disco no posee una id, entonces es un disco nuevo el cual se agrega y salta el mensaje disco agregado,
        //pero si ya posee una id entonces te salta el mensaje de modificacion exitosa y lo modifica en la database
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            NegocioDisco negocio = new NegocioDisco();
            try
            {
                if (disco == null)
                    disco = new disco();
              
                disco.Titulo = txttitulo.Text;
                disco.FechaLanzamiento = dtpfechalanzamiento.Text;
                disco.CantidadDeCanciones = int.Parse(txtcantidadcanciones.Text);
                disco.UrlImagenTapa = txturltapadisco.Text;
                disco.Estilo = (TipoDeEstilo)cbestilo.SelectedItem;
                disco.Edicion = (TipoDeEdicion)cbedicion.SelectedItem;
                //si disco.Id = 0, no entra, por lo tanto es un disco nuevo
                if (disco.Id != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente");
                }
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        
        //si apretaste el btn ver disco te lo carga con su informacion mas sus canciones, pero si le diste al btn agregar te lo carga vacio para su posterior rellenado
        private void Frmagregardiscos_Load(object sender, EventArgs e)
        {
            
            estilonegocio estilo = new estilonegocio();
            edicionNegocio edicion = new edicionNegocio();
            try
            {
                cbestilo.DataSource = estilo.listar();
                cbestilo.ValueMember = "Id";
                cbestilo.DisplayMember = "Descripcion";
                cbedicion.DataSource = edicion.listar();
                cbedicion.ValueMember = "Id";
                cbedicion.DisplayMember = "EdicionDescripcion";

                //si es distinto de null entonces quiere modificar un disco ya existente
                if (disco != null)
                {
                    txttitulo.Text = disco.Titulo;
                    dtpfechalanzamiento.Text = disco.FechaLanzamiento;
                    txtcantidadcanciones.Text = disco.CantidadDeCanciones.ToString();
                    txturltapadisco.Text = disco.UrlImagenTapa;
                    CargarImagen(disco.UrlImagenTapa);
                    cbestilo.SelectedValue = disco.Estilo.id;
                    cbedicion.SelectedValue = disco.Edicion.id;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        //le pasa una url por parametro al metodo cargar imagen
        private void txturltapadisco_Leave(object sender, EventArgs e)
        {
            CargarImagen(txturltapadisco.Text);
        }

        //si no se le pasa una imagen, precarga una default
        private void CargarImagen(string imagen)
        {
            try
            {
                pbprecargardeagregarimagen.Load(imagen);
            }
            catch (Exception)
            {

                pbprecargardeagregarimagen.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRGh5WFH8TOIfRKxUrIgJZoDCs1yvQ4hIcppw&s");
            }
        }

        //si el txt titulo esta vacio lo pinta de rojo es lo minimo que tiene que tener un disco para su insercion en la database
        private void txttitulo_Leave(object sender, EventArgs e)
        {
            
            if (txttitulo.Text == "")
            {
                txttitulo.BackColor = Color.Red;
                btnaceptar.Enabled = false;
                lblobligatoriotitulo.Visible = true;
            }
            else
            {
                txttitulo.BackColor = System.Drawing.SystemColors.Control;
                lblobligatoriotitulo.Visible = false;
            }
        }

        //si el txt cantidad de canciones esta vacio lo pinta de rojo es lo minimo que tiene que tener un disco para su insercion en la database
        private void txtcantidadcanciones_Leave(object sender, EventArgs e)
        {
            
            if (txtcantidadcanciones.Text == "")
            {
                txtcantidadcanciones.BackColor = Color.Red;
                btnaceptar.Enabled = false;
                lblobligatoriocanciones.Visible = true;
            }
            else
            {
                txtcantidadcanciones.BackColor = System.Drawing.SystemColors.Control;
                btnaceptar.Enabled = true;
                lblobligatoriocanciones.Visible = false;
            }
        }

        //este metodo sirve para que solo en el txt cantidadcanciones solo ponga numeros
        private void txtcantidadcanciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true; //solo numeros, no letras
            }
        }

       
    }
}
