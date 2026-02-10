namespace MoneyKind4Opos.Currencies.Interfaces;

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
/// <param name="Name">Unit name.</param>
/// <param name="Symbol">Unit symbol.</param>
/// <param name="Ratio">Ratio to base unit.</param>
public record SubsidiaryUnit(
    string Name,
    string? Symbol,
    decimal Ratio) : ISubsidiaryUnit;
