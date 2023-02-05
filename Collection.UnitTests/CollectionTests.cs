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
    }
}