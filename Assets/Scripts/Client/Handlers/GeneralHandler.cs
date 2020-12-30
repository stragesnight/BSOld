using UnityEngine;

/// <summary>
/// GeneralHandler class manages systems on a start of a game
/// </summary>
public class GeneralHandler : MonoBehaviour
{
    [SerializeField] private MapData mapData;
    [SerializeField] private ConstructionActions buildingActions;
    [SerializeField] private ResourceActions resourceActions;
    [SerializeField] private TilemapActions tilemapActions;


    private void Awake()
    {
        mapData.CheckInstance();

        mapData.constructionActions = buildingActions;
        mapData.resourceActions = resourceActions;
        mapData.tilemapActions = tilemapActions;
    }
}
