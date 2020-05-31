using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Tests.MapperToMagazineState
{
    [TestFixture]
    public class MapperToMagazineStateTests
    {
        #region SetUp
        private Core.MapperToMagazineState.MapperToMagazineState sut;
        private static List<MagazineStateSource> emptySource;
        private List<MagazineStateSource> source;

        [SetUp]
        public void Setup()
        {
            sut = new Core.MapperToMagazineState.MapperToMagazineState();
            emptySource = new List<MagazineStateSource>();
            source = new List<MagazineStateSource>()
            {
                new MagazineStateSource()
                {
                    MaterialId = "TestMaterialId1",
                    MaterialName = "TestMaterial1",
                    AmoutsPerMagazine = new List<MaterialAmoutPerMagazine>()
                    {
                        new MaterialAmoutPerMagazine().InMagazine("TestMagazine1").IsAmoutOf(4),
                        new MaterialAmoutPerMagazine().InMagazine("TestMagazine2").IsAmoutOf(15)
                    }
                },
                new MagazineStateSource()
                {
                    MaterialId = "TestMaterialId2",
                    MaterialName = "TestMaterial2",
                    AmoutsPerMagazine = new List<MaterialAmoutPerMagazine>()
                    {
                        new MaterialAmoutPerMagazine().InMagazine("TestMagazine1").IsAmoutOf(5),
                        new MaterialAmoutPerMagazine().InMagazine("TestMagazine3").IsAmoutOf(6)
                    }
                }
            };
        }
        #endregion

        #region Map
        [Test]
        public void Map_returns_the_collection_of_states_when_source_is_available()
        {
            //Act
            IEnumerable<MagazineState> states = sut.Map(source);

            //Assert
            Assert.IsNotNull(states);
            Assert.AreEqual(3, states.Count());

            Assert.AreEqual("TestMagazine1", states.ElementAt(0).MagazineName);

            Assert.AreEqual(2, states.ElementAt(0).MaterialsStates.Count);
            Assert.AreEqual("TestMaterialId1", states.ElementAt(0).MaterialsStates[0].MaterialId);
            Assert.AreEqual(4, states.ElementAt(0).MaterialsStates[0].MaterialAmout);
            Assert.AreEqual("TestMaterialId2", states.ElementAt(0).MaterialsStates[1].MaterialId);
            Assert.AreEqual(5, states.ElementAt(0).MaterialsStates[1].MaterialAmout);

            Assert.AreEqual("TestMagazine2", states.ElementAt(1).MagazineName);

            Assert.AreEqual(1, states.ElementAt(1).MaterialsStates.Count);
            Assert.AreEqual("TestMaterialId1", states.ElementAt(1).MaterialsStates[0].MaterialId);
            Assert.AreEqual(15, states.ElementAt(1).MaterialsStates[0].MaterialAmout);

            Assert.AreEqual("TestMagazine3", states.ElementAt(2).MagazineName);

            Assert.AreEqual(1, states.ElementAt(2).MaterialsStates.Count);
            Assert.AreEqual("TestMaterialId2", states.ElementAt(2).MaterialsStates[0].MaterialId);
            Assert.AreEqual(6, states.ElementAt(2).MaterialsStates[0].MaterialAmout);
        }

        [Test]
        [TestCase(null)]
        [TestCaseSource("emptySource")]
        public void Map_throws_ArgumentNullException_when_isource_is_null_or_empty(IEnumerable<MagazineStateSource> source)
        {
            Assert.Throws<ArgumentNullException>(() => sut.Map(source));
        }
        #endregion
    }
}
