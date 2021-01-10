using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ResourceMapGenerator generates resource map from given set of ResourceNoiseMaps
/// </summary>
public class ResourceMapGenerator : MonoBehaviour
{
    private Dictionary<Vector3Int, ResourceItem> resourceMap;
    private ResourceNoiseMap[] resourceNoiseMaps;


    // Initialize algorithm and generate resourceMap
    public void Initialize(ResourceNoiseMap[] _resourceNoiseMaps)
    {
        resourceNoiseMaps = _resourceNoiseMaps;

        resourceMap = new Dictionary<Vector3Int, ResourceItem>();

        GenerateNoiseMaps();
        PopulateDictionary();

        // Set MapData resourceMap
        MapData.Instance.SetResourceMap(resourceMap);
    }


    private void PopulateDictionary()
    {
        // Get map size
        int mapWidth = MapData.Instance.GetMapWidth();
        int mapHeight = MapData.Instance.GetMapHeight();

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                bool isFound = GetValidResource(position, out ResourceItem resource);

                if (isFound)
                    resourceMap.Add(position, resource);
            }
        }
    }


    // Generate noise map for every resource in resourceNoiseMaps
    private void GenerateNoiseMaps()
    {
        for (int i = 0; i < resourceNoiseMaps.Length; i++)
        {
            NoiseMap noiseMap = resourceNoiseMaps[i].noiseMap;
            resourceNoiseMaps[i].noiseMap.map = Noise.GenerateNoiseMap
                (
                noiseMap.seed,
                noiseMap.scale,
                noiseMap.octaves,
                noiseMap.persistance,
                noiseMap.lacunarity
                );
        }
    }


    // Get resource that can appear at given point
    private bool GetValidResource(Vector3Int position, out ResourceItem resource)
    {
        foreach (ResourceNoiseMap resourceNoiseMap in resourceNoiseMaps)
        {
            // Get current value of a heightMap
            float currentHeight = resourceNoiseMap.noiseMap.map[position.x, position.y];
            // Get MapZone at fiven point
            MapZone currentMapZone;
            MapData.Instance.GetWalkableNatureAtPoint(position, out currentMapZone);

            // Return current Resource if conditions are satisfied
            if (currentHeight > resourceNoiseMap.minHeight
                && resourceNoiseMap.mapZones.Contains(currentMapZone))
            {
                resource = resourceNoiseMap.resource;
                return true;
            }
        }

        // Otherwise return null
        resource = null;
        return false;
    }
}


/// <summary>
/// ResourceNoiseMap struct holds information about map resource parameters
/// and corresponding NoiseMap
/// </summary>
[System.Serializable]
public struct ResourceNoiseMap
{
    public ResourceItem resource;
    public MapZone[] mapZones;
    [Range(0, 1)] public float minHeight;
    public NoiseMap noiseMap;
}