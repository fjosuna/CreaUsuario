using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Usuario.CapaDatos;
using Usuario.MiContenedorIoC;
using Usuario.MisExcepciones;

namespace Usuario.CapaLogicaNegocio
{
    

    public class UsuarioCapaLogicaNegocio : IUsuarioCapaLogicaNegocio
    {
        private  IUsuarioCapaDatos usuarioCapaDatos;

        /// <summary>
        /// Obtenemos una instania del objeto de la capa de datos.
        /// </summary>
        public void Init(IMiContenedorIoC miContenederIoC ){

            // Evitamos el constructor new para desacoplar al maximo la implementacion de la capa de datos
            usuarioCapaDatos = miContenederIoC.DameInstancia(typeof(IUsuarioCapaDatos)) as UsuarioCapaDatos;
        }

        /// <summary>
        /// Usando la capa de datos creamos un nombre de usuario.
        /// </summary>
        public void Crea(string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
            {
                throw new UsuarioVacioException();
            }
            usuarioCapaDatos.Crea(nombre);
        }

        /// <summary>
        /// Obtiene una cadena con todos los usuarios. Metodo usado para comprobar la inserccion correcta de un usuario.
        /// </summary>
        public string ToString()
        {
            return usuarioCapaDatos.ToString();
        }
        
    }
}
