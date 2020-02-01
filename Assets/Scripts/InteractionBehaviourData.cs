using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InteractionBehaviourData
{
    [BitMask(typeof(PhysicsInteractionInfo.PhysicsInteractionType))]
    public PhysicsInteractionInfo.PhysicsInteractionType targetType;

    public List<InteractionAction> interactionActions;
}

[System.Serializable]
public struct InteractionAction
{
    public enum ApplyTargetScope
    {
        Colliding,
        AllAvailableInScene,
    }
    public ApplyTargetScope targetScope;
    public enum InteractionActionType
    {
        BounceOff = 1 << 0,
        SuckToMe = 1 << 1,
        Destroy = 1 << 2
    }

    public InteractionActionType actionType;
    public string jsonParams;
}
