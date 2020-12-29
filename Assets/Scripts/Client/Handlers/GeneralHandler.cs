using UnityEngine;

/// <summary>
/// GeneralHandler class manages systems on a start of a game
/// </summary>
public class GeneralHandler : MonoBehaviour
{
    [SerializeField] private MapData mapData;
    [SerializeField] private BuildingActions buildingActions;
    [SerializeField] private TilemapActions tilemapActions;


    private void Awake()
    {
        mapData.CheckInstance();

        mapData.buildingActions = buildingActions;
        mapData.tilemapActions = tilemapActions;

        mapData.EnableActions();
    }


    private void OnDisable()
    {
        mapData.DisableActions();
    }
}
