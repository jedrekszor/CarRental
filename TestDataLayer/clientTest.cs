using DataLayer.Data;
using NUnit.Framework;

namespace TestDataLayer
{
    [TestFixture]
    public class ClientTest
    {
        [Test]
        public void DefaultConstructorTest()
        {
            Client client = new Client();

            Assert.AreEqual(client.Id, "cccl");
            Assert.AreEqual(client.Name, "client_name");
            Assert.AreEqual(client.Surname, "client_surname");
            Assert.AreEqual(client.LicNo, "client_licNo");
            Assert.AreEqual(client.Age, 0);
        }

        [Test]
        public void CustomConstructorTest()
        {
            Client client = new Client("name", "surname", "licNo", 30);

            Assert.AreEqual(client.Id, "nsli");
            Assert.AreEqual(client.Name, "name");
            Assert.AreEqual(client.Surname, "surname");
            Assert.AreEqual(client.LicNo, "licNo");
            Assert.AreEqual(client.Age, 30);
        }

        [Test]
        public void SetterAgeTest()
        {
            //                Client client = new Client("test1", "test2", "test3", 30);
            //                DbManager manager = new DbManager(Path);
            //
            //                manager.AddClient(client);
            //                client.Age = 35;
            //                
            //                Assert.AreEqual( 35, client.Age);
            //                Assert.AreEqual( 35, manager.GetClient(client.Id).Age);
        }
    }
}