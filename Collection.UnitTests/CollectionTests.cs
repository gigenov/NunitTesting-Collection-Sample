using Collections;

namespace Collection.UnitTests
{
    public class CollectionTests
    {

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //Arrange and Act
            var coll = new Collection<int>();

            //Assert
            Assert.AreEqual(coll.ToString(), "[]");
        }

        //Unit Tests from Georgi
        
        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            //Arrange and Act
            var coll = new Collection<int>();

            //Assert
            Assert.That(coll.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            //Arrange and Act
            var coll = new Collection<int>(432);

            //Assert
            Assert.That(coll.ToString(), Is.EqualTo("[432]"));
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            //Arrange and Act
            var coll = new Collection<int>(2, 3, 4);

            //Assert
            Assert.That(coll.ToString(), Is.EqualTo("[2, 3, 4]"));
        }
        //Test Ani//
        public void Test_Collection_ConstructorSingleItem()
        {
            var coll = new Collection<int>(5);

            var actual = coll.ToString();
            var expected = "[5]";

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var coll = new Collection<int>(5, 6);
            Assert.AreEqual(coll.ToString(), "[5, 6]");

        }
        [Test]


        public void Test_Collection_Add()
        {
            //Arrange
            var coll = new Collection<string>("Ani", "Tedi");

            //Act
            coll.Add("Joro");

            //Assert
            Assert.AreEqual(coll.ToString(), "[Ani, Tedi, Joro]");
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var coll = new Collection<string>("Ani", "Tedi");

            coll.AddRange("Tea");

            Assert.AreEqual(coll.ToString(), "[Ani, Tedi, Tea]");
        }
        [Test]
        public void Test_Collection_AddRange()
        {

        }
    }
}