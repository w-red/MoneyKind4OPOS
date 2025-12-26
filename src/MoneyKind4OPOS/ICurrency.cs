using MoneyKind4Opos.Codes;

namespace MoneyKind4Opos;

/// <summary>Interface of Currency</summary>
public interface ICurrency
{
    /// <summary>Currency code.</summary>
    static abstract Iso4217 Code { get; }

    /// <summary>Minimum unit.</summary>
    static abstract decimal MinimumUnit { get; }

    /// <summary>Coin faces.</summary>
    static abstract IEnumerable<CashFaceInfo> Coins {get;}

    /// <summary>Bill faces.</summary>
    static abstract IEnumerable<CashFaceInfo> Bills { get; }
}
