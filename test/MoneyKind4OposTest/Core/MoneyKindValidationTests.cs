using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>Validation tests for MoneyKind ICashCountValidatable implementation.</summary>
public class MoneyKindValidationTests
{
    /// <summary>IsValidFaceValue tests with valid denominations.</summary>
    [Theory]
    [InlineData(0.05)]
    [InlineData(0.1)]
    [InlineData(0.5)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(50)]
    [InlineData(100)]
    public void Aud_IsValidFaceValue_WithValidDenominations_ShouldReturnTrue(decimal faceValue)
    {
        var mk = new MoneyKind<AudCurrency>();
        mk.IsValidFaceValue(faceValue).ShouldBeTrue();
    }

    /// <summary>IsValidFaceValue tests with invalid denominations.</summary>
    [Theory]
    [InlineData(0.03)]
    [InlineData(0.07)]
    [InlineData(3)]
    [InlineData(25)]
    [InlineData(200)]
    public void Aud_IsValidFaceValue_WithInvalidDenominations_ShouldReturnFalse(decimal faceValue)
    {
        var mk = new MoneyKind<AudCurrency>();
        mk.IsValidFaceValue(faceValue).ShouldBeFalse();
    }

    /// <summary>IsValidCount tests with valid counts.</summary>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(1000)]
    [InlineData(int.MaxValue)]
    public void MoneyKind_IsValidCount_WithValidCounts_ShouldReturnTrue(int count)
    {
        var mk = new MoneyKind<AudCurrency>();
        mk.IsValidCount(count).ShouldBeTrue();
    }

