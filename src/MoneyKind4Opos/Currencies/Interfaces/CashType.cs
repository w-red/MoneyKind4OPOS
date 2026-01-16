namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>Cash type.</summary>
public enum CashType
{
    /// <summary>Undefined cash type.</summary>
    Undefined = 0,
    /// <summary>Coin cash type.</summary>
    Coin = 1,
    /// <summary>Bill cash type.</summary>
    Bill = 2,
    /// <summary>Banknote cash type.</summary>
    Banknote = Bill,
}
