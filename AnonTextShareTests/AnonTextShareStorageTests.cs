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
            Assert.IsTrue(db.UpdateCollectionTitle(col, "judul baru", "password"));
        }

        [TestMethod]
        public void TestUpdateCollectionsTitle_IncorrectPass()
        {
            Assert.IsFalse(db.UpdateCollectionTitle(col, "judul terbaru", "passwordsalah"));
        }
    }
}