using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Models;

public class CashFaceInfoTest
{
    [Fact]
    public void LocalNameShouldFallbackToNameWhenNotSpecified()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen");

        // Assert
        face.LocalName.ShouldBe("100 Yen");
    }

    [Fact]
    public void LocalNameShouldUseSpecifiedValueWhenProvided()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen", "百円");

        // Assert
        face.LocalName.ShouldBe("百円");
    }

    [Fact]
    public void LocalNameShouldFallbackToNameWhenExplicitlySetToNull()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen", null);

        // Assert
        face.LocalName.ShouldBe("100 Yen");
    }
}
