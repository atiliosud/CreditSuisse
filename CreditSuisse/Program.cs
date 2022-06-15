
using CreditSuisse.TraidDomain;

var inputFile = @"C:\Projects\CreditSuisse\CreditSuisse\Input.txt";
var trades = Trade.Build(inputFile);

foreach (var trade in trades)
{
    Console.WriteLine(trade.Risk);
}