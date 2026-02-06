using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

/// <summary>Tests for MoneyKind IMoneyKindRoundable implementation.</summary>
public class MoneyKindRoundableTest
{
    /// <summary>Verifies that AUD amounts are rounded correctly to the nearest 0.05 using the ToEven midpoint rounding mode.</summary>
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

    /// <summary>Verifies that negative AUD amounts are rounded correctly using various midpoint rounding modes.</summary>
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

    /// <summary>Verifies that AUD amounts are rounded correctly to the nearest 0.05 using the AwayFromZero midpoint rounding mode.</summary>
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

    /// <summary>Verifies that AUD amounts are rounded down to the nearest 0.05 using the ToZero (toward zero) midpoint rounding mode.</summary>
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

    /// <summary>Verifies that JPY amounts (MinimumUnit=1) are rounded correctly from fractional inputs.</summary>
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

    /// <summary>Verifies standard integer ROUNDing behavior for JPY across positive and negative values.</summary>
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

    /// <summary>Verifies that RoundToMinimumUnit uses Banker's Rounding (ToEven) as the default behavior.</summary>
    [Fact]
    public void AudRoundToMinimumUnitWithDefaultModeShouldUseToEven()
    {
        var mk = new MoneyKind<AudCurrency>();
        
        // Default should be ToEven
        var result = mk.RoundToMinimumUnit(100.025m);
        
        result.ShouldBe(100.00m); // ToEven: rounds to nearest even
    }

    /// <summary>Verifies that IsRoundedToMinimumUnit returns true for amounts that are multipes of the currency's minimum unit.</summary>
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

    /// <summary>Verifies that IsRoundedToMinimumUnit returns false for amounts that are not multiples of the currency's minimum unit.</summary>
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

    /// <summary>Verifies IsRoundedToMinimumUnit logic for JPY, where minimum unit is 1.</summary>
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

    /// <summary>Verifies that negative amounts are correctly rounded toward zero for AUD.</summary>
    [Fact]
    public void AudRoundToMinimumUnitWithNegativeAmountShouldRound()
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.RoundToMinimumUnit(
            -100.03m,
            MidpointRounding.ToZero);
        
        result.ShouldBe(-100.00m);
    }

    /// <summary>Verifies that zero remains zero after rounding to the minimum unit.</summary>
    [Fact]
    public void AudRoundToMinimumUnitWithZeroShouldReturnZero()
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var result = mk.RoundToMinimumUnit(0m);
        
        result.ShouldBe(0m);
    }

    /// <summary>Verifies that rounding a value that is already rounded has no further effect (idempotency).</summary>
    [Fact]
    public void AudRoundToMinimumUnitIdempotencyRoundingTwiceShouldYieldSameResult()
    {
        var mk = new MoneyKind<AudCurrency>();
        
        var rounded1 = mk.RoundToMinimumUnit(100.03m);
        var rounded2 = mk.RoundToMinimumUnit(rounded1);
        
        rounded1.ShouldBe(rounded2);
    }

    /// <summary>Verifies the integration between RoundToMinimumUnit and IsRoundedToMinimumUnit.</summary>
    [Fact]
    public void AudRoundThenValidateShouldSucceed()
    {
        var mk = new MoneyKind<AudCurrency>();
        var amount = 99.99m;
        
        var rounded = mk.RoundToMinimumUnit(amount);
        var isValid = mk.IsRoundedToMinimumUnit(rounded);
        
        isValid.ShouldBeTrue();
    }

    /// <summary>Compares various midpoint rounding modes against the same input value for AUD.</summary>
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