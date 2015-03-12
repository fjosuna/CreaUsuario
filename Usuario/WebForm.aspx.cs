
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Usuario.CapaLogicaNegocio;
using Usuario.MiContenedorIoC;
using Usuario.MisExcepciones;

namespace UsuarioApp
{
    public partial class WebForm : System.Web.UI.Page
    {
        
        /// <summary>
        /// Almacenamos tanto el contenedor IoC como una instancia de la capa de negocio en la sesion.
        /// </summary>
        private IUsuarioCapaLogicaNegocio _usuarioCapaLogicaNegocio;
        public IUsuarioCapaLogicaNegocio usuarioCapaLogicaNegocio
        {
            // guardamos el usuario de negocio en la sesion ademas de en el atributo de la clase
            set { 
                this._usuarioCapaLogicaNegocio = value;
                Session["usuarioCapaLogicaNegocio"] = value;
            }
            // si no tenemos un usuario de negocio en la sesion lo creamos
            get {
                if (this._usuarioCapaLogicaNegocio == null)
                {
                    this._usuarioCapaLogicaNegocio = Session["usuarioCapaLogicaNegocio"] as UsuarioCapaLogicaNegocio;

                    if (this._usuarioCapaLogicaNegocio == null){
                        MiClaseContenedorIoC miContenedor = new MiClaseContenedorIoC();
                        miContenedor = Application["MiContenedorIoC"] as MiClaseContenedorIoC;
                        
                        // Evitamos el constructor new para desacoplar al maximo la implementacion de la logica de negocio
                        //usuarioCapaLogicaNegocio = new UsuarioCapaLogicaNegocio(miContenedor);
                        usuarioCapaLogicaNegocio = miContenedor.DameInstancia(typeof(IUsuarioCapaLogicaNegocio)) as UsuarioCapaLogicaNegocio;
                        usuarioCapaLogicaNegocio.Init(miContenedor);
                    }
                }
                return this._usuarioCapaLogicaNegocio; 
            }
        }

        /// <summary>
        /// Metodo que respondel al evento del boton "Crear" y usando una instancia de la capa de negocio almacena el usuario en la base de datos.
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                // Al pulsar el boton creamos el usuario en la capa de datos
                usuarioCapaLogicaNegocio.Crea(txtUsuario.Text);

                lblTodos.Text = usuarioCapaLogicaNegocio.ToString();
            }
            // Excepcion controlada o tratada
            catch (UsuarioVacioException ex)
            {
                lblError.Text = "No se permite un usuario vacío";
            }
                // Excepcion no controlada
            catch (Exception ex)
            {
                string msgExtendido = "";
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                {
                    msgExtendido = (string.IsNullOrEmpty(ex.InnerException.InnerException.Message)) ? "" : ex.InnerException.InnerException.Message;
                
                }
                lblError.Text = "Se ha producido un error incontrolado: " + ex.Message + ". " + msgExtendido;
            }
        }
    }
}