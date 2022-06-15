namespace CreditSuisse.TraidDomain;

public class Trade : ITrade
{
    public double Value { get; }

    public string ClientSector { get; }

    public DateTime NextPaymentDate { get; }

    private DateTime ReferenceDate { get; }

    public string Risk => (Value, ClientSector, NextPaymentDate) switch
    {
        (_, _, DateTime nextPaymentDate)
        when ReferenceDate.Subtract(nextPaymentDate).Days > 30 => "EXPIRED",
        (double value, string clientSector, _) when value > 1000000 && clientSector == "Private" => "HIGHRISK",
        (double value, string clientSector, _) when value > 1000000 && clientSector == "Public" => "MEDIUMRISK",
        _ => "NORISK"
    };

    public Trade(double value, string clientSector, DateTime nextPaymentDate, DateTime referenceDate)
    {
        Value = value;
        ClientSector = clientSector;
        NextPaymentDate = nextPaymentDate;
        ReferenceDate = referenceDate;
    }
    
    public static Trade[] Build(string file)
    {
        var lines = File.ReadAllLines(file);
        var referenceDate = DateTime.Parse(lines[0]);
        var remaningLines = lines.Skip(2).ToArray();

        return remaningLines.Select(line => ConvertFromString(line, referenceDate)).ToArray();
    }

    private static Trade ConvertFromString(string input, DateTime referenceDate)
    {
        var parts = input.Split(' ');

        var value = double.Parse(parts[0]);
        var clientSector = parts[1];
        var nextPaymentDate = DateTime.Parse(parts[2]);

        return new Trade(value, clientSector, nextPaymentDate, referenceDate);
    }
}