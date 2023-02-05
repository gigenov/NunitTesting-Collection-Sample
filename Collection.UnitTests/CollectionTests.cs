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

        [Test]
        public void Test_Collection_AddRaange()
        {
            //Arrange and Act
            var coll = new Collection<int>(2, 3, 4);

            coll.AddRange(new[] { 5, 6, 7 });    

            //Assert
            Assert.That(coll.ToString(), Is.EqualTo("[2, 3, 4, 5, 6, 7]"));
        }

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

        [Test]

        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();

            Assert.That(nestedToString,
              Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));
        }

        [TestCase ("Peter,Maria,Ivan", 0,"Peter")]
        [TestCase ("Peter,Maria,Ivan", 01,"Maria")]
        [TestCase ("Peter,Maria,Ivan,,,", 4,"")]
        [TestCase ("Peter,Maria,Ivan,Koko", 3,"Koko")]
        public void Test_Collection_GetByValidIndix(string data, int index, string expected)
        {
            var coll = new Collection<string>(data.Split(","));

            var actual = coll[index];
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}