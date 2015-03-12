using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Usuario.MiContenedorIoC;

namespace UsuarioApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            MiClaseContenedorIoC miContenedor = new MiClaseContenedorIoC();

            // Registramos por CONVENCION todas las clases con su interfaz cuyo Namespace comienze por Usuario
            miContenedor.Registra("Usuario");
            Application["MiContenedorIoC"] = miContenedor;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application["MiContenedorIoC"] = null;
        
        }
    }
}