using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Usuario.CapaDatos
{
    public class UsuarioCapaDatos : IUsuarioCapaDatos
    {
        string[] usuarios={};


        public bool Existe(string nombre)
        {
            bool existe=false;
            using (usuarioEntities bdUsuario = new usuarioEntities())
            {
                existe = bdUsuario.USUARIO.Any(usuario => usuario.NAME.Equals(nombre));
            }
            return existe;
        }

        
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
        public void CreaPrueba(string nombre)
        {
            if (!ExistePrueba(nombre))
            {
                Array.Resize(ref usuarios, usuarios.Length + 1);
                usuarios[usuarios.Length - 1] = nombre;
            }
        }

        public bool ExistePrueba(string nombre)
        {
            bool existe = false;
            foreach (string usuario in usuarios)
            {
                if (usuario.Equals(nombre))
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
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
