using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OposTest.InterfaceTests;

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

    /// <summary>Verifies that the total amount is zero for a newly initialized MoneyKind instance.</summary>
    [Fact]
    public void TotalAmountWithNoCoinsShouldBeZero()
    {
        var mk = new StubMoneyKind();
        mk.TotalAmount().ShouldBe(0m);
    }

    /// <summary>Verifies that the total amount correctly sums all coins and bills across various denominations.</summary>
    [Fact]
    public void TotalAmountWithCoinsAndBillsShouldSumCorrectly()
    {
        var mk = new StubMoneyKind();
        mk[0.5m] = 2; // 0.5 * 2 = 1.0
        mk[1.0m] = 3; // 1.0 * 3 = 3.0
        mk[5.0m] = 1; // 5.0 * 1 = 5.0

        mk.TotalAmount().ShouldBe(9.0m);
    }

    /// <summary>Verifies that CoinAmount returns only the sum of coins, excluding bills.</summary>
    [Fact]
    public void CoinAmountShouldOnlySumCoins()
    {
        var mk = new StubMoneyKind();
        mk[0.5m] = 2; // 0.5 * 2 = 1.0(coin)
        mk[5.0m] = 1; // 5.0(bill)

        mk.CoinAmount().ShouldBe(1.0m);
    }

    /// <summary>Verifies that CoinAmount equals total amount when no bills are present in the inventory.</summary>
    [Fact]
    public void CoinAmountWithNoBillsShouldEqualTotalAmount()
    {
        var mk = new StubMoneyKind();
        mk[1.0m, CashType.Coin] = 5;

        mk.CoinAmount().ShouldBe(mk.TotalAmount());
    }

    /// <summary>Verifies that BillAmount returns only the sum of bills, excluding coins.</summary>
    [Fact]
    public void BillAmountShouldOnlySumBills()
    {
        var mk = new StubMoneyKind();
        mk[0.5m] = 2;   // 1.0(coin)
        mk[10.0m] = 2;  // 10.0 * 2 = 20.0(bill)

        mk.BillAmount().ShouldBe(20.0m);
    }

    /// <summary>Verifies that Parse correctly restores denomination counts from a valid cash-count string.</summary>
    [Fact]
    public void ParseWithValidStringShouldRestoreCounts()
    {
        var mk = StubMoneyKind.Parse(".05:3,.50:2,1:10;5:20");

        mk[0.05m].ShouldBe(3);
        mk[0.05m, CashType.Coin].ShouldBe(3);
        mk[0.5m].ShouldBe(2);
        mk[0.5m, CashType.Coin].ShouldBe(2);
        mk[1.0m].ShouldBe(10);
        mk[1.0m, CashType.Coin].ShouldBe(10);
        mk[5.0m].ShouldBe(20);
        mk[5.0m, CashType.Bill].ShouldBe(20);
    }

    /// <summary>Verifies that Parse returns an empty MoneyKind instance when given an empty string.</summary>
    [Fact]
    public void ParseWithEmptyStringShouldReturnEmptyCounts()
    {
        var mk = StubMoneyKind.Parse("");
        mk.Counts
            .Count(w => w.Value > 0).ShouldBe(0);
    }

    /// <summary>Verifies that Parse correctly processes strings containing only coin definitions.</summary>
    [Fact]
    public void ParseWithOnlyCoinsShouldIgnoreBills()
    {
        var mk = StubMoneyKind.Parse("0.5:3");

        mk.Counts
            .Count(c => c.Value > 0)
            .ShouldBe(1);
        mk[0.5m].ShouldBe(3);
        mk[0.5m, CashType.Coin].ShouldBe(3);
        mk.TotalAmount().ShouldBe(1.5m);
    }

    /// <summary>Verifies that Parse correctly processes strings containing only bill definitions.</summary>
    [Fact]
    public void ParseWithOnlyBillsShouldIgnoreCoins()
    {
        var mk = StubMoneyKind.Parse(";10:2");

        mk.Counts
            .Count(c => c.Value > 0)
            .ShouldBe(1);
        mk[10.0m].ShouldBe(2);
        mk.TotalAmount().ShouldBe(20.0m);
    }

    /// <summary>Verifies parsing accuracy across various legacy, whitespace-heavy, or mixed string formats.</summary>
    [Theory]
    [InlineData("0.5:1,0.5:2", 1.0)]   // Last one wins in current implementation (0.5:2 = 1.0 total)
    [InlineData(" 0.5 : 2 ", 1.0)]    // Whitespace handling
    [InlineData(".5:3", 1.5)]         // Leading dot
    [InlineData("0.5:1,invalid:9,1:1", 1.5)] // Mixed valid/invalid
    [InlineData("0.5:1;1:2", 2.5)]    // Standard mixed
    public void ParseVariousFormatsShouldBeHandledGracefully(string input, decimal expectedTotal)
    {
        var mk = StubMoneyKind.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>Verifies that the parser ignores face values that are not defined in the currency implementation.</summary>
    [Fact]
    public void ParseWithUndefinedFaceShouldIgnoreIt()
    {
        // 999 is undefined face value
        var mk = StubMoneyKind.Parse("0.5:1,999:5;5:1");

        mk.Counts
            .Count(c => c.Value > 0)
            .ShouldBe(2); // 0.5:1 and 5:1
        mk.TotalAmount().ShouldBe(5.5m);
    }

    /// <summary>Verifies that ToCashCountsString produces a valid string with zero counts when inventory is empty.</summary>
    [Fact]
    public void ToCashCountsStringWithEmptyCountsShouldReturnZeros()
    {
        var mk = new StubMoneyKind();
        var result = mk.ToCashCountsString();

        result.ShouldContain(".5:0");
        result.ShouldContain("1:0");
        result.ShouldContain("5:0");
        result.ShouldContain("10:0");
        result.ShouldContain(";");
    }

    /// <summary>Verifies that ToCashCountsString correctly encodes inventory counts into the standard string format.</summary>
    [Fact]
    public void ToCashCountsStringWithCountsShouldFormatCorrectly()
    {
        var mk = new StubMoneyKind();
        mk[0.5m] = 2;
        mk[5.0m] = 1;

        var result = mk.ToCashCountsString();

        result.ShouldContain(".5:2");
        result.ShouldContain("5:1");
    }

    /// <summary>Verifies that data remains consistent after a serialization (ToCashCountsString) and deserialization (Parse) round-trip.</summary>
    [Fact]
    public void ToCashCountsStringRoundTripShouldPreserveData()
    {
        var original = new StubMoneyKind();
        original[1.0m] = 3;
        original[10.0m] = 2;

        var serialized = original.ToCashCountsString();
        var restored = StubMoneyKind.Parse(serialized);

        restored.TotalAmount().ShouldBe(original.TotalAmount());
    }

}
