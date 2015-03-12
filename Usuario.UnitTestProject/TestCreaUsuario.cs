using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Usuario.CapaLogicaNegocio;
using Usuario.CapaDatos;
using Usuario.MiContenedorIoC;

namespace Usuario.UnitTestProject
{

    [TestClass]
    public class UnitTest
    {
        private MiClaseContenedorIoC miContenedor = new MiClaseContenedorIoC();

        public UnitTest()
        {
            // Registramos por CONVENCION todas las clases con su interfaz cuyo Namespace comienze por Usuario
            miContenedor.Registra("Usuario");
            miContenedor.RegistraTest(typeof(IUsuarioCapaDatos), typeof(UsuarioCapaDatos));
            miContenedor.RegistraTest(typeof(IUsuarioCapaLogicaNegocio), typeof(UsuarioCapaLogicaNegocio));



        }

        [TestMethod]
        /// <summary>
        /// Comprueba que se crea el usuario correctamente.
        /// </summary>
        public void TestCreaUsuario()
        {
            UsuarioCapaLogicaNegocio usuarioCapaLogicaNegocio = miContenedor.DameInstancia(typeof(IUsuarioCapaLogicaNegocio)) as UsuarioCapaLogicaNegocio;
            usuarioCapaLogicaNegocio.Init(miContenedor);

            usuarioCapaLogicaNegocio.Crea("a");
            
            UsuarioCapaDatos usuarioDatos = new UsuarioCapaDatos();
            Assert.IsTrue(usuarioDatos.Existe("a"));

        }
        [TestMethod]
        /// <summary>
        /// Comprueba que la inserccion del usuario no es sensible a mayuscula/minusculas -> Debe de fallar porque no lo es
        /// .
        /// </summary>
        public void TestCreaUsuarioSensibleMinusculas()
        {

            UsuarioCapaLogicaNegocio usuarioCapaLogicaNegocio = miContenedor.DameInstancia(typeof(IUsuarioCapaLogicaNegocio)) as UsuarioCapaLogicaNegocio;
            usuarioCapaLogicaNegocio.Init(miContenedor);


            UsuarioCapaDatos usuarioDatos = new UsuarioCapaDatos();

            Assert.IsFalse(usuarioDatos.Existe("x"));
            usuarioCapaLogicaNegocio.Crea("X");
            Assert.IsFalse(usuarioDatos.Existe("x"));


        }

        [TestMethod]
        [ExpectedException(typeof(Usuario.MisExcepciones.UsuarioVacioException))]
        /// <summary>
        /// Comprueba que se devuelve una excepcion al intentar crear un usuario vacio
        /// 
        /// 
        /// </summary>
        public void TestUsuarioVacio()
        {
            UsuarioCapaLogicaNegocio usuarioCapaLogicaNegocio = miContenedor.DameInstancia(typeof(IUsuarioCapaLogicaNegocio)) as UsuarioCapaLogicaNegocio;
            usuarioCapaLogicaNegocio.Init(miContenedor);

            usuarioCapaLogicaNegocio.Crea(" ");
         }
 
    }
}
