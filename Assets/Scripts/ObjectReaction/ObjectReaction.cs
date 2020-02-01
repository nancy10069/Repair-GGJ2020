using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PhysicsInteractionInfo))]
public abstract class ObjectReaction : MonoBehaviour
{
    
    protected Rigidbody2D rigidBody;
    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    public abstract void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, bool isCountinous);
    public abstract void CollisionEnterReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, Collision2D collision);
    protected ForceMode2D GetForceMode(bool isCountinuous)
    {
        ForceMode2D forceMode = isCountinuous ? ForceMode2D.Force : ForceMode2D.Impulse;
        return forceMode;
    }
}
