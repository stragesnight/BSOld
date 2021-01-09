using UnityEngine;

/// <summary>
/// General game Entity Behaviour class.
/// </summary>
public class EntityBehaviour : MonoBehaviour
{
    public EntityData entityData;
    public StateMachine stateMachine;

    public EReaction currentReaction;


    protected virtual void Awake()
    {
        stateMachine = new StateMachine();
        stateMachine.SetState(EState.Default);

        currentReaction = entityData.GetDefaultReaction();
    }
}
