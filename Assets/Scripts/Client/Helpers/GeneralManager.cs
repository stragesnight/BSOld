using UnityEngine;

/// <summary>
/// GeneralManager class manages systems on a start of a game
/// </summary>
public class GeneralManager : MonoBehaviour
{
    [SerializeField] private MapData mapData;
    [SerializeField] private BuildingPlacer buildingPlacer;
    [SerializeField] private TilemapDrawer tilemapDrawer;


    private void Start()
    {
        mapData.CheckInstance();

        mapData.buildingPlacer = buildingPlacer;
        mapData.tilemapDrawer = tilemapDrawer;

        mapData.EnableActions();
    }


    private void OnDisable()
    {
        mapData.DisableActions();
    }
}
