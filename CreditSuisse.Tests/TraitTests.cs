using CreditSuisse.TraidDomain;

using System.Text;

namespace CreditSuisse.Tests;

public class TraitTests
{

    [Test]
    public void Test1()
    {
        var content = new string[]
        {
            "12/11/2021",
            "3",
            "2000000 Private 12/20/2022",
            "5000000 Public 06/12/2022",
            "300000 Private 07/01/2019"
        };

        var tempFile = Path.GetTempFileName();
        File.WriteAllLines(tempFile, content, Encoding.UTF8);

        
        try
        {
            var trades = Trade.Build(tempFile);

            CollectionAssert.AllItemsAreNotNull(trades);
            Assert.That(trades.Length, Is.EqualTo(3));
            Assert.That(trades[0].Risk, Is.EqualTo("HIGHRISK"));
            Assert.That(trades[1].Risk, Is.EqualTo("MEDIUMRISK"));
            Assert.That(trades[2].Risk, Is.EqualTo("EXPIRED"));
        }
        catch
        {
        }
        finally
        {
            File.Delete(tempFile);
        }


    }
}