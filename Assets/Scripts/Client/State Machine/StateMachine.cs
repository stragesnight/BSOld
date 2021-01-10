using System.Collections.Generic;

/// <summary>
/// A State Machine.
/// </summary>
public class StateMachine
{
    // Dictionary of all available states
    private Dictionary<EState, InternalState> _states = new Dictionary<EState, InternalState>
    {
        { EState.Default,   new InternalState(true, true, true) },
        { EState.InMenu,    new InternalState(false, false, false)},
        { EState.Attacking, new InternalState(false, false, true)},
        { EState.Gathering, new InternalState(false, true, false)},
        { EState.Building,  new InternalState(true, true, false)},
        { EState.Shocked,   new InternalState(false, false, false)}
    };

    // Current State of the Entity
    private EState _currentState;


    public void SetState(EState state) { _currentState = state; }
    public InternalState GetState() =>_states[_currentState];
    public EState GetStateEnumValue() => _currentState;


    // Class describing properties of a state
    public class InternalState
    {
        public bool Walkable;
        public bool Interactable;
        public bool Attackable;


        public InternalState(bool walkable, bool interactable, bool attackable)
        {
            Walkable = walkable;
            Interactable = interactable;
            Attackable = attackable;
        }
    }
}


public enum EState { Default, InMenu, Attacking, Gathering, Building, Shocked }
