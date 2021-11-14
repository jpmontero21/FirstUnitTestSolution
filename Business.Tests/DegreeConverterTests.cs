using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Tests
{
    [TestFixture]
    public class DegreeConverterTests
    {
        /*
         EXAMPLE
        SetUp method, basicamente cre el setUp del ambiente de pruebas, por ejemplo si comparten el mismo objeto, para que todas las pruebas puedan usarlo sin cambiar la instancia 
        lo que podria generar que las pruebas se "jodan" entre si

        TearDown, es el dispose the las pruebas, basicamente, limpiar el objecto compartido

        Las versiones OneTimeSetUp/TearDown, corren por assebly y/o por Namespace , las @normales@ corren por clase
         */

        //Field Object _obj;
        [SetUp]
        public void SetUp()
        {
            //Create the object 
            //_obj = new Object();
        }

        [TearDown]
        public void TearDown()
        {
            //_obj.Dispose();
            //_obj = null;
        }


        [Test]
        public void ToCelsius_1_Returns_M17_22()
        {
            double result = new DegreeConverter().ToCelsius(1);
            Assert.That(result, Is.EqualTo(-17.222222222222221));
        }

        [Test]
        public void ToCelsius_50_Returns10()
        {
            double result = new DegreeConverter().ToCelsius(50);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void ToFahrenheit_0_Returns32()
        {
            double result = new DegreeConverter().ToFahrenheit(0.0);
            Assert.That(result, Is.EqualTo(32));
        }

        [Test]
        public void ToFahrenheit_25_Returns77()
        {
            double result = new DegreeConverter().ToFahrenheit(25);
            Assert.That(result, Is.EqualTo(77));
        }
    }
}
