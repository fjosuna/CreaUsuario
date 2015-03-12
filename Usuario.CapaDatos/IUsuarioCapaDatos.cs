using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.CapaDatos
{
    public interface IUsuarioCapaDatos
    {
        void Crea(string nombre);
        string ToString();
    }
}
