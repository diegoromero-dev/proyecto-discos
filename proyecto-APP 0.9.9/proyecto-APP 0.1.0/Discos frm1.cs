using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace proyecto_APP_0._1._0
{
    public partial class frmdiscos : Form
    {
        private List<disco> listadisco;
        

        public frmdiscos()
        {
            InitializeComponent();
        }
        
        //carga los combobox con datos para su previa seleccion
        private void frmdiscos_Load(object sender, EventArgs e)
        {
            cargar();
            cbcampo.Items.Add("Titulo");
            cbcampo.Items.Add("Fecha de lanzamiento");
            cbcampo.Items.Add("Cantidad de canciones");
            cbcampo.SelectedIndex = 0;
            cbcriterio.SelectedIndex = 0;
            
        }

        //carga los datos traidos de la database y los imprime en el datagridview
        private void cargar() 
        {
            try
            {
                NegocioDisco negocio = new NegocioDisco();
                listadisco = negocio.listar();
                dgvdisco.DataSource = listadisco;
                ocultarColumnas();
                CargarImagen(listadisco[0].UrlImagenTapa);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        //oculta columnas que no nesecitan ser mostradas
        private void ocultarColumnas() 
        {
            dgvdisco.Columns["UrlImagenTapa"].Visible = false;
            dgvdisco.Columns["Id"].Visible = false;
            dgvdisco.Columns["UbicacionCancionesLocal"].Visible = false;
        }

        //cambia la imagen de la fila seleccionada
        private void dgvdisco_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvdisco.CurrentRow != null)
            {
                disco discselecionado = (disco)dgvdisco.CurrentRow.DataBoundItem;
                CargarImagen(discselecionado.UrlImagenTapa);
            }
            
        }

        //carga las imagenes de la database y en caso de no tener nada carga una imagen por default, moduliza esta funcion para usarla mas veces
        private void CargarImagen(string imagen) 
        {
            try
            {
                pbtapadiscos.Load(imagen);
            }
            catch (Exception)
            {

                pbtapadiscos.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRGh5WFH8TOIfRKxUrIgJZoDCs1yvQ4hIcppw&s");
            }
        }

        //al darle al btn agregar, te muestra una ventana para ingresar un nuevo disco con sus atributos
        private void btnagregar_Click(object sender, EventArgs e)
        {
            Frmagregardiscos agregar = new Frmagregardiscos();
            agregar.ShowDialog();
            cargar();
            
        }

        //despues de seleccionar una fila podes modificarla al darle al btn modificar
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            disco seleccionado;
            seleccionado = (disco)dgvdisco.CurrentRow.DataBoundItem;
            Frmagregardiscos modificar = new Frmagregardiscos(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        //eliminar la fila seleccionada de forma permanente y te lo vuelve a preguntar con un cartel de aviso
        private void btneliminar_Click(object sender, EventArgs e)
        {
            NegocioDisco negocio = new NegocioDisco();
            disco seleccionadoeliminar;
            try
            {
                DialogResult resultadoeliminacionboton = MessageBox.Show("¿Seguro que lo quiere eliminar?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultadoeliminacionboton == DialogResult.Yes)
                { 
                    seleccionadoeliminar = (disco)dgvdisco.CurrentRow.DataBoundItem;
                    negocio.eliminarfisico(seleccionadoeliminar);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        //elimina un fila seleccionda, pero de esta forma se puede recuperar los datos en caso de equivocacion
        private void btneliminarlogica_Click(object sender, EventArgs e)
        {
            NegocioDisco negocio = new NegocioDisco();
            disco baja;
            try
            {
                DialogResult resultadoeliminacionboton = MessageBox.Show("¿Seguro que lo quiere eliminar?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultadoeliminacionboton == DialogResult.Yes)
                {
                    baja = (disco)dgvdisco.CurrentRow.DataBoundItem;
                    negocio.eliminarlogico(baja);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        //un filtro para busqueda avanzada en caso de tener muchos datos
        private void btnfiltro_Click(object sender, EventArgs e)
        {
            string filtro = txtfiltro.Text;
            List<disco> listaFiltrada;
            
            if (filtro != "")
            {
                listaFiltrada = listadisco.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.FechaLanzamiento.ToUpper().Contains(filtro.ToUpper()) || x.Edicion.EdicionDescripcion.ToUpper().Contains(filtro.ToUpper()) || x.CantidadDeCanciones.ToString().Contains(filtro));
                dgvdisco.DataSource = null;
                dgvdisco.DataSource = listaFiltrada;
                ocultarColumnas();
            }
            else
            {
                dgvdisco.DataSource = listadisco;
            }
            
        }

        //un filtro que se actualiza mientras vas escribiendo, un poco mas dinamico
        private void txtfiltrosinboton_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtfiltrosinboton.Text;
            List<disco> listaFiltrada;

            if (filtro != "")
            {
                listaFiltrada = listadisco.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.FechaLanzamiento.ToUpper().Contains(filtro.ToUpper()) || x.Edicion.EdicionDescripcion.ToUpper().Contains(filtro.ToUpper()) || x.CantidadDeCanciones.ToString().Contains(filtro));
                dgvdisco.DataSource = null;
                dgvdisco.DataSource = listaFiltrada;
                ocultarColumnas();
            }
            else
            {
                dgvdisco.DataSource = listadisco;
            }
        }

        //estos combobox forman parte de una busqueda mas avanza, en donde podes filtrar por campo o criterio
        private void cbcampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbcampo.SelectedItem.ToString();
            if (opcion == "Cantidad de canciones")
            {
                cbcriterio.Items.Clear();
                cbcriterio.Items.Add("Mayor a");
                cbcriterio.Items.Add("Menor a");
                cbcriterio.Items.Add("Igual a");
                cbcriterio.SelectedIndex = 0;
                btnfiltroavanzado.Enabled = false;
                txtfiltroavanzadosolonumeros.Visible = true;
                txtfiltroavanzado.Visible = false;
                
            }
            else if(opcion == "Fecha de lanzamiento")
            {
                cbcriterio.Items.Clear();
                cbcriterio.Items.Add("Comienza con");
                cbcriterio.Items.Add("Termina con");
                cbcriterio.Items.Add("Contiene");
                cbcriterio.SelectedIndex = 0;
                txtfiltroavanzado.BackColor = System.Drawing.SystemColors.Control;
                txtfiltroavanzadosolonumeros.Visible = false;
                txtfiltroavanzado.Visible = true;
                btnfiltroavanzado.Enabled = true;
            }
            else if (opcion == "Titulo")
            {
                cbcriterio.Items.Clear();
                cbcriterio.Items.Add("Comienza con");
                cbcriterio.Items.Add("Termina con");
                cbcriterio.Items.Add("Contiene");
                cbcriterio.SelectedIndex = 0;
                txtfiltroavanzado.BackColor = System.Drawing.SystemColors.Control;
                txtfiltroavanzadosolonumeros.Visible = false;
                txtfiltroavanzado.Visible = true;
                btnfiltroavanzado.Enabled = true;
            }
            
        }
       
        //recoje los datos de los combobox de la funcion de arriba para al darle click te traiga dichos resultados con sus respectivos campos o criterio seleccionados
        private void btnfiltroavanzado_Click(object sender, EventArgs e)
        {
            NegocioDisco negocio = new NegocioDisco();
            try
            {
                string resultadotxt = "";
                if (txtfiltroavanzadosolonumeros.Visible == true)
                {
                    resultadotxt = txtfiltroavanzadosolonumeros.Text;
                }
                if (txtfiltroavanzado.Visible == true)
                {
                    resultadotxt = txtfiltroavanzado.Text;
                }
                string campo = cbcampo.SelectedItem.ToString();
                string criterio = cbcriterio.SelectedItem.ToString();
                string filtro = resultadotxt;
                dgvdisco.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        //metodo para resetear campo,criterio y busqueda
        public void resetfiltro() 
        {
            NegocioDisco negocio = new NegocioDisco();
            try
            {
                string resultadotxt = "";
                if (txtfiltroavanzadosolonumeros.Visible == true)
                {
                    resultadotxt = txtfiltroavanzadosolonumeros.Text;
                }
                if (txtfiltroavanzado.Visible == true)
                {
                    resultadotxt = txtfiltroavanzado.Text;
                }
                string campo = cbcampo.SelectedItem.ToString();
                string criterio = cbcriterio.SelectedItem.ToString();
                string filtro = resultadotxt;
                dgvdisco.DataSource = negocio.filtrar(campo, criterio, filtro);
                txtfiltroavanzado.Clear();
                txtfiltroavanzadosolonumeros.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

      
        //solo permite escribir numeros para ciertas busquedas avanzadas
        private void txtfiltroavanzadosolonumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true; //solo numeros, no letras
            }
        }

        //en caso de no escribir numeros o que no contenga nada, te lo pinta de rojo como error
        private void txtfiltroavanzadosolonumeros_TextChanged(object sender, EventArgs e)
        {
            if (txtfiltroavanzadosolonumeros.Text == "")
            {
                txtfiltroavanzadosolonumeros.BackColor = Color.Red;
                btnfiltroavanzado.Enabled = false;

            }
            else
            {
                txtfiltroavanzadosolonumeros.BackColor = System.Drawing.SystemColors.Control;
                btnfiltroavanzado.Enabled = true;

            }
        }

        //este btn usa el metodo resetear
        private void btnresetearbusquedafiltrada_Click(object sender, EventArgs e)
        {
            cbcampo.SelectedIndex = 0;
            cbcriterio.SelectedIndex = 0;
            txtfiltroavanzado.Clear();
            txtfiltroavanzadosolonumeros.Clear();
            resetfiltro();
            
        }

      

        
    }
}
