using UnityEngine;

/// <summary>
/// Gathering Building that can gather specified list of resources.
/// </summary>
public class GatheringBuildingSO : BuildingSO
{
    [Header("Type-specific parameters")]
    public int baseProduction;
    public Resource[] gatherableResources;
}