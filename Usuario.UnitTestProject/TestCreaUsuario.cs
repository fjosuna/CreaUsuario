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
        public void TestCreaUsuario()
        {

            
            UsuarioCapaLogicaNegocio usuarioCapaLogicaNegocio = miContenedor.DameInstancia(typeof(IUsuarioCapaLogicaNegocio)) as UsuarioCapaLogicaNegocio;
            usuarioCapaLogicaNegocio.Init(miContenedor);

            
            usuarioCapaLogicaNegocio.Crea("a");

            UsuarioCapaDatos usuarioDatos = new UsuarioCapaDatos();
            Assert.IsTrue(usuarioDatos.Existe("a"));

        }
        [TestMethod]
        ///<summary>
        ///
        ///</summary>
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
        public void TestUsuarioVacio()
        {
            UsuarioCapaLogicaNegocio usuarioCapaLogicaNegocio = miContenedor.DameInstancia(typeof(IUsuarioCapaLogicaNegocio)) as UsuarioCapaLogicaNegocio;
            usuarioCapaLogicaNegocio.Init(miContenedor);

            usuarioCapaLogicaNegocio.Crea(" ");
         }
 
    }
}
