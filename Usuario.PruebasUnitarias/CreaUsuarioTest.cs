using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   using NUnit.Framework;
using Usuario.MiContenedorIoC;
using Usuario.CapaLogicaNegocio;
using Usuario.CapaDatos;

namespace Usuario.PruebasUnitarias
{

    [TestFixture]
    public class CreaUsuarioTest
    {
        MiClaseContenedorIoC miContenedor;

        [SetUp]
        public void Init()
        {
            MiClaseContenedorIoC miContenedor = new MiClaseContenedorIoC();

            // Registramos por CONVENCION todas las clases con su interfaz cuyo Namespace comienze por Usuario
            miContenedor.Registra("Usuario");
        }

        [Test]
        public void TestCreaUsuario()
        {

            UsuarioCapaLogicaNegocio usuarioCapaLogicaNegocio = miContenedor.DameInstancia(typeof(IUsuarioCapaLogicaNegocio)) as UsuarioCapaLogicaNegocio;
            usuarioCapaLogicaNegocio.Init(miContenedor);

            usuarioCapaLogicaNegocio.Crea("a");

            UsuarioCapaDatos usuarioDatos = new UsuarioCapaDatos();
            Assert.IsTrue(usuarioDatos.Existe("a"));

        }
    }
}
