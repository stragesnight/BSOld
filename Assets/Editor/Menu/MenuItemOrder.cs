using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor.Tilemaps
{
    internal enum EConstructionsMenuItemOrder
    {
        GatheringBuilding = 149
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

    internal enum EActionsAndDataMenuItemOrder
    {
        MapData = 150,
        BuildingActions = 160,
        ResourceActions,
        TilemapActions
    }

    internal enum EContentMenuItemOrder
    {
        EntityData = 150,
        Inventory,
        Item,
        Resource = 170,
        MapZone
    }

    internal enum RelayersMenuItemOrder
    {
        InputReader = 180
    }

    static internal partial class AssetCreation
    {
        // ============================================ ACTION CHANNELS ============================================

        [MenuItem("Assets/Create/Relayers/Input Reader", priority = (int)RelayersMenuItemOrder.InputReader)]
        static void CreateEntityMovementChannelSO()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<InputReader>(), "New Input Reader.asset");
        }

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

        // ============================================= CONSTRUCTIONNS =============================================

        [MenuItem("Assets/Create/Content/Constructions/Buildings/Gathering BuildingSO", priority = (int)EConstructionsMenuItemOrder.GatheringBuilding)]
        static void CreateGatheringBuilding()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<GatheringBuildingSO>(), "New Gathering BuildingSO.asset");
        }

        // ================================================ CONTENT ================================================

        [MenuItem("Assets/Create/Content/Resource", priority = (int)EContentMenuItemOrder.Resource)]
        static void CreateResource()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<ResourceItem>(), "New Resource.asset");
        }

        [MenuItem("Assets/Create/Content/Map Zone", priority = (int)EContentMenuItemOrder.MapZone)]
        static void CreateMapZone()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<MapZone>(), "New Map Zone.asset");
        }

        [MenuItem("Assets/Create/Content/Data/Entity", priority = (int)EContentMenuItemOrder.EntityData)]
        static void CreatePlayerData()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<EntityData>(), "New Entity.asset");
        }

        [MenuItem("Assets/Create/Content/Data/Inventory", priority = (int)EContentMenuItemOrder.Inventory)]
        static void CreateInventory()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<InventorySO>(), "New Inventory.asset");
        }

        [MenuItem("Assets/Create/Content/Items/Melee Weapon", priority = (int)EContentMenuItemOrder.Item)]
        static void CreateItem()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<MeleeWeaponItemSO>(), "New Item.asset");
        }

        //================================================= ACTIONS =================================================

        [MenuItem("Assets/Create/Actions and Data/Actions/Building Actions", priority = (int)EActionsAndDataMenuItemOrder.BuildingActions)]
        static void CreateBuildingActions()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<ConstructionActions>(), "New Building Actions.asset");
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