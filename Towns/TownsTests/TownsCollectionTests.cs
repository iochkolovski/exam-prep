namespace TownsTests
{
    internal class TownsCollectionTests
    {
        private TownsCollection _townsCollectionOne;
        private TownsCollection _townsCollectionTwo;

        [SetUp]
        public void Setup()
        {
            _townsCollectionOne = new TownsCollection("Sofia");
            _townsCollectionTwo = new TownsCollection("Sofia, London");
        }
        [TearDown]
        public void Teardown()
        {
            _townsCollectionOne.Towns.Clear();
            _townsCollectionTwo.Towns.Clear();
        }

        [Test]
        public void Tets_Constructor_Empty()
        {
            var testCollection = new TownsCollection();
            Assert.That(testCollection.Towns.Count, Is.EqualTo(0));
            Assert.That(testCollection.ToString(), Is.Empty);
        }

        [Test]
        public void Tets_Constructor_Single_Town()
        {
            Assert.That(this._townsCollectionOne.Towns.Count, Is.EqualTo(1));
            Assert.That(this._townsCollectionOne.Towns[0], Is.EqualTo("Sofia"));
        }

        [Test]
        public void Tets_Constructor_Two_Towns()
        {
            Assert.That(this._townsCollectionTwo.Towns.Count, Is.EqualTo(2));
            Assert.That(this._townsCollectionTwo.ToString(), Is.EqualTo("Sofia, London"));
        }

        [Test]
        public void Test_Town_Collection_Add_Method()
        {
            this._townsCollectionOne.Add("Tokyo");
            Assert.That(this._townsCollectionOne.Towns.Count(), Is.EqualTo(2));
            Assert.That(this._townsCollectionOne.ToString(), Is.EqualTo("Sofia, Tokyo"));
        }

        [Test]
        public void Test_Town_Collection_Add_Duplicated_Method()
        {
            var isAdded = this._townsCollectionOne.Add("Sofia");
            Assert.False(isAdded);
        }

        [Test]
        public void Test_Town_Collection_Empty_Town_Add_Method()
        {
            var isAdded = this._townsCollectionOne.Add("");
            Assert.False(isAdded);
        }

        [Test]
        public void Test_Town_Collection_RemoveAt_Method()
        {
            this._townsCollectionTwo.RemoveAt(1);
            Assert.That(this._townsCollectionTwo.Towns.Count(), Is.EqualTo(1));
            Assert.That(this._townsCollectionOne.ToString(), Is.EqualTo("Sofia"));
        }

        [Test]
        public void Test_Town_Collection_OutOfRangeIndex_RemoveAt_Method()
        {
            try
            {
                this._townsCollectionTwo.RemoveAt(50);
            }
            catch(ArgumentOutOfRangeException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Test_Town_Collection_Empty_Reverse_Method()
        {
            try
            {
                this._townsCollectionTwo.Reverse();
            }
            catch (ArgumentNullException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Test_Town_Collection_One_Element_Reverse_Method()
        {
            try
            {
                this._townsCollectionOne.Reverse();
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }
    }
}
