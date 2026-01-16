namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>Symbol placement enumeration.</summary>
public enum SymbolPlacement
{
    /// <summary>Prefix placement (e.g., $100).</summary>
    Prefix,
    /// <summary>Postfix placement (e.g., 100 dollar).</summary>
    Postfix,
    /// <summary>Suffix placement (=Postfix)</summary>
    Suffix = Postfix,
}
