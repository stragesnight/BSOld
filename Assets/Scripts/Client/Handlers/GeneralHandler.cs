using UnityEngine;

/// <summary>
/// GeneralHandler class manages systems on a start of a game
/// </summary>
public class GeneralHandler : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] private MapData _mapData;
    [SerializeField] private ConstructionActions _buildingActions;
    [SerializeField] private ResourceActions _resourceActions;
    [SerializeField] private TilemapActions _tilemapActions;


    private void Awake()
    {
        EnableMap();
    }


    private void EnableMap()
    {
        _mapData.CheckInstance();

        _mapData.constructionActions = _buildingActions;
        _mapData.resourceActions = _resourceActions;
        _mapData.tilemapActions = _tilemapActions;
    }
}
