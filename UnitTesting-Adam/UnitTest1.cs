namespace UnitTesting_Adam;

[TestClass]
public class UnitTest1
{
    private SimpleDB simpleDB = new SimpleDB();
    string id1, id2;

    [TestInitialize]
    public void Setup()
    {
        this.id1 = simpleDB.CreateDocument("Doc 1", "Gaada isi");
        this.id2 = simpleDB.CreateDocument("Doc 1", "Masih Gaada isi", "12345");
    }

    [TestMethod]
    public void UTA1()
    {
        string id = "165917503";
        Assert.IsTrue(simpleDB.CheckDocument(id1));
    }

    [TestMethod]
    public void UTA2()
    {
        string password = "12345";
        Assert.IsTrue(simpleDB.CheckDocument(id2,password));
    }
}