    /// <summary>IsValidCount tests with invalid counts.</summary>
    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(int.MinValue)]
    public void MoneyKind_IsValidCount_WithInvalidCounts_ShouldReturnFalse(int count)
    {
        var mk = new MoneyKind<AudCurrency>();
        mk.IsValidCount(count).ShouldBeFalse();
    }

    /// <summary>TrySetCashCount tests with valid denomination and count.</summary>
    [Fact]
    public void Aud_TrySetCashCount_WithValidValues_ShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TrySetCashCount(100m, 5, out var error);

        result.ShouldBeTrue();
        error.ShouldBeNull();
        mk[100m].ShouldBe(5);
    }

    /// <summary>TrySetCashCount tests with invalid denomination.</summary>
    [Fact]
    public void Aud_TrySetCashCount_WithInvalidDenomination_ShouldFail()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TrySetCashCount(25m, 3, out var error);

        result.ShouldBeFalse();
        error.ShouldNotBeNull();
        error.ShouldContain("25");
        error.ShouldContain("AUD");
    }

    /// <summary>TrySetCashCount tests with negative count.</summary>
    [Fact]
    public void MoneyKind_TrySetCashCount_WithNegativeCount_ShouldFail()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TrySetCashCount(100m, -5, out var error);

        result.ShouldBeFalse();
        error.ShouldNotBeNull();
        error.ShouldContain("-5");
    }

    /// <summary>TrySetCashCount with CashType parameter tests.</summary>
    [Fact]
    public void Aud_TrySetCashCount_WithTypeParameter_WithValidValues_ShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TrySetCashCount(10m, CashType.Bill, 3, out var error);

        result.ShouldBeTrue();
        error.ShouldBeNull();
        mk[10m, CashType.Bill].ShouldBe(3);
    }

    /// <summary>TrySetCashCount with CashType parameter and invalid type combination.</summary>
    [Fact]
    public void Aud_TrySetCashCount_WithTypeParameter_WithInvalidType_ShouldFail()
    {
        var mk = new MoneyKind<AudCurrency>();

        // 10 is a Bill in AUD, not a Coin
        var result = mk.TrySetCashCount(10m, CashType.Coin, 3, out var error);

        result.ShouldBeFalse();
        error.ShouldNotBeNull();
        error.ShouldContain("10");
        error.ShouldContain(CashType.Coin.ToString());
    }

    /// <summary>TryValidateParse tests with valid CashCounts string.</summary>
    [Fact]
    public void Aud_TryValidateParse_WithValidString_ShouldSucceedWithoutWarnings()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05:10,0.1:5;10:2,50:1";

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldBeEmpty();
    }

    /// <summary>TryValidateParse tests with empty string.</summary>
    [Fact]
    public void MoneyKind_TryValidateParse_WithEmptyString_ShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TryValidateParse("", out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldBeEmpty();
    }

    /// <summary>TryValidateParse tests with invalid denomination.</summary>
    [Fact]
    public void Aud_TryValidateParse_WithInvalidDenomination_ShouldReturnWarning()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05:10,99:5;10:2"; // 99 is not valid

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldNotBeEmpty();
        warnings.ShouldContain(w => w.Contains("99"));
    }

    /// <summary>TryValidateParse tests with negative count.</summary>
    [Fact]
    public void MoneyKind_TryValidateParse_WithNegativeCount_ShouldReturnWarning()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05:10,0.1:-5;10:2";

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldNotBeEmpty();
        warnings.ShouldContain(w => w.Contains("-5"));
    }

    /// <summary>TryValidateParse tests with malformed format.</summary>
    [Fact]
    public void MoneyKind_TryValidateParse_WithMalformedFormat_ShouldReturnWarning()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05-10,0.1:5;10:2"; // '-' instead of ':'

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldNotBeEmpty();
        warnings.ShouldContain(w => w.Contains("Invalid format"));
    }

    /// <summary>TryValidateParse tests with invalid numeric values.</summary>
    [Theory]
    [InlineData("abc:10;")]
    [InlineData("0.05:xyz;")]
    [InlineData("0.05:1.5;")]
    public void MoneyKind_TryValidateParse_WithInvalidNumericValues_ShouldReturnWarning(string cashCounts)
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldNotBeEmpty();
    }

    /// <summary>TryValidateParse tests with multiple warnings.</summary>
    [Fact]
    public void Aud_TryValidateParse_WithMultipleIssues_ShouldReturnMultipleWarnings()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05:10,99:5;200:-1,10:2"; // 99 and 200 invalid, -1 negative

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.Count.ShouldBeGreaterThanOrEqualTo(3);
    }

    /// <summary>TrySetCashCount integration test with multiple calls.</summary>
    [Fact]
    public void Aud_TrySetCashCount_MultipleValidCalls_ShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();

        mk.TrySetCashCount(0.05m, 10, out _).ShouldBeTrue();
        mk.TrySetCashCount(1m, 5, out _).ShouldBeTrue();
        mk.TrySetCashCount(10m, 3, out _).ShouldBeTrue();
        mk.TrySetCashCount(100m, 2, out _).ShouldBeTrue();

        mk[0.05m].ShouldBe(10);
        mk[1m].ShouldBe(5);
        mk[10m].ShouldBe(3);
        mk[100m].ShouldBe(2);
    }

    /// <summary>TrySetCashCount idempotency test.</summary>
    [Fact]
    public void Aud_TrySetCashCount_Idempotency_ShouldUpdateValue()
    {
        var mk = new MoneyKind<AudCurrency>();

        mk.TrySetCashCount(100m, 5, out _).ShouldBeTrue();
        mk[100m].ShouldBe(5);

        mk.TrySetCashCount(100m, 10, out _).ShouldBeTrue();
        mk[100m].ShouldBe(10);
    }

    /// <summary>Validation with JPY currency for international support.</summary>
    [Fact]
    public void Jpy_IsValidFaceValue_ShouldDifferFromAud()
    {
        var audMk = new MoneyKind<AudCurrency>();
        var jpyMk = new MoneyKind<JpyCurrency>();

        // AUD has 0.05 as valid, JPY does not
        audMk.IsValidFaceValue(0.05m).ShouldBeTrue();
        jpyMk.IsValidFaceValue(0.05m).ShouldBeFalse();

        // JPY has 1 as valid denomination
        jpyMk.IsValidFaceValue(1m).ShouldBeTrue();
    }
}