using NUnit.Framework;
using Towns;

namespace TownsTests
{
    internal class TownsProcessorTests
    {

        TownsProcessor townProcessor;

        [SetUp]
        public void SetUp()
        {
            this.townProcessor = new TownsProcessor();
        }

        [Test]
        public void Test_Town_Proccessor_Create_Command()
        {
            var result = townProcessor.ExecuteCommand("CREATE");
            Assert.AreEqual(result, "Successfully created collection of towns.");
        }

        [Test]
        public void Test_Town_Proccessor_Print_Command()
        {
            townProcessor.ExecuteCommand("CREATE Sofia, London");
            var result = townProcessor.ExecuteCommand("PRINT");
            Assert.AreEqual(result, "Towns: Sofia, London");
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Town_Proccessor_Reverse_Command()
        {
            townProcessor.ExecuteCommand("CREATE Tokyo, Zimbabwe, Sofia, Hong Kong");
            var result = townProcessor.ExecuteCommand("REVERSE");
            Assert.That(result, Is.EqualTo("Collection of towns reversed."));
        }

        [Test]
        public void Test_Town_Proccessor_Null_Items_In_List_Reverse_Command()
        {
            townProcessor.ExecuteCommand("CREATE ");
            var result = townProcessor.ExecuteCommand("REVERSE");
            Assert.That(result, Is.EqualTo("Cannot reverse a collection of towns with less than 2 items."));
        }

        [Test]
        public void Test_Town_Proccessor_Null_List_Reverse_Command()
        {
            var result = townProcessor.ExecuteCommand("REVERSE");
            Assert.That(result, Is.EqualTo("Cannot reverse a null collection of towns."));
        }

    }
}
