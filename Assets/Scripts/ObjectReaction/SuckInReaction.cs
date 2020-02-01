using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckInReaction : ObjectReaction
{

    [SerializeField]
    private float suckForceRatio = 20f;
    [SerializeField]
    private float maximumSpeed = 5f;

    public override void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, bool isCountinuous)
    {
        if (actionType == InteractionAction.InteractionActionType.SuckToMe)
        {
            rigidBody.AddForce((from.transform.position - transform.position).normalized * suckForceRatio, GetForceMode(isCountinuous));
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, maximumSpeed);
            if (Vector2.SqrMagnitude(transform.position - from.transform.position) <= 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
