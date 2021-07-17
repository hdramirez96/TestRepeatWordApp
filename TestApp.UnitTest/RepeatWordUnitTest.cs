using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestApp.Core.DTOs;
using TestApp.Core.Services;

namespace TestApp.UnitTest
{
    [TestClass]
    public class RepeatWordUnitTest
    {
        [TestMethod]
        public void GetSuccess()
        {
            var repeatWordDto = new RepeatWordDTO
            {
                Text = "Este es una prueba unitaria. y con caracteres / especiales *",
                Word = "Unitaria",
                Count = 0
            };
            var expected = 1;
            var response = new RepeatWordService().Get(repeatWordDto);
            Assert.AreEqual(expected, response.Count);
        }

        [TestMethod]
        public void GetWordIsRequired_ThrowsException()
        {
            var repeatWordDto = new RepeatWordDTO
            {
                Text = "Este es una prueba unitaria. y con caracteres / especiales *",
                Word = "",
                Count = 0
            };
            Assert.ThrowsException<ArgumentException>(() => new RepeatWordService().Get(repeatWordDto));
        }
    }
}
