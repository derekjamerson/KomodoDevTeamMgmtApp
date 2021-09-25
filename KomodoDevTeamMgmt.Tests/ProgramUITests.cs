using Program;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoDevTeamMgmt.Tests
{
    [TestClass]
    public class ProgramUITests
    {
        ProgramUI programUI = new ProgramUI();

        //[TestInitialize]
        //public void Arrange()
        //{
        //}

        [TestMethod]
        public void StringToInt_InputIsValid_True()
        {
            int result = programUI.StringToInt("7");
            Assert.IsTrue(result == 7);
        }
    }
}
