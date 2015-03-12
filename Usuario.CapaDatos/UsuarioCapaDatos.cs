using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Usuario.CapaDatos
{
    public class UsuarioCapaDatos : IUsuarioCapaDatos
    {
        /// <summary>
        /// Comprueba si ya existe en la tabla el usuario.
        /// </summary>
        public bool Existe(string nombre)
        {
            bool existe=false;
            using (usuarioEntities bdUsuario = new usuarioEntities())
            {
                existe = bdUsuario.USUARIO.Any(usuario => usuario.NAME.Equals(nombre));
            }
            return existe;
        }

        /// <summary>
        /// Inserta un nuevo nombre de usuario en la tabla si no existe.
        /// </summary>
        public void Crea(string nombre)
        {
            if (!Existe(nombre))
            {
                using (usuarioEntities bdUsuario = new usuarioEntities())
                {
                    int claveMasAlta = bdUsuario.USUARIO.Max(usuario => usuario.Clave);

                    USUARIO nuevoUsuario = new USUARIO();


                    nuevoUsuario.Clave = claveMasAlta + 1;
                    nuevoUsuario.NAME = nombre;
                    bdUsuario.USUARIO.Add(nuevoUsuario);
                    bdUsuario.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Devuelve una cadena concatenada con todos los usuario almacenados en la tabla.
        /// </summary>
        public override string ToString()
        {

            StringBuilder str = new StringBuilder();
            using (usuarioEntities bdUsuario = new usuarioEntities())
            {
                bdUsuario.USUARIO.ToList().ForEach(usuario => str.Append("["+usuario.NAME+"]"));
                
            }

            return str.ToString();
        }
    }
}
