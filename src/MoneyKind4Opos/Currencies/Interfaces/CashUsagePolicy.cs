namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>Defines how a denomination is used in cash management operations.</summary>
public enum CashUsagePolicy
{
    /// <summary>Standard denomination suitable for deposit, dispensing, and recycling.</summary>
    Standard = 0,

    /// <summary>Valid denomination but typically not used for dispensing change (recycling). e.g. 2000 JPY bill.</summary>
    NonRecyclable = 1,

    /// <summary>High-value denomination usually move to a collection box immediately after deposit.</summary>
    CollectionOnly = 2,

    /// <summary>Special context denominations like commemorative coins or outdated sequences.</summary>
    Special = 9
}
