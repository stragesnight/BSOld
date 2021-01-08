using UnityEngine;

/// <summary>
/// General game Entity Behaviour class.
/// </summary>
public class EntityBehavoiur : MonoBehaviour
{
    public EntityData entityData;
    public StateMachine stateMachine;


    protected virtual void Awake()
    {
        stateMachine = new StateMachine();
        stateMachine.SetState(EState.Default);
    }
}
