
namespace MoneyKind4Opos;

public class CashCountsWriter<TCurrency>
    where TCurrency : ICurrency
{
    protected readonly Dictionary<decimal, int> counts = [];

    public string ToCashCountsString()
    {
        var coinsPart = 
            string.Join(
                ", ",
                TCurrency
                .Coins
                .Select(
                    c => 
                    $"{c.Value}:{counts.GetValueOrDefault(c.Value, 0)}"));
        var billsPart =
            string.Join(
                ", ",
                TCurrency
                .Bills
                .Select(
                    c =>
                    $"{c.Value}:{counts.GetValueOrDefault(c.Value, 0)}"));
        return $"{coinsPart};{billsPart}";
    }
}
