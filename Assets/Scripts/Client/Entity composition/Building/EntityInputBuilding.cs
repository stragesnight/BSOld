using UnityEngine;

/// <summary>
/// Entity Building based on Player's input.
/// </summary>
public class EntityInputBuilding : EntityBuilding
{
    [SerializeField] private InputReader _inputReader;


    private void OnEnable()
    {
        _inputReader.attackAction += OnPlaceConstructionInputReceived;
        _inputReader.mousePositionAction += OnConstructionOriginPositionChange;
    }


    private void OnDisable()
    {
        _inputReader.attackAction -= OnPlaceConstructionInputReceived;
        _inputReader.mousePositionAction -= OnConstructionOriginPositionChange;
    }
}
