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
        /// <summary>
        /// Contenedor framework Unity.
        /// </summary>
        private UnityContainer miContenedorIoC = null;

        /// <summary>
        /// Registra por convencion todas las clases con su interfaz, que se nombra igual pero con la I inicial.
        /// </summary>
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
        /// <summary>
        /// Devuelve una instancia de una clase a partir de su interfaz.
        /// </summary>
        public object DameInstancia(Type interfaz)
        {

            object instancia = miContenedorIoC.Resolve(interfaz);
            return instancia;
        }
        /// <summary>
        /// Metodo usado en el proyecto de pruebas UnitTestProject porque el metodo Registro no registraba correctamente todas las clases y se necesitaba hacerlo explicitamente
        /// 
        /// </summary>
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
