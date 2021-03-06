﻿using MagazineStateImporterBackend.Core.MagazineStateSourceParser.Models;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MagazineStateImporterBackend.Tests
{
    [TestFixture]
    public class MagazineStateImporterTests
    {
        #region SetUp
        private Core.MagazineStateImporter.MagazineStateImporter sut;
        private Mock<Core.Shared.Interfaces.IMapperToDestinationState<MagazineState, MagazineStateSource>> mapperMock;
        private Mock<Core.Shared.Interfaces.IFromSource<MagazineStateSource, ParserInput>> parserMock;

        private List<MagazineState> magazineStates;
        private List<MagazineStateSource> source;

        [SetUp]
        public void Setup()
        {
            magazineStates = new List<MagazineState>()
            {
                new MagazineState()
                {
                   MagazineName = "TestMagazine3"
                },
                new MagazineState()
                {
                   MagazineName = "TestMagazine2"
                },
                new MagazineState()
                {
                    MagazineName = "TestMagazine1"
                }
            };

            magazineStates[2].MaterialsStates.Add(new MaterialState()
            {
                MaterialAmount = 7,
                MaterialId = "TestMaterial2Id"
            });

            magazineStates[2].MaterialsStates.Add(new MaterialState()
            {
                MaterialAmount = 5,
                MaterialId = "TestMaterial1Id"
            });

            magazineStates[0].MaterialsStates.Add(new MaterialState()
            {
                MaterialAmount = 1,
                MaterialId = "TestMaterial3Id"
            });

            magazineStates[1].MaterialsStates.Add(new MaterialState()
            {
                MaterialAmount = 1,
                MaterialId = "TestMaterial2Id"
            });

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



            mapperMock = new Mock<Core.Shared.Interfaces.IMapperToDestinationState<MagazineState, MagazineStateSource>>();
            mapperMock.Setup(m => m.Map(It.IsAny<IEnumerable<MagazineStateSource>>())).Returns(magazineStates);

            parserMock = new Mock<Core.Shared.Interfaces.IFromSource<MagazineStateSource, ParserInput>>();
            parserMock.Setup(m => m.GetDataFromSource(It.IsAny<ParserInput>())).Returns(source);

            sut = new Core.MagazineStateImporter.MagazineStateImporter(mapperMock.Object, parserMock.Object);
        }
        #endregion

        #region GetImportedMagazinesStates
        [Test]
        public void GetImportedMagazinesStates_invokes_GetDataFromSource_and_Map_methods()
        {
            sut.GetImportedMagazinesStates(new Core.MagazineStateImporter.Models.ImporterInput());

            parserMock.Verify(m => m.GetDataFromSource(It.IsAny<ParserInput>()), Times.Once);
            mapperMock.Verify(m => m.Map(source), Times.Once);
        }
        #endregion
    }
}
