namespace MoneyKind4Opos.Currencies;

/// <summary>Interface for subsidiary unit.</summary>
public interface ISubsidiaryUnit
{
    /// <summary>Unit name.</summary>
    string Name { get; }

    /// <summary>Unit symbol.</summary>
    /// <remarks>null : use main symbol.</remarks>
    string? Symbol { get; }

    /// <summary>Ratio to base unit.</summary>
    decimal Ratio { get; }
}

/// <summary>Implementation of ISubsidiaryUnit.</summary>
public record SubsidiaryUnit(
    string Name,
    string? Symbol,
    decimal Ratio) : ISubsidiaryUnit;
