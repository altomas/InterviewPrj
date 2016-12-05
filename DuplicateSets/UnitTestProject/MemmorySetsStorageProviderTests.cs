using System;
using System.IO;
using System.Linq;
using DuplicateSets;
using DuplicateSets.Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MemmorySetsStorageProviderTests
    {
        [TestMethod]
        public void CanAddSet()
        {
            //Arrange
            var undertest =  new IntagerSetStorage();

            var set = new int[] {71, 48, 21, 100, 1, 19};

            //ACT
            var result1 = undertest.InputSet(set);
            var result2 = undertest.InputSet(set);

            //ASSERT

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void CanAddOneValueSet()
        {
            //Arrange
            var undertest = new IntagerSetStorage();

            var set = new int[] { 71 };

            //ACT
            var result1 = undertest.InputSet(set);
            var result2 = undertest.InputSet(set);

            //ASSERT

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void EmptySetIsValid()
        {
            // TODO: Clarify with Architect!!!!
            //This I need to clarify with BA and Architect if Empty set is valid or not
            // but technically it is possible to treat it as a regular one

            //Arrange
            var undertest = new IntagerSetStorage();

            var set = new int[] { };

            //ACT
            var result1 = undertest.InputSet(set);
            var result2 = undertest.InputSet(set);

            //ASSERT

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void CanAddSetAsString()
        {
            //Arrange
            var undertest = new IntagerSetStorage();

            var set = "71,48,21,100,1,19";

            //ACT
            var result1 = undertest.InputSet(set);
            var result2 = undertest.InputSet(set);

            //ASSERT

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }



        [TestMethod]
        public void TheSameSetsTest()
        {
            //Arrange
            var undertest = new IntagerSetStorage();

            var set = new int[] { 71, 48, 21, 100, 1, 19 };
            var theSameSet = set;
            var shafledSet = new int[] { 19, 100, 21, 48, 1, 71 };

            //ACT
            var result1 = undertest.InputSet(set);
            var result2 = undertest.InputSet(theSameSet);
            var result3 = undertest.InputSet(shafledSet);



            //ASSERT

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }


        [TestMethod]
        public void SetHasdifferentAmountOfValuesThanExistingTest()
        {
            //Arrange
            var undertest = new IntagerSetStorage();

            var set = new int[] { 71, 48, 21, 100, 1, 19 };

            var extendedFromEndSet = new int[] { 71, 48, 21, 100, 1, 19, 10000 };
            var extendedFromBeginningSet = new int[] { 1000, 71, 48, 21, 100, 1, 19 };
            var cutFromBeginningSet = new int[] { 48, 21, 100, 1, 19 };
            var cutFromEndSet = new int[] { 71, 48, 21, 100, 1 };

            //ACT
            var result1 = undertest.InputSet(set);
            var result2 = undertest.InputSet(extendedFromEndSet);
            var result3 = undertest.InputSet(extendedFromBeginningSet);
            var result4 = undertest.InputSet(cutFromBeginningSet);
            var result5 = undertest.InputSet(cutFromEndSet);


            //ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
            Assert.IsFalse(result5);
        }


        [TestMethod]
        public void CanReturnTheMostFreequentSet()
        {
            //Arrange
            var undertest = new IntagerSetStorage();

            //expected freequent set
            var expected = new[] {"1,2,3,4,5,6", "6,5,4,3,2,1", "3,1,4,6,2,5"};
        

            undertest.InputSet(new int[] {1, 2, 3, 4, 5, 6 });
            undertest.InputSet(new int[] {6, 5, 4, 3, 2, 1 });
            undertest.InputSet(new int[] {3, 1, 4, 6, 2, 5 });

            undertest.InputSet(new int[] { 1, 1, 1, 1, 1, 1 });
            undertest.InputSet(new int[] { 2, 2, 2, 2, 2, 2 });
            undertest.InputSet(new int[] { 71, 48, 21, 100, 1, 19 });

            //ACT
            var result = undertest.Statistics.FreequentSet.Select(i=> string.Join(",", i)).ToArray();

            //ASSERT
            Assert.AreEqual(expected.Length, result.Length);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            
        }

        [TestMethod]
        public void ItCanReturnAmountOfStandaloneAndDuplicateSets()
        {
            //Arrange
            var undertest = new IntagerSetStorage();

            //expected freequent set
            var expected = new[] { "1,2,3,4,5,6", "6,5,4,3,2,1", "3,1,4,6,2,5" };

            int expectedDuplicateSets = 1;


            undertest.InputSet(new int[] { 1, 2, 3, 4, 5, 6 });
            undertest.InputSet(new int[] { 6, 5, 4, 3, 2, 1 });
            undertest.InputSet(new int[] { 3, 1, 4, 6, 2, 5 });

            int expectedStandaloneSets = 3;
            undertest.InputSet(new int[] { 1, 1, 1, 1, 1, 1 });
            undertest.InputSet(new int[] { 2, 2, 2, 2, 2, 2 });
            undertest.InputSet(new int[] { 71, 48, 21, 100, 1, 19 });

            //ACT
            var result = undertest.Statistics.FreequentSet.Select(i => string.Join(",", i)).ToArray();

            //ASSERT
            Assert.AreEqual(expectedDuplicateSets, undertest.Statistics.DuplicatesCount);
            Assert.AreEqual(expectedStandaloneSets, undertest.Statistics.NonDuplicatesCount);

        }

        [TestMethod]
        public void InvalidSetIsRegistered()
        {
            //Arrange
            var undertest = new IntagerSetStorage();
            string invalidSet = "1,2,3d,4";

            //Act
            var res = undertest.InputSet(invalidSet);

            //Assert
            Assert.IsFalse(res);
            Assert.AreEqual(invalidSet, undertest.Statistics.InvalidSets.First());

        }

        [TestMethod]
        public void TestAgainstFileDataSet()
        {
            //Arrange
            var undertest = new IntagerSetStorage();

            string line;
            var inputsFile = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
            if (!File.Exists(inputsFile))
            {
                Assert.Fail($"{inputsFile} does not exist");
            }

            System.IO.StreamReader file = File.OpenText(inputsFile);

            //ACT
            while ((line = file.ReadLine()) != null)
            {
                undertest.InputSet(line);
            }

            file.Close();

            undertest.AcceptVisitor(new SimpleConsoleReporting());
        }

    }
}
