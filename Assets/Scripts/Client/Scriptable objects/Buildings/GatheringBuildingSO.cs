using UnityEngine;

/// <summary>
/// Gathering Building that can gather specified list of resources.
/// </summary>
public class GatheringBuildingSO : ConstructionSO
{
    [Header("Type-specific parameters")]
    public int baseProduction;
    public ResourceItem[] gatherableResources;
}