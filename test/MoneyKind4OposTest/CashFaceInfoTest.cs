using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class CashFaceInfoTest
{
    [Fact]
    public void LocalName_ShouldFallbackToName_WhenNotSpecified()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen");

        // Assert
        face.LocalName.ShouldBe("100 Yen");
    }

    [Fact]
    public void LocalName_ShouldUseSpecifiedValue_WhenProvided()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen", "百円");

        // Assert
        face.LocalName.ShouldBe("百円");
    }

    [Fact]
    public void LocalName_ShouldFallbackToName_WhenExplicitlySetToNull()
    {
        // Arrange & Act
        var face = new CashFaceInfo(100m, CashType.Coin, "100 Yen", null);

        // Assert
        face.LocalName.ShouldBe("100 Yen");
    }
}
