using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Tests.Shared.Models.MagazineState
{
    [TestFixture]
    public class MagazineStateTests
    {
        #region SetUp
        private Core.Shared.Models.MagazineState.MagazineState sut;

        [SetUp]
        public void Setup()
        {
            sut = new Core.Shared.Models.MagazineState.MagazineState();
        }
        #endregion

        #region MaterialsAmout
        [Test]
        public void MaterialsAmout_returns_sum_of_materials_amouts()
        {
            //Arrange
            sut.MaterialsStates.Add(new Core.Shared.Models.MagazineState.MaterialState()
            {
                MaterialAmout = 5,
                MaterialId = "TestMaterial1Id"
            });
            sut.MaterialsStates.Add(new Core.Shared.Models.MagazineState.MaterialState()
            {
                MaterialAmout = 7,
                MaterialId = "TestMaterial2Id"
            });

            //Act && Assert
            Assert.AreEqual(12, sut.MaterialsAmout);
        }
        #endregion
    }
}
