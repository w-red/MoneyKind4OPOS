using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Models;

/// <summary>Tests for the CashFaceInfo model, verifying LocalName fallback and assignment logic.</summary>
public class CashFaceInfoTest
{
    /// <summary>Verifies that LocalName falls back to the English Name when not explicitly specified.</summary>
    [Fact]
    public void LocalNameShouldFallbackToNameWhenNotSpecified()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen");

        // Assert
        face.LocalName.ShouldBe("100 Yen");
    }

    /// <summary>Verifies that LocalName correctly uses the provided localized value.</summary>
    [Fact]
    public void LocalNameShouldUseSpecifiedValueWhenProvided()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen", "百円");

        // Assert
        face.LocalName.ShouldBe("百円");
    }

    /// <summary>Verifies that LocalName falls back to the Name when the localized value is explicitly set to null.</summary>
    [Fact]
    public void LocalNameShouldFallbackToNameWhenExplicitlySetToNull()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen", null);

        // Assert
        face.LocalName.ShouldBe("100 Yen");
    }
}
