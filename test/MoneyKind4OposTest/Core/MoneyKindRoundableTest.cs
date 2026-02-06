using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>Tests for MoneyKind IMoneyKindRoundable implementation.</summary>
public class MoneyKindRoundableTest
{
    /// <summary>RoundToMinimumUnit tests with AUD (MinimumUnit = 0.05).</summary>
    [Theory]
    [InlineData(100.00, MidpointRounding.ToEven, 100.00)]
    [InlineData(100.01, MidpointRounding.ToEven, 100.00)]
    [InlineData(100.02, MidpointRounding.ToEven, 100.00)]
    [InlineData(100.03, MidpointRounding.ToEven, 100.05)]
    [InlineData(100.04, MidpointRounding.ToEven, 100.05)]
    [InlineData(100.025, MidpointRounding.ToEven, 100.00)]
    [InlineData(100.035, MidpointRounding.ToEven, 100.05)]
    public void AudRoundToMinimumUnitWithToEvenShouldRoundCorrectly(
        decimal amount, MidpointRounding rounding, decimal expected)
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.RoundToMinimumUnit(amount, rounding);
        
        result.ShouldBe(expected);
    }

    /// <summary>Negative value tests for standard Rounding with AUD.</summary>
    [Theory]
    [InlineData(-100.01, MidpointRounding.AwayFromZero, -100.00)] // -2000.2 -> -2000 (Nearest)
    [InlineData(-100.04, MidpointRounding.ToZero, -100.00)]      // -2000.8 -> -2000 (ToZero)
    [InlineData(-100.03, MidpointRounding.ToEven, -100.05)]      // -2000.6 -> -2001 (Nearest)
    public void AudRoundToMinimumUnitNegativeShouldRoundCorrectly(
        decimal amount, MidpointRounding rounding, decimal expected)
    {
        var mk = new MoneyKind<AudCurrency>();
        var result = mk.RoundToMinimumUnit(amount, rounding);
        result.ShouldBe(expected);
    }

    /// <summary>RoundToMinimumUnit tests with AwayFromZero mode.</summary>
    [Theory]
    [InlineData(100.01, 100.00)] // 2000.2 -> 2000 (Nearest)
    [InlineData(100.02, 100.00)]
    [InlineData(100.03, 100.05)] // 2000.6 -> 2001 (Nearest)
    [InlineData(100.04, 100.05)]
    [InlineData(100.025, 100.05)] // Midpoint -> AwayFromZero
    public void AudRoundToMinimumUnitWithAwayFromZeroShouldRoundCorrectly(
        decimal amount, decimal expected)
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.RoundToMinimumUnit(amount, MidpointRounding.AwayFromZero);
        
        result.ShouldBe(expected);
    }

    /// <summary>RoundToMinimumUnit tests with TowardZero mode.</summary>
    [Theory]
    [InlineData(100.04, 100.00)]
    [InlineData(100.075, 100.05)]
    [InlineData(100.099, 100.05)]
    public void AudRoundToMinimumUnitWithTowardZeroShouldRoundDown(
        decimal amount, decimal expected)
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.RoundToMinimumUnit(amount, MidpointRounding.ToZero);
        
        result.ShouldBe(expected);
    }

    /// <summary>RoundToMinimumUnit tests with JPY (MinimumUnit = 1).</summary>
    [Theory]
    [InlineData(1000.00, MidpointRounding.ToEven, 1000.00)]
    [InlineData(1000.5, MidpointRounding.AwayFromZero, 1001.00)]
    [InlineData(1000.4, MidpointRounding.ToZero, 1000.00)]
    public void JpyRoundToMinimumUnitWithIntegerMinimumUnitShouldRound(
        decimal amount,
        MidpointRounding rounding,
        decimal expected)
    {
        var mk = new MoneyKind<JpyCurrency>();
        
        var result = mk
            .RoundToMinimumUnit(
                amount,
                rounding);
        
        result.ShouldBe(expected);
    }

    /// <summary>Standard integer-scale Rounding tests using JPY.</summary>
    [Theory]
    [InlineData(-1.2, MidpointRounding.AwayFromZero, -1.0)]
    [InlineData(-1.8, MidpointRounding.ToZero, -1.0)]
    [InlineData(-1.5, MidpointRounding.ToEven, -2.0)]
    [InlineData(-2.5, MidpointRounding.ToEven, -2.0)]
    [InlineData(1.2, MidpointRounding.AwayFromZero, 1.0)]
    [InlineData(1.8, MidpointRounding.ToZero, 1.0)]
    public void JpyRoundToMinimumUnitStandardShouldRoundExactly(
        decimal amount, MidpointRounding rounding, decimal expected)
    {
        var mk = new MoneyKind<JpyCurrency>();
        var result = mk.RoundToMinimumUnit(amount, rounding);
        result.ShouldBe(expected);
    }

    /// <summary>RoundToMinimumUnit with default rounding mode (ToEven).</summary>
    [Fact]
    public void AudRoundToMinimumUnitWithDefaultModeShouldUseToEven()
    {
        var mk = new MoneyKind<AudCurrency>();
        
        // Default should be ToEven
        var result = mk.RoundToMinimumUnit(100.025m);
        
        result.ShouldBe(100.00m); // ToEven: rounds to nearest even
    }

    /// <summary>IsRoundedToMinimumUnit tests with valid amounts.</summary>
    [Theory]
    [InlineData(100.00)]
    [InlineData(100.05)]
    [InlineData(100.10)]
    [InlineData(0.05)]
    [InlineData(0.00)]
    public void AudIsRoundedToMinimumUnitWithValidAmountsShouldReturnTrue(decimal amount)
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.IsRoundedToMinimumUnit(amount);
        
        result.ShouldBeTrue();
    }

    /// <summary>IsRoundedToMinimumUnit tests with invalid amounts.</summary>
    [Theory]
    [InlineData(100.01)]
    [InlineData(100.02)]
    [InlineData(100.03)]
    [InlineData(100.04)]
    [InlineData(0.01)]
    [InlineData(0.03)]
    public void AudIsRoundedToMinimumUnitWithInvalidAmountsShouldReturnFalse(decimal amount)
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.IsRoundedToMinimumUnit(amount);
        
        result.ShouldBeFalse();
    }

    /// <summary>IsRoundedToMinimumUnit tests with JPY (MinimumUnit = 1).</summary>
    [Theory]
    [InlineData(1000.00, true)]
    [InlineData(1000.5, false)]
    [InlineData(999.00, true)]
    [InlineData(0.00, true)]
    public void JpyIsRoundedToMinimumUnitWithIntegerMinimumUnitShouldValidateCorrectly(
        decimal amount, bool expected)
    {
        var mk = new MoneyKind<JpyCurrency>();
        
        var result = mk.IsRoundedToMinimumUnit(amount);
        
        result.ShouldBe(expected);
    }

    /// <summary>RoundToMinimumUnit with negative amounts.</summary>
    [Fact]
    public void AudRoundToMinimumUnitWithNegativeAmountShouldRound()
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.RoundToMinimumUnit(
            -100.03m,
            MidpointRounding.ToZero);
        
        result.ShouldBe(-100.00m);
    }

    /// <summary>RoundToMinimumUnit with zero amount.</summary>
    [Fact]
    public void AudRoundToMinimumUnitWithZeroShouldReturnZero()
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.RoundToMinimumUnit(0m);
        
        result.ShouldBe(0m);
    }

    /// <summary>RoundToMinimumUnit idempotency test.</summary>
    [Fact]
    public void AudRoundToMinimumUnitIdempotencyRoundingTwiceShouldYieldSameResult()
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var rounded1 = mk.RoundToMinimumUnit(100.03m);
        var rounded2 = mk.RoundToMinimumUnit(rounded1);
        
        rounded1.ShouldBe(rounded2);
    }

    /// <summary>Integration test: Validate rounded amount.</summary>
    [Fact]
    public void AudRoundThenValidateShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();
        var amount = 99.99m;
        
        var rounded = mk.RoundToMinimumUnit(amount);
        var isValid = mk.IsRoundedToMinimumUnit(rounded);
        
        isValid.ShouldBeTrue();
    }

    /// <summary>Integration test: Multiple rounding modes comparison.</summary>
    [Fact]
    public void AudCompareRoundingModesWithMidpointValue()
    {
        var mk = new MoneyKind<AudCurrency>();
        var amount = 100.025m; // Midpoint between 100.00 and 100.05

        var toEven =
            mk
            .RoundToMinimumUnit(amount, MidpointRounding.ToEven);
        var awayFromZero =
            mk
            .RoundToMinimumUnit(amount, MidpointRounding.AwayFromZero);
        var towardZero = 
            mk
            .RoundToMinimumUnit(amount, MidpointRounding.ToZero);

        toEven.ShouldBe(100.00m); // Rounds to even
        awayFromZero.ShouldBe(100.05m); // Rounds away from zero
        towardZero.ShouldBe(100.00m); // Rounds toward zero
    }
}