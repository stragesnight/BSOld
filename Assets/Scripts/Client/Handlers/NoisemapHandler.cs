using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// NoisemapHandler class is responsible for synchronizing Tilemap data and values of noise maps 
/// </summary>
public class NoisemapHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MapData _mapData;
    [SerializeField] private TilemapActions _tilemapActions;


    // Subscribe to Actions
    private void OnEnable()
    {
        _tilemapActions.setWalkableNatureTilemapEntryAction += SetHeightNoisemapEntry;
        _tilemapActions.setWalkableNatureTilemapEntryAction += SetTemperatureNoisemapEntry;
        _tilemapActions.setWalkableNatureTilemapEntryAction += SetFertilityNoisemapEntry;

        _tilemapActions.setWalkableNatureTilemapAction += SetHeightNoisemap;
        _tilemapActions.setWalkableNatureTilemapAction += SetTemperatureNoisemap;
        _tilemapActions.setWalkableNatureTilemapAction += SetFertilityNoisemap;

    }

    // Unsublscribe from Actions
    private void OnDisable()
    {
        _tilemapActions.setWalkableNatureTilemapEntryAction -= SetHeightNoisemapEntry;
        _tilemapActions.setWalkableNatureTilemapEntryAction -= SetTemperatureNoisemapEntry;
        _tilemapActions.setWalkableNatureTilemapEntryAction -= SetFertilityNoisemapEntry;

        _tilemapActions.setWalkableNatureTilemapAction -= SetHeightNoisemap;
        _tilemapActions.setWalkableNatureTilemapAction -= SetTemperatureNoisemap;
        _tilemapActions.setWalkableNatureTilemapAction -= SetFertilityNoisemap;

    }


    // Height map
    private void SetHeightNoisemapEntry(Vector3Int position, MapZone mapZone)
    {
        if (mapZone.isRestrictedByTemperature)
            _mapData.SetHeightAtPoint(position, (int)mapZone.elevationZone / 100f);
    }
    private void SetHeightNoisemap(Dictionary<Vector3Int, MapZone> map)
    {
        _mapData.SetHeightMap(GetElevationValues(map));
    }

    // Temperature map
    private void SetTemperatureNoisemapEntry(Vector3Int position, MapZone mapZone)
    {
        if (mapZone.isRestrictedByTemperature)
            _mapData.SetTemperatureAtPoint(position, (int)mapZone.temperatureBiome / 100f);
    }
    private void SetTemperatureNoisemap(Dictionary<Vector3Int, MapZone> map)
    {
        _mapData.SetTemperatureMap(GetTemperatureValues(map));
    }    
    
    // Fertility map
    private void SetFertilityNoisemapEntry(Vector3Int position, MapZone mapZone)
    {
        if (mapZone.isRestrictedByFertility) 
            _mapData.SetFertilityAtPoint(position, (int)mapZone.fertilityZone / 100f);
    }
    private void SetFertilityNoisemap(Dictionary<Vector3Int, MapZone> map)
    {
        _mapData.SetFertilityMap(GetFertilityValues(map));
    }



    // Transform Dictionary into elevation values
    private float[,] GetElevationValues(Dictionary<Vector3Int, MapZone> map)
    {
        float[,] outputMap = _mapData.GetHeightMap();

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
        float[,] outputMap = _mapData.GetTemperatureMap();

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
        float[,] outputMap = _mapData.GetFertilityMap();

        foreach (Vector3Int position in map.Keys)
        {
            if (map[position].isRestrictedByFertility)
                outputMap[position.x, position.y] = (int)map[position].fertilityZone / 100f;
        }

        return outputMap;
    }
}
