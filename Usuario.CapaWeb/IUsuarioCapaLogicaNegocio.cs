using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.MiContenedorIoC;

namespace Usuario.CapaLogicaNegocio
{
    public interface IUsuarioCapaLogicaNegocio
    {
        void Crea(string nombre);
        void Init(IMiContenedorIoC miContenederIoC);
        string ToString();
    }
}
