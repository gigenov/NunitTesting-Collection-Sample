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

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            // Arrange
            var coll = new Collection<int>(3, 5, 6);

            // Act
            coll.RemoveAt(1);

            // Assert
            Assert.AreEqual(coll.ToString(), "[3, 6]");

        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            // Arrange
            var coll = new Collection<int>(3, 5, 6);


            // Act and Assert
            Assert.That(() => { coll.RemoveAt(3); }, Throws.InstanceOf<ArgumentOutOfRangeException>()); 

        }

        [Test]
        public void Test_Collection_RemoveAll()
        {
           

        }

        [Test]
        public void Test_Collection_Clear()
        {
            // Arrange
            var coll = new Collection<int>(3, 5, 6);

            // Act 
            coll.Clear();

            //Assert
            Assert.AreEqual(0, coll.Count);
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            // Arrange
            var coll = new Collection<int>(3, 5, 6);

            //Assert
            Assert.AreEqual(3, coll.Count);
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count) );
        }
    }
}
