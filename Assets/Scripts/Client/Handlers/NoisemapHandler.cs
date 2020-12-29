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
        tilemapActions.OnSetNatureTilemapEntry += SetHeightNoisemapEntry;
        tilemapActions.OnSetNatureTilemapEntry += SetTemperatureNoisemapEntry;
        tilemapActions.OnSetNatureTilemapEntry += SetFertilityNoisemapEntry;

        tilemapActions.OnSetNatureTilemap += SetHeightNoisemap;
        tilemapActions.OnSetNatureTilemap += SetTemperatureNoisemap;
        tilemapActions.OnSetNatureTilemap += SetFertilityNoisemap;

    }

    // Unsublscribe from Actions
    private void OnDisable()
    {
        tilemapActions.OnSetNatureTilemapEntry -= SetHeightNoisemapEntry;
        tilemapActions.OnSetNatureTilemapEntry -= SetTemperatureNoisemapEntry;
        tilemapActions.OnSetNatureTilemapEntry -= SetFertilityNoisemapEntry;

        tilemapActions.OnSetNatureTilemap -= SetHeightNoisemap;
        tilemapActions.OnSetNatureTilemap -= SetTemperatureNoisemap;
        tilemapActions.OnSetNatureTilemap -= SetFertilityNoisemap;

    }


    // Height map
    private void SetHeightNoisemapEntry(Vector3Int position, TileBase tile)
    {
        if ((tile as RuleTile).isRestrictedByTemperature)
            mapData.SetHeightAtPoint(position, (int)(tile as RuleTile).elevationZone / 100f);
    }
    private void SetHeightNoisemap(Dictionary<Vector3Int, TileBase> map)
    {
        mapData.SetHeightMap(GetElevationValues(map));
    }

    // Temperature map
    private void SetTemperatureNoisemapEntry(Vector3Int position, TileBase tile)
    {
        if ((tile as RuleTile).isRestrictedByTemperature)
            mapData.SetTemperatureAtPoint(position, (int)(tile as RuleTile).temperatureBiome / 100f);
    }
    private void SetTemperatureNoisemap(Dictionary<Vector3Int, TileBase> map)
    {
        mapData.SetTemperatureMap(GetTemperatureValues(map));
    }    
    
    // Fertility map
    private void SetFertilityNoisemapEntry(Vector3Int position, TileBase tile)
    {
        if ((tile as RuleTile).isRestrictedByFertility) 
            mapData.SetFertilityAtPoint(position, (int)(tile as RuleTile).fertilityZone / 100f);
    }
    private void SetFertilityNoisemap(Dictionary<Vector3Int, TileBase> map)
    {
        mapData.SetFertilityMap(GetFertilityValues(map));
    }



    // Transform Dictionary into elevation values
    private float[,] GetElevationValues(Dictionary<Vector3Int, TileBase> map)
    {
        float[,] outputMap = mapData.GetHeightMap();

        foreach (Vector3Int position in map.Keys)
        {
            RuleTile currentTile = map[position] as RuleTile;
            if (currentTile.isRestrictedByElevation)
                outputMap[position.x, position.y] = (int)currentTile.elevationZone / 100f;
        }

        return outputMap;
    }

    // Transform Dictionary into temperature values
    private float[,] GetTemperatureValues(Dictionary<Vector3Int, TileBase> map)
    {
        float[,] outputMap = mapData.GetTemperatureMap();

        foreach (Vector3Int position in map.Keys)
        {
            RuleTile currentTile = map[position] as RuleTile;
            if (currentTile.isRestrictedByTemperature)
                outputMap[position.x, position.y] = (int)currentTile.temperatureBiome / 100f;
        }

        return outputMap;
    }

    // Transform Dictionary into fertility values
    private float[,] GetFertilityValues(Dictionary<Vector3Int, TileBase> map)
    {
        float[,] outputMap = mapData.GetFertilityMap();

        foreach (Vector3Int position in map.Keys)
        {
            RuleTile currentTile = map[position] as RuleTile;
            if (currentTile.isRestrictedByFertility)
                outputMap[position.x, position.y] = (int)currentTile.fertilityZone / 100f;
        }

        return outputMap;
    }
}