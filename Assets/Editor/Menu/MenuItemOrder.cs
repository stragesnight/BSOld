using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor.Tilemaps
{
    internal enum IBuildingsMenuItemOrder
    {
        GatheringBuilding = 179
    }

    internal enum ETilesMenuItemOrder
    {
        RuleTile = 180,
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

        [MenuItem("Assets/Create/Buildings/Gathering BuildingSO", priority = (int)IBuildingsMenuItemOrder.GatheringBuilding)]
        static void CreateGatheringBuilding()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<GatheringBuildingSO>(), "New Gathering BuildingSO.asset");
        }

        // =============================================== RESOURCES ===============================================

        [MenuItem("Assets/Create/Resource", priority = 190)]
        static void CreateResource()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<Resource>(), "New Resource.asset");
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