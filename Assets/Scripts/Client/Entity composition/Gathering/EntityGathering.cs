using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity's ability to gather resources on a map.
/// </summary>
[RequireComponent(typeof(EntityBehaviour))]
public class EntityGathering : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private EntityBehaviour _entity;
    private StateMachine _stateMachine;

    private InstrumentItemSO _heldInstrument;

    private ResourceItemSO _currentGatheredResource;
    private Vector3Int _currentGatheredPosition;

    private float _gatheringTimer;


    private void Start()
    {
        _entity = GetComponent<EntityBehaviour>();
        _stateMachine = _entity.stateMachine;
    }


    private void OnEnable()
    {
        _inputReader.attackAction += OnGatheringInputReceived;
    }


    private void OnDisable()
    {
        _inputReader.attackAction -= OnGatheringInputReceived;
    }


    private void Update()
    {
        // Decrement timer if current state is Gathering
        if (_stateMachine.GetStateEnumValue() == EState.Gathering)
        {
            _gatheringTimer -= Time.deltaTime;
            // Call OnGatheringCompleted if timer is below zero
            if (_gatheringTimer <= 0f)
                OnGatheringCompleted();
        }
    }


    private void OnGatheringInputReceived()
    {
        _heldInstrument = (InstrumentItemSO)_entity.HeldItem;
        // If Entity can interact in current state
        if (_stateMachine.GetState().Interactable)
        {
            // If there is Resource that Entity can gather
            if (TryGetGatherableResource(out _currentGatheredResource, out _currentGatheredPosition))
            {
                // Initiate Gathering
                _gatheringTimer = _heldInstrument.gatheringTime;
                _stateMachine.SetState(EState.Gathering);

                print("gathering started");
            }
        }
    }


    private void OnGatheringCompleted()
    {
        PickableItemDropHandler.Instance.DropItemFromResource(_currentGatheredPosition, _currentGatheredResource);
        _stateMachine.SetState(EState.Default);

        print("gathering completed");
    }


    private bool TryGetGatherableResource(out ResourceItemSO resource, out Vector3Int position)
    {
        // translate current position into Vector3Int
        Vector3Int currentPosition = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

        int radius = _heldInstrument.gatheringRadius;

        // For each cell in radius
        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                // Try get Resoure at this point
                if (MapData.Instance.GetResourceAtPoint(currentPosition + new Vector3Int(x, y, 0), out ResourceItemSO foundResource))
                {
                    // If current instrument type matches required type
                    if (_heldInstrument.instrumentType == foundResource.requiredInstrumentType)
                    {
                        // Return true, resource and its position
                        resource = foundResource;
                        position = currentPosition + new Vector3Int(x, y, 0);
                        return true;
                    }
                }
            }
        }

        resource = null;
        position = Vector3Int.zero;
        return false;
    }
}
