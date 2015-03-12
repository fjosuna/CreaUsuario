using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.MiContenedorIoC
{
    public interface IMiContenedorIoC
    {
        void Registra(string nombreEspacioEmpieza);

        object DameInstancia(Type interfaz);
    }
}
