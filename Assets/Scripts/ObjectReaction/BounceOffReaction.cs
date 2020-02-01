﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffReaction : ObjectReaction
{
    [SerializeField]
    private float pushOffForceRatio = 10f;
    [SerializeField]
    private float maximumSpeed = 5f;
    public override void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, bool isCountinuous)
    {
        
        if (actionType == InteractionAction.InteractionActionType.BounceOff)
        {
            rigidBody.AddForce((from.transform.position - transform.position).normalized * -1 * pushOffForceRatio, GetForceMode(isCountinuous));
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, maximumSpeed);

        }
    }


}
