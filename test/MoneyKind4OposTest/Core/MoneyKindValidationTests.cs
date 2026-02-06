using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

/// <summary>Validation tests for MoneyKind ICashCountValidatable implementation.</summary>
public class MoneyKindValidationTests
{
    /// <summary>Verifies that IsValidFaceValue correctly identifies valid AUD denominations.</summary>
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
    public void AudIsValidFaceValueWithValidDenominationsShouldReturnTrue(decimal faceValue)
    {
        var mk = new MoneyKind<AudCurrency>();
        mk.IsValidFaceValue(faceValue).ShouldBeTrue();
    }

    /// <summary>Verifies that IsValidFaceValue correctly identifies invalid AUD denominations.</summary>
    [Theory]
    [InlineData(0.03)]
    [InlineData(0.07)]
    [InlineData(3)]
    [InlineData(25)]
    [InlineData(200)]
    public void AudIsValidFaceValueWithInvalidDenominationsShouldReturnFalse(decimal faceValue)
    {
        var mk = new MoneyKind<AudCurrency>();
        mk.IsValidFaceValue(faceValue).ShouldBeFalse();
    }

    /// <summary>Verifies that IsValidCount correctly identifies valid inventory counts (non-negative).</summary>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(1000)]
    [InlineData(int.MaxValue)]
    public void MoneyKindIsValidCountWithValidCountsShouldReturnTrue(int count)
    {
        var mk = new MoneyKind<AudCurrency>();
        mk.IsValidCount(count).ShouldBeTrue();
    }

    /// <summary>Verifies that IsValidCount correctly identifies invalid inventory counts (negative).</summary>
    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(int.MinValue)]
    public void MoneyKindIsValidCountWithInvalidCountsShouldReturnFalse(int count)
    {
        var mk = new MoneyKind<AudCurrency>();
        mk.IsValidCount(count).ShouldBeFalse();
    }

    /// <summary>Verifies that TrySetCashCount succeeds when given a valid denomination and count.</summary>
    [Fact]
    public void AudTrySetCashCountWithValidValuesShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TrySetCashCount(100m, 5, out var error);

        result.ShouldBeTrue();
        error.ShouldBeNull();
        mk[100m].ShouldBe(5);
    }

    /// <summary>Verifies that TrySetCashCount fails when given a denomination not supported by the currency.</summary>
    [Fact]
    public void AudTrySetCashCountWithInvalidDenominationShouldFail()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TrySetCashCount(25m, 3, out var error);

        result.ShouldBeFalse();
        error.ShouldNotBeNull();
        error.ShouldContain("25");
        error.ShouldContain("AUD");
    }

    /// <summary>Verifies that TrySetCashCount fails when given a negative count.</summary>
    [Fact]
    public void MoneyKindTrySetCashCountWithNegativeCountShouldFail()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TrySetCashCount(100m, -5, out var error);

        result.ShouldBeFalse();
        error.ShouldNotBeNull();
        error.ShouldContain("-5");
    }

    /// <summary>Verifies that TrySetCashCount with an explicit CashType parameter succeeds for valid inputs.</summary>
    [Fact]
    public void AudTrySetCashCountWithTypeParameterWithValidValuesShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TrySetCashCount(10m, CashType.Bill, 3, out var error);

        result.ShouldBeTrue();
        error.ShouldBeNull();
        mk[10m, CashType.Bill].ShouldBe(3);
    }

    /// <summary>Verifies that TrySetCashCount fails when the specified CashType does not match the denomination.</summary>
    [Fact]
    public void AudTrySetCashCountWithTypeParameterWithInvalidTypeShouldFail()
    {
        var mk = new MoneyKind<AudCurrency>();

        // 10 is a Bill in AUD, not a Coin
        var result = mk.TrySetCashCount(10m, CashType.Coin, 3, out var error);

        result.ShouldBeFalse();
        error.ShouldNotBeNull();
        error.ShouldContain("10");
        error.ShouldContain(CashType.Coin.ToString());
    }

    /// <summary>Verifies that TryValidateParse identifies a well-formed string as valid without warnings.</summary>
    [Fact]
    public void AudTryValidateParseWithValidStringShouldSucceedWithoutWarnings()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05:10,0.1:5;10:2,50:1";

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldBeEmpty();
    }

    /// <summary>Verifies that TryValidateParse handles an empty string as valid.</summary>
    [Fact]
    public void MoneyKindTryValidateParseWithEmptyStringShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TryValidateParse("", out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldBeEmpty();
    }

    /// <summary>Verifies that TryValidateParse generates a warning when an invalid denomination is encountered.</summary>
    [Fact]
    public void AudTryValidateParseWithInvalidDenominationShouldReturnWarning()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05:10,99:5;10:2"; // 99 is not valid

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldNotBeEmpty();
        warnings.ShouldContain(w => w.Contains("99"));
    }

    /// <summary>Verifies that TryValidateParse generates a warning when a negative count is encountered.</summary>
    [Fact]
    public void MoneyKindTryValidateParseWithNegativeCountShouldReturnWarning()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05:10,0.1:-5;10:2";

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldNotBeEmpty();
        warnings.ShouldContain(w => w.Contains("-5"));
    }

    /// <summary>Verifies that TryValidateParse generates a warning for malformed string formats.</summary>
    [Fact]
    public void MoneyKindTryValidateParseWithMalformedFormatShouldReturnWarning()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05-10,0.1:5;10:2"; // '-' instead of ':'

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldNotBeEmpty();
        warnings.ShouldContain(w => w.Contains("Invalid format"));
    }

    /// <summary>Verifies that TryValidateParse generates warnings for invalid numeric values in the input string.</summary>
    [Theory]
    [InlineData("abc:10;")]
    [InlineData("0.05:xyz;")]
    [InlineData("0.05:1.5;")]
    public void MoneyKindTryValidateParseWithInvalidNumericValuesShouldReturnWarning(string cashCounts)
    {
        var mk = new MoneyKind<AudCurrency>();

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.ShouldNotBeEmpty();
    }

    /// <summary>Verifies that TryValidateParse can return multiple warnings for a single input string.</summary>
    [Fact]
    public void AudTryValidateParseWithMultipleIssuesShouldReturnMultipleWarnings()
    {
        var mk = new MoneyKind<AudCurrency>();
        var cashCounts = "0.05:10,99:5;200:-1,10:2"; // 99 and 200 invalid, -1 negative

        var result = mk.TryValidateParse(cashCounts, out var warnings);

        result.ShouldBeTrue();
        warnings.Count.ShouldBeGreaterThanOrEqualTo(3);
    }

    /// <summary>Verifies that multiple successful calls to TrySetCashCount correctly update the inventory.</summary>
    [Fact]
    public void AudTrySetCashCountMultipleValidCallsShouldSucceed()
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

    /// <summary>Verifies that TrySetCashCount is idempotent or correctly updates existing counts.</summary>
    [Fact]
    public void AudTrySetCashCountIdempotencyShouldUpdateValue()
    {
        var mk = new MoneyKind<AudCurrency>();

        mk.TrySetCashCount(100m, 5, out _).ShouldBeTrue();
        mk[100m].ShouldBe(5);

        mk.TrySetCashCount(100m, 10, out _).ShouldBeTrue();
        mk[100m].ShouldBe(10);
    }

    /// <summary>Verifies that validation logic correctly distinguishes between different currency denomination sets.</summary>
    [Fact]
    public void JpyIsValidFaceValueShouldDifferFromAud()
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