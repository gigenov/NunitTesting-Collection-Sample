using Collections;
using System.Threading.Channels;

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

        // Unit tests Insert Method Radostina
        [Test]
        public void Test_Collection_InsertAtStart()
        {
            // Arrange
            var coll = new Collection<int>(1, 2, 3);

            // Act

            coll.InsertAt(0, 0);
            var actual = coll.ToString();
            var expected = "[0, 1, 2, 3]";

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            // Arrange
            var coll = new Collection<string>("Ivan", "Peter", "Maria");

            // Act

            coll.InsertAt(2, "Angel");
            var actual = coll.ToString();
            var expected = "[Ivan, Peter, Angel, Maria]";

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            // Arrange
            var coll = new Collection<double>(1, 2, 3);

            // Act

            coll.InsertAt(1, 1.5);
            var actual = coll.ToString();
            var expected = "[1, 1,5, 2, 3]";

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        // Unit tests Collection Initialisation
        [Test]
        public void Test_Collection_Initialisation_CountAndCapacity()
        {
            // Arrange and Act
            var coll = new Collection<int>();

            // Assert
            Assert.That(coll.Count, Is.EqualTo(0));
            Assert.That(coll.Capacity, Is.EqualTo(16));
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            // Arrange
            var coll = new Collection<int>(1, 2, 3, 4);
            var odlCapacity = coll.Capacity;
            int num = 0;

            // Act

            for (int i = 0; i < 13; i++)
            {
                coll.InsertAt(0, num);
                num--;
            }
            var actual = coll.ToString();
            var expected = "[-12, -11, -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4]";
            var newCapacity = coll.Capacity;

            // Assert
            Assert.That(expected, Is.EqualTo(actual), "Assertion on the collection");
            Assert.That(coll.Count, Is.GreaterThan(odlCapacity), "Collection count is grater than old capacity");
            Assert.That(odlCapacity, Is.EqualTo(16), "Old Capacity");
            Assert.That(newCapacity, Is.EqualTo(32), "New Capacity");
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            // Arrange
            var coll = new Collection<string>("Ivan", "Peter", "Maria");

            // Act and Assert
            Assert.That(() => coll.InsertAt(10, "Angel"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCase("1,2,3", 0, "0", "[0, 1, 2, 3]")]
        [TestCase("1,2,3", 2, "333", "[1, 2, 333, 3]")]
        [TestCase("", 0, "100", "[100]")]
        [TestCase("Ivan,Peter,Maria", 1, "Angel", "[Ivan, Angel, Peter, Maria]")]
        public void Test_Collection_InsertItemDDT(string data, int index, string item, string expected)
        {
            // Arrange
            var coll = new Collection<string>(data.Split(",", StringSplitOptions.RemoveEmptyEntries));
            
            // Act
            coll.InsertAt(index, item);
            var actual = coll.ToString();

            // Assert
            Assert.That(expected, Is.EqualTo(actual));

        }

        [TestCase("Peter", 10, "Ivan")]
        [TestCase("Peter,Maria, Ivan", 5, "Angel")]
        [TestCase("Peter,Maria, Ivan", -1, "Angel")]
        [TestCase("", 1, "Angel")]
        public void Test_Collection_InsertAtInvalidIndexDDT(string data, int index, string item)
        {
            var coll = new Collection<string>(data.Split(",", StringSplitOptions.RemoveEmptyEntries));

            Assert.That(() => coll.InsertAt(index, item), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}