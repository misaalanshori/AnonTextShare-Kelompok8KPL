using AnonTextShareStorage;

namespace AnonTextShareTests
{
    [TestClass]
    public class AnonTextShareStorage_SimpleDB_CollectionTests
    {
        SimpleDB db;
        string col;

        [TestInitialize]
        public void InitTest()
        {
            db = new SimpleDB();
            col = db.CreateCollection("Atitle", new List<string>{ "Hello", "World"}, "password");
        }

        [TestMethod]
        public void TestUpdateCollectionsTitle_CorrectPass()
        {
            db.UpdateCollectionTitle(col, "judul baru", "password");
            Assert.AreEqual("judul baru", db.GetCollectionTitle(col));
        }

        [TestMethod]
        public void TestUpdateCollectionsTitle_IncorrectPass()
        {
            db.UpdateCollectionTitle(col, "judul terbaru", "passwordsalah");
            Assert.AreNotEqual("judul terbaru", db.GetCollectionTitle(col));
        }
    }
}