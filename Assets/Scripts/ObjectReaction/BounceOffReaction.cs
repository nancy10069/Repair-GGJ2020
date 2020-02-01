using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffReaction : ObjectReaction
{
    [SerializeField]
    private float pushOffForceRatio = 10f;
    [SerializeField]
    private float maximumSpeed = 5f;
    public override void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam)
    {
        if (actionType == InteractionAction.InteractionActionType.BounceOff)
        {
            rigidBody.AddForce((from.transform.position - transform.position).normalized * -1 * pushOffForceRatio, ForceMode2D.Force);
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, maximumSpeed);

        }
    }


}
