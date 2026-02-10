using dominio;
using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioDisco
    {
        //conexion a database vieja
        public List<disco> listar()
        {
            List<disco> lista = new List<disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion, T.Descripcion, D.IdEstilo, D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo and E.Id = T.Id and D.Activo = 1";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    disco aux = new disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = Convert.ToString(lector["FechaLanzamiento"]);
                    aux.CantidadDeCanciones = (int)lector["CantidadCanciones"];
                    if (!(lector["UrlImagenTapa"] is DBNull))
                    {
                        aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    }
                    aux.Estilo = new TipoDeEstilo();
                    aux.Estilo.id = (int)lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)lector["Descripcion"];
                    aux.Edicion = new TipoDeEdicion();
                    aux.Edicion.id = (int)lector["IdTipoEdicion"];
                    aux.Edicion.EdicionDescripcion = (string)lector[5];
                    

                    lista.Add(aux);
                    
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        //agregar datos a database
        public void agregar(disco disconuevo) 
        {
            accesodatos datos = new accesodatos();
            try
            {
                datos.setearconsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion, Activo) values ('"+disconuevo.Titulo+ "','"+disconuevo.FechaLanzamiento+"',"+disconuevo.CantidadDeCanciones+",'"+disconuevo.UrlImagenTapa+"', @IdEstilo, @IdTipoEdicion, 1)");
                datos.setearParametro("@IdEstilo", disconuevo.Estilo.id);
                datos.setearParametro("@IdTipoEdicion", disconuevo.Edicion.id);
                datos.ejercutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarconexion();
            }
        }
        //modificar datos de database
        public void modificar(disco discomodificado)
        {
            accesodatos datos = new accesodatos();
            try
            {
                datos.setearconsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fecha, CantidadCanciones = @cantidadcanciones, UrlImagenTapa = @url, IdEstilo = @idestilo, IdTipoEdicion = @idedicion where id = @id");
                datos.setearParametro("@titulo", discomodificado.Titulo);
                datos.setearParametro("@fecha", discomodificado.FechaLanzamiento);
                datos.setearParametro("@cantidadcanciones", discomodificado.CantidadDeCanciones);
                datos.setearParametro("@url", discomodificado.UrlImagenTapa);
                datos.setearParametro("@idestilo", discomodificado.Estilo.id);
                datos.setearParametro("@idedicion", discomodificado.Edicion.id);
                datos.setearParametro("@id", discomodificado.Id);

                datos.ejercutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarconexion();
            }
        }
        //eliminar datos de database
        //eliminar datos de forma fisica lo borra permanentemente
        public void eliminarfisico(disco discoeliminar) 
        {
            accesodatos datos = new accesodatos();
            try
            {
                datos.setearconsulta("delete from DISCOS where id = @id");
                datos.setearParametro("@id", discoeliminar.Id);
                datos.ejercutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            { 
                datos.cerrarconexion(); 
            }
        }
        //eliminar datos de database
        //eliminar datos de forma logica hace que se puedan recuperar en caso de error
        public void eliminarlogico(disco baja) 
        {
            accesodatos datos = new accesodatos();
            try
            {
                
                datos.setearconsulta("update DISCOS set Activo = 0 where id = @id");
                datos.setearParametro("@id",baja.Id);
                datos.ejercutaraccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarconexion();
            }
        }
        //busqueda de datos en la database

        public List<disco> filtrar(string campo, string criterio, string filtro)
        {
            List<disco> list = new List<disco>();
            accesodatos datos = new accesodatos();
            try
            {
                string consulta = "select D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion, T.Descripcion, D.IdEstilo, D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo and E.Id = T.Id and D.Activo = 1 and ";
                if (campo == "Cantidad de canciones")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "D.CantidadCanciones > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "D.CantidadCanciones < " + filtro;
                            break;
                        case "Igual a":
                            consulta += "D.CantidadCanciones = " + filtro;
                            break; 
                    }
                }
                else if(campo == "Fecha de lanzamiento")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "D.FechaLanzamiento like '"+filtro+"%'";
                            break;
                        case "Termina con":
                            consulta += "D.FechaLanzamiento like '%"+filtro+"'";
                            break;
                        case "Contiene":
                            consulta += "D.FechaLanzamiento like '%"+filtro+"%'";
                            break;
                            default:
                            break;
                    }

                }
                else if (campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "D.Titulo like '"+filtro+"%'";
                            break;
                        case "Termina con":
                            consulta += "D.Titulo like '%"+filtro+"'";
                            break;
                        case "Contiene":
                            consulta += "D.Titulo like '%"+filtro+"%'";
                            break;
                        default:
                            break;
                    }

                }
                datos.setearconsulta(consulta);
                datos.ejecutarlectura();
                while (datos.Lector.Read())
                {
                    disco aux = new disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = Convert.ToString(datos.Lector["FechaLanzamiento"]);
                    aux.CantidadDeCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                    {
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    }
                    aux.Estilo = new TipoDeEstilo();
                    aux.Estilo.id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Edicion = new TipoDeEdicion();
                    aux.Edicion.id = (int)datos.Lector["IdTipoEdicion"];
                    aux.Edicion.EdicionDescripcion = (string)datos.Lector[5];

                    list.Add(aux);

                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarconexion();
            }
        }
    }

}
