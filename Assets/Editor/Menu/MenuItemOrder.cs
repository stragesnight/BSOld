using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor.Tilemaps
{
    internal enum EBuildingsMenuItemOrder
    {
        GatheringBuilding = 149
    }

    internal enum EActionsAndDataMenuItemOrder
    {
        MapData = 150,
        BuildingActions = 160,
        ResourceActions,
        TilemapActions
    }

    internal enum ETilesMenuItemOrder
    {
        RuleTile = 151,
        AnimatedTile,
        RandomTile,
        //RuleOverrideTile,
        //AdvanceRuleOverrideTile,
        //CustomRuleTile,
    }

    static internal partial class AssetCreation
    {
        // ================================================= TILES =================================================
        [MenuItem("Assets/Create/2D/Tiles/Rule Tile", priority = (int)ETilesMenuItemOrder.RuleTile)]
        static void CreateRuleTile()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<RuleTile>(), "New Rule Tile.asset");
        }

        [MenuItem("Assets/Create/2D/Tiles/Animated Tile", priority = (int)ETilesMenuItemOrder.AnimatedTile)]
        static void CreateAnimatedTile()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<AnimatedTile>(), "New Animated Tile.asset");
        }

        [MenuItem("Assets/Create/2D/Tiles/Random Tile", priority = (int)ETilesMenuItemOrder.RandomTile)]
        static void CreateRandomTile()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<RandomTile>(), "New Random Tile.asset");
        }

        // =============================================== BUILDINGS ===============================================

        [MenuItem("Assets/Create/Content/Buildings/Gathering BuildingSO", priority = (int)EBuildingsMenuItemOrder.GatheringBuilding)]
        static void CreateGatheringBuilding()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<GatheringBuildingSO>(), "New Gathering BuildingSO.asset");
        }

        // =============================================== RESOURCES ===============================================

        [MenuItem("Assets/Create/Content/Resource", priority = 150)]
        static void CreateResource()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<Resource>(), "New Resource.asset");
        }

        //================================================= ACTIONS =================================================

        [MenuItem("Assets/Create/Actions and Data/Actions/Building Actions", priority = (int)EActionsAndDataMenuItemOrder.BuildingActions)]
        static void CreateBuildingActions()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<BuildingActions>(), "New Building Actions.asset");
        }

        [MenuItem("Assets/Create/Actions and Data/Actions/Tilemap Actions", priority = (int)EActionsAndDataMenuItemOrder.TilemapActions)]
        static void CreateTilemapActions()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<TilemapActions>(), "New Tilemap Actions.asset");
        }

        [MenuItem("Assets/Create/Actions and Data/Actions/Resource Actions", priority = (int)EActionsAndDataMenuItemOrder.ResourceActions)]
        static void CreateResourceActions()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<ResourceActions>(), "New Resource Actions.asset");
        }

        // ================================================== DATA ==================================================

        [MenuItem("Assets/Create/Actions and Data/Data/Map Data", priority = (int)EActionsAndDataMenuItemOrder.MapData)]
        static void CreateMapData()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<MapData>(), "New Map Data.asset");
        }



        /*
        [MenuItem("Assets/Create/2D/Tiles/Advanced Rule Override Tile", priority = (int)ETilesMenuItemOrder.AdvanceRuleOverrideTile)]
        static void CreateAdvancedRuleOverrideTile()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<AdvancedRuleOverrideTile>(), "New Advanced Rule Override Tile.asset");
        }

        [MenuItem("Assets/Create/2D/Tiles/Rule Override Tile", priority = (int)ETilesMenuItemOrder.RuleOverrideTile)]
        static void CreateRuleOverrideTile()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<RuleOverrideTile>(), "New Rule Override Tile.asset");
        }
        */
    }
}