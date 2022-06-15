
var inputFile = @"C:\Projects\CreditSuisse\CreditSuisse\Input.txt";
var lines = File.ReadAllLines(inputFile);
var trades = Trade.Build(lines);

foreach (var trade in trades)
{
    Console.WriteLine(trade.Risk);
}