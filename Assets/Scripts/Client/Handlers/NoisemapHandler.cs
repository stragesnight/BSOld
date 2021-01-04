using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// NoisemapHandler class is responsible for synchronizing Tilemap data and values of noise maps 
/// </summary>
public class NoisemapHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MapData mapData;
    [SerializeField] private TilemapActions tilemapActions;


    // Subscribe to Actions
    private void OnEnable()
    {
        tilemapActions.OnSetWalkableNatureTilemapEntry += SetHeightNoisemapEntry;
        tilemapActions.OnSetWalkableNatureTilemapEntry += SetTemperatureNoisemapEntry;
        tilemapActions.OnSetWalkableNatureTilemapEntry += SetFertilityNoisemapEntry;

        tilemapActions.OnSetWalkableNatureTilemap += SetHeightNoisemap;
        tilemapActions.OnSetWalkableNatureTilemap += SetTemperatureNoisemap;
        tilemapActions.OnSetWalkableNatureTilemap += SetFertilityNoisemap;

    }

    // Unsublscribe from Actions
    private void OnDisable()
    {
        tilemapActions.OnSetWalkableNatureTilemapEntry -= SetHeightNoisemapEntry;
        tilemapActions.OnSetWalkableNatureTilemapEntry -= SetTemperatureNoisemapEntry;
        tilemapActions.OnSetWalkableNatureTilemapEntry -= SetFertilityNoisemapEntry;

        tilemapActions.OnSetWalkableNatureTilemap -= SetHeightNoisemap;
        tilemapActions.OnSetWalkableNatureTilemap -= SetTemperatureNoisemap;
        tilemapActions.OnSetWalkableNatureTilemap -= SetFertilityNoisemap;

    }


    // Height map
    private void SetHeightNoisemapEntry(Vector3Int position, MapZone mapZone)
    {
        if (mapZone.isRestrictedByTemperature)
            mapData.SetHeightAtPoint(position, (int)mapZone.elevationZone / 100f);
    }
    private void SetHeightNoisemap(Dictionary<Vector3Int, MapZone> map)
    {
        mapData.SetHeightMap(GetElevationValues(map));
    }

    // Temperature map
    private void SetTemperatureNoisemapEntry(Vector3Int position, MapZone mapZone)
    {
        if (mapZone.isRestrictedByTemperature)
            mapData.SetTemperatureAtPoint(position, (int)mapZone.temperatureBiome / 100f);
    }
    private void SetTemperatureNoisemap(Dictionary<Vector3Int, MapZone> map)
    {
        mapData.SetTemperatureMap(GetTemperatureValues(map));
    }    
    
    // Fertility map
    private void SetFertilityNoisemapEntry(Vector3Int position, MapZone mapZone)
    {
        if (mapZone.isRestrictedByFertility) 
            mapData.SetFertilityAtPoint(position, (int)mapZone.fertilityZone / 100f);
    }
    private void SetFertilityNoisemap(Dictionary<Vector3Int, MapZone> map)
    {
        mapData.SetFertilityMap(GetFertilityValues(map));
    }



    // Transform Dictionary into elevation values
    private float[,] GetElevationValues(Dictionary<Vector3Int, MapZone> map)
    {
        float[,] outputMap = mapData.GetHeightMap();

        foreach (Vector3Int position in map.Keys)
        {
            if (map[position].isRestrictedByElevation)
                outputMap[position.x, position.y] = (int)map[position].elevationZone / 100f;
        }

        return outputMap;
    }

    // Transform Dictionary into temperature values
    private float[,] GetTemperatureValues(Dictionary<Vector3Int, MapZone> map)
    {
        float[,] outputMap = mapData.GetTemperatureMap();

        foreach (Vector3Int position in map.Keys)
        {
            if (map[position].isRestrictedByTemperature)
                outputMap[position.x, position.y] = (int)map[position].temperatureBiome / 100f;
        }

        return outputMap;
    }

    // Transform Dictionary into fertility values
    private float[,] GetFertilityValues(Dictionary<Vector3Int, MapZone> map)
    {
        float[,] outputMap = mapData.GetFertilityMap();

        foreach (Vector3Int position in map.Keys)
        {
            if (map[position].isRestrictedByFertility)
                outputMap[position.x, position.y] = (int)map[position].fertilityZone / 100f;
        }

        return outputMap;
    }
}