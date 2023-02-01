using Collections;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

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

        //Unit Tests from Boyan

        [Test]
        public void Test_Collection_GetByIndex()
        {
            //Arrange and act
            var coll = new Collection<int>(3, 6, 9);
            var item = coll[1];

            //Assert
            Assert.That(item.ToString(), Is.EqualTo("6"));   
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            //Arrange and act
            var coll = new Collection<int>(6, 9);

            //Assert
            Assert.That(() => { var item = coll[2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex_2()
        {
            var names = new Collection<string>("Bob", "Joe");
            Assert.That(() => { var name = names[-1]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[2]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Bob, Joe]"));
        }

        
        //public void Test_Collection_SetByIndex(){ … }
        //public void Test_Collection_SetByInvalidIndex() { … }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }


    }
}