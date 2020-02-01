using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectReaction : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    public abstract void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam);
}
