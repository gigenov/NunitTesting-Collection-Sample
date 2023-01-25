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

        // Insert tests Radostina

        // Test commit& push to branch

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            Console.WriteLine("TO DO Test_Collection_InsertAtStart");
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            Console.WriteLine("Test_Collection_InsertAtEnd");
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            Console.WriteLine("TO DO Test_Collection_InsertAtMiddle");
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            Console.WriteLine("TO DO Test_Collection_InsertAtWithGrow");
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            Console.WriteLine("TO DO Test_Collection_InsertAtInvalidIndex");
        }

    }
}