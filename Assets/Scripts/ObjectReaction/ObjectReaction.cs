using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectReaction : MonoBehaviour
{
    public InteractionAction.InteractionActionType receiveType;
    public abstract void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam);
}
