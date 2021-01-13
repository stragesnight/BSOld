using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity's ability to manipulate constructions.
/// </summary>
[RequireComponent(typeof(EntityBehaviour))]
public class EntityBuilding : MonoBehaviour
{
    protected EntityBehaviour _entity;
    protected StateMachine _stateMachine;
    protected InventorySO _inventory;

    [SerializeField] private GameObject _currentConstruction;
    private ConstructionSO _currentConstrutionType;
    protected Vector3Int _constructionOriginPosition;


    protected virtual void Start()
    {
        _entity = GetComponent<EntityBehaviour>();
        _stateMachine = _entity.stateMachine;
        _inventory = _entity.entityData.GetInventory();

        _currentConstrutionType = _currentConstruction.GetComponent<ConstructionBehaviour>().type;
    }


    // Update Construction origin position
    protected void OnConstructionOriginPositionChange(Vector2 position)
    {
        _constructionOriginPosition = new Vector3Int((int)position.x, (int)position.y, 0);
    }


    protected virtual void OnPlaceConstructionInputReceived()
    {
        // If Entity can interact in current state
        if (_stateMachine.GetState().Interactable)
        {
            // Get positions that building will take
            Vector3Int[] positions = _currentConstrutionType.GetConstructionPositions(_constructionOriginPosition);

            // If space if available
            if (CheckPlacingAccessibility(positions))
            {
                // Place Construction
                MapData.Instance.SetConstructionAtPoint(positions, _currentConstruction, true);
                // Deposit items from inventory to blueprint
                _inventory.DepositItems(_currentConstrutionType.GetRequiredResources(), out Dictionary<ItemSO, int> depositedItems);
                MapData.Instance.GetConstructionAtPoint(_constructionOriginPosition, out GameObject construction);
                construction.GetComponent<ConstructionBlueprint>().DepositItems(depositedItems);
            }
        }
           
    }


    protected bool CheckPlacingAccessibility(Vector3Int[] positions)
    {
        // For each position that construction will take
        foreach (Vector3Int position in positions)
        {
            // Check accessibility at that point
            MapData.Instance.GetPlacingAccessibilityMapAtPoint(position, out bool accessible);
            // Return false if at least one tile is unaccessible
            if (!accessible)
            {
                return true;
            }          
        }

        // Return true if all tiles are accessible
        return true;
    }
}
