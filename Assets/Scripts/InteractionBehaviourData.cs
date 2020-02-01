using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/InteractionBehaviourData")]
public class InteractionBehaviourData : ScriptableObject
{
    [BitMask(typeof(PhysicsInteractionInfo.PhysicsInteractionType))]
    public PhysicsInteractionInfo.PhysicsInteractionType targetType;
    public enum ApplyTargetScope
    {
        Colliding,
        AllAvailableInScene,
    }
    public ApplyTargetScope targetScope;
    public List<InteractionAction> interactionActions;
}

[System.Serializable]
public struct InteractionAction
{

    public enum InteractionActionType
    {
        BounceOff = 1 << 0,
        SuckIn = 1 << 1,
    }

    public InteractionActionType actionType;
    public string jsonParams;
}
