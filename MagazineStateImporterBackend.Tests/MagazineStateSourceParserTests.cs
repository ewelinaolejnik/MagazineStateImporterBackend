using MagazineStateImporterBackend.Core.MagazineStateSourceParser.Models;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Tests
{
    [TestFixture]
    public class MagazineStateSourceParserTests
    {
        #region SetUp
        private Core.MagazineStateSourceParser.MagazineStateSourceParser sut;
        public static IEnumerable InvalidParserInput
        {
            get
            {
                yield return new ParserInput() { UnparsedStates = null };
                yield return new ParserInput() { UnparsedStates = new List<string>() };
            }
        }

        public static IEnumerable ValidParserInput
        {
            get
            {
                yield return new ParserInput()
                {
                    UnparsedStates = new List<string>()
                {
                    "# New materials",
                    "Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10",
                    "Maple Dovetail Drawerbox;COM-124047;WH-A,15"
                }
                };
                yield return new ParserInput() { UnparsedStates = new List<string>() 
                {
                    "Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10",
                    "Maple Dovetail Drawerbox;COM-124047;WH-A,15"
                } };
            }
        }

        [SetUp]
        public void Setup()
        {
            sut = new Core.MagazineStateSourceParser.MagazineStateSourceParser();
        }
        #endregion

        #region Parse
        [Test]
        public void Parse_returns_the_source_when_input_is_valid()
        {
            //Arrange
            string validInput = "Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10";

            //Act
            MagazineStateSource magazineStateSource = sut.Parse(validInput);

            //Assert
            Assert.IsNotNull(magazineStateSource);
            Assert.AreEqual("COM-100001", magazineStateSource.MaterialId);
            Assert.AreEqual("Cherry Hardwood Arched Door - PS", magazineStateSource.MaterialName);
            Assert.AreEqual(2, magazineStateSource.AmoutsPerMagazine.Count);

            Assert.AreEqual("WH-A", magazineStateSource.AmoutsPerMagazine[0].MagazineName);
            Assert.AreEqual(5, magazineStateSource.AmoutsPerMagazine[0].Amout);

            Assert.AreEqual("WH-B", magazineStateSource.AmoutsPerMagazine[1].MagazineName);
            Assert.AreEqual(10, magazineStateSource.AmoutsPerMagazine[1].Amout);
        }

        [Test]
        public void Parse_returns_the_source_when_input_has_one_magazine()
        {
            //Arrange
            string validInput = "Maple Dovetail Drawerbox;COM-124047;WH-A,15";

            //Act
            MagazineStateSource magazineStateSource = sut.Parse(validInput);

            //Assert
            Assert.IsNotNull(magazineStateSource);
            Assert.AreEqual("COM-124047", magazineStateSource.MaterialId);
            Assert.AreEqual("Maple Dovetail Drawerbox", magazineStateSource.MaterialName);
            Assert.AreEqual(1, magazineStateSource.AmoutsPerMagazine.Count);

            Assert.AreEqual("WH-A", magazineStateSource.AmoutsPerMagazine[0].MagazineName);
            Assert.AreEqual(15, magazineStateSource.AmoutsPerMagazine[0].Amout);
        }

        [Test]
        [TestCase("TestMaterial TestMaterialId;Magazine1,5|Magazine2,10")]
        [TestCase("TestMaterial;TestMaterialId Magazine1,5|Magazine2,10")]
        [TestCase("TestMaterial;TestMaterialId;Magazine1,5 Magazine2,10")]
        [TestCase("TestMaterial;TestMaterialId;Magazine1 5|Magazine2 10")]
        public void Parse_throws_exception_when_input_has_not_each_required_character(string invalidInput)
        {
            Assert.That(() => sut.Parse(invalidInput), Throws.InstanceOf<Exception>());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Parse_throws_ArgumentNullException_when_input_is_null_or_empty(string emptyInput)
        {
            Assert.Throws<ArgumentNullException>(() => sut.Parse(emptyInput));
        }

        [Test]
        public void Parse_throws_FormatException_when_amout_is_not_number()
        {
            //Arrange
            string invalidInput = "TestMaterial;TestMaterialId;Magazine1,5|Magazine2,ten";

            //Act && Assert
            Assert.Throws<FormatException>(() => sut.Parse(invalidInput));
        }

        #endregion

        #region GetDataFromSource
        [Test]
        [TestCaseSource("ValidParserInput")]
        public void GetDataFromSource_returns_collection_of_sources_when_input_is_valid(ParserInput input)
        {
            //Act
            var result = sut.GetDataFromSource(input);

            //Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        [TestCase(null)]
        [TestCaseSource("InvalidParserInput")]
        public void GetDataFromSource_throws_ArgumentNullException_when_input_is_null_or_empty(ParserInput input)
        {
            Assert.Throws<ArgumentNullException>(() => sut.GetDataFromSource(input));
        }
        #endregion
    }
}
