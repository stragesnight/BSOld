using UnityEngine;

/// <summary>
/// GeneralHandler class manages systems on a start of a game
/// </summary>
public class GeneralHandler : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] private MapData mapData;
    [SerializeField] private ConstructionActions buildingActions;
    [SerializeField] private ResourceActions resourceActions;
    [SerializeField] private TilemapActions tilemapActions;


    private void Awake()
    {
        EnableMap();
    }


    private void EnableMap()
    {
        mapData.CheckInstance();

        mapData.constructionActions = buildingActions;
        mapData.resourceActions = resourceActions;
        mapData.tilemapActions = tilemapActions;
    }
}
