using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

namespace Usuario.MiContenedorIoC
{
    public class MiClaseContenedorIoC :  IMiContenedorIoC
    {
        private UnityContainer miContenedorIoC = null;
 
        public void  Registra(string nombreEspacioEmpieza)
        {
            if (miContenedorIoC == null)
            {
                miContenedorIoC = new UnityContainer();
            }

            miContenedorIoC.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(t => t.Namespace.StartsWith(nombreEspacioEmpieza)),
                //  AllClasses.FromAssemblies(typeof(Usuario.).Assembly),
                    WithMappings.FromMatchingInterface,
                   WithName.Default,
                   WithLifetime.ContainerControlled
            );
            

        }

        public object DameInstancia(Type interfaz)
        {

            object instancia = miContenedorIoC.Resolve(interfaz);
            return instancia;

        }
        public void RegistraTest(Type interfaz,Type clase)
        {
            if (miContenedorIoC == null)
            {
                miContenedorIoC = new UnityContainer();
            }
            miContenedorIoC.RegisterType(interfaz, clase);
            
        }
    }
}
