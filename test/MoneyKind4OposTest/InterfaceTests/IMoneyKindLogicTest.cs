using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OPOSTest.InterfaceTests;

/// <summary>IMoneyKind tests using Stub implementation.</summary>
public class IMoneyKindLogicTest
{
    /// <summary>Stub Currency</summary>
    private class StubCurrency :
        ICurrency,
        ICashCountFormattable<StubCurrency>,
        ICurrencyFormattable<StubCurrency>
    {
        private static readonly CashFaceInfo[] _coins =
        [
            new(0.05m, CashType.Coin, "5cent coin"),
            new(0.5m, CashType.Coin, "50cent coin"),
            new(1.0m, CashType.Coin, "$1 coin")
        ];

        private static readonly CashFaceInfo[] _bills =
        [
            new(1.0m, CashType.Bill, "$1 bill"),
            new(5.0m, CashType.Bill, "$5 bill"),
            new(10.0m, CashType.Bill, "$10 bill")
        ];

        public static Iso4217 Code => Iso4217.USD;
        public static decimal MinimumUnit => 0.5m;
        public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
            [new SubsidiaryUnit("Cent", "¢", 0.01m)];

        public static IEnumerable<CashFaceInfo> Coins => _coins;
        public static IEnumerable<CashFaceInfo> Bills => _bills;

        public static CurrencyFormattingOptions Global { get; } = new(
            Symbol: "$",
            NumberFormat: NumberFormatInfo.InvariantInfo,
            DisplayFormat: new(
                Placement: SymbolPlacement.Prefix,
                DecimalZeroReplacement: ".",
                GroupSeparator: ",",
                DecimalSeparator: "."
            )
        );

        public static CurrencyFormattingOptions Local => Global;

        public static bool IsZeroPadding => false;
    }

    private class StubMoneyKind : MoneyKind<StubCurrency> { }

    [Fact]
    public void TotalAmount_WithNoCoins_ShouldBeZero()
    {
        var mk = new StubMoneyKind();
        mk.TotalAmount().ShouldBe(0m);
    }

    [Fact]
    public void TotalAmount_WithCoinsAndBills_ShouldSumCorrectly()
    {
        var mk = new StubMoneyKind();
        mk[0.5m] = 2; // 0.5 * 2 = 1.0
        mk[1.0m] = 3; // 1.0 * 3 = 3.0
        mk[5.0m] = 1; // 5.0 * 1 = 5.0

        mk.TotalAmount().ShouldBe(9.0m);
    }

    [Fact]
    public void CoinAmount_ShouldOnlySumCoins()
    {
        var mk = new StubMoneyKind();
        mk[0.5m] = 2; // 0.5 * 2 = 1.0(coin)
        mk[5.0m] = 1; // 5.0(bill)

        mk.CoinAmount().ShouldBe(1.0m);
    }

    [Fact]
    public void CoinAmount_WithNoBills_ShouldEqualTotalAmount()
    {
        var mk = new StubMoneyKind();
        mk[1.0m, CashType.Coin] = 5;

        mk.CoinAmount().ShouldBe(mk.TotalAmount());
    }

    [Fact]
    public void BillAmount_ShouldOnlySumBills()
    {
        var mk = new StubMoneyKind();
        mk[0.5m] = 2;   // 1.0(coin)
        mk[10.0m] = 2;  // 10.0 * 2 = 20.0(bill)

        mk.BillAmount().ShouldBe(20.0m);
    }

    [Fact]
    public void Parse_WithValidString_ShouldRestoreCounts()
    {
        var mk = StubMoneyKind.Parse(".05:3,.50:2,1:10;5:20");

        mk[0.05m].ShouldBe(3);
        mk[0.5m].ShouldBe(2);
        mk[1.0m].ShouldBe(10);
        mk[5.0m].ShouldBe(20);
    }

    [Fact]
    public void Parse_WithEmptyString_ShouldReturnEmptyCounts()
    {
        var mk = StubMoneyKind.Parse("");
        mk.Counts.Count.ShouldBe(0);
    }

    [Fact]
    public void Parse_WithOnlyCoins_ShouldIgnoreBills()
    {
        var mk = StubMoneyKind.Parse("0.5:3");

        mk.Counts.Count.ShouldBe(1);
        mk[0.5m].ShouldBe(3);
    }

    [Fact]
    public void Parse_WithOnlyBills_ShouldIgnoreCoins()
    {
        var mk = StubMoneyKind.Parse(";10:2");

        mk.Counts.Count.ShouldBe(1);
        mk[10.0m].ShouldBe(2);
    }

    [Fact]
    public void Parse_WithUndefinedFace_ShouldIgnoreIt()
    {
        // 999 is undefined face value
        var mk = StubMoneyKind.Parse("0.5:1,999:5;5:1");

        mk.Counts.Count.ShouldBe(2); // 0.5:1 and 5:1
        mk.TotalAmount().ShouldBe(5.5m);
    }

    [Fact]
    public void ToCashCountsString_WithEmptyCounts_ShouldReturnZeros()
    {
        var mk = new StubMoneyKind();
        var result = mk.ToCashCountsString();

        result.ShouldContain(".5:0");
        result.ShouldContain("1:0");
        result.ShouldContain("5:0");
        result.ShouldContain("10:0");
        result.ShouldContain(";");
    }

    [Fact]
    public void ToCashCountsString_WithCounts_ShouldFormatCorrectly()
    {
        var mk = new StubMoneyKind();
        mk[0.5m] = 2;
        mk[5.0m] = 1;

        var result = mk.ToCashCountsString();

        result.ShouldContain(".5:2");
        result.ShouldContain("5:1");
    }

    [Fact]
    public void ToCashCountsString_RoundTrip_ShouldPreserveData()
    {
        var original = new StubMoneyKind();
        original[1.0m] = 3;
        original[10.0m] = 2;

        var serialized = original.ToCashCountsString();
        var restored = StubMoneyKind.Parse(serialized);

        restored.TotalAmount().ShouldBe(original.TotalAmount());
    }

}
