using UnityEngine;

/// <summary>
/// Entity's Inventory manager based on AI decision.
/// </summary>
[RequireComponent(typeof(AIVision))]
public class EntityAIInventoryManager : EntityInventoryManager
{
    private AIVision _vision;


    protected override void Start()
    {
        base.Start();

        _vision = GetComponent<AIVision>();

        _vision.enemySpotedAction += SwitchToWeapon;
        _vision.enemyLostAction += SwitchToRandomSlot;
    }


    private void OnDisable()
    {
        _vision.enemySpotedAction -= SwitchToWeapon;
        _vision.enemyLostAction -= SwitchToRandomSlot;
    }


    // Switch held item to first slot in inventory
    private void SwitchToWeapon(EntityBehaviour _entity) { OnInventorySlotChanged(0); }
    private void SwitchToRandomSlot() { OnInventorySlotChanged(Random.Range(0, 10)); }
}