
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BodyPartBehaviour : MonoBehaviour
{
    public List<InteractionBehaviourData> interactionBehaviourData;
    PhysicsInteractionInfo physicsInfo;

    public virtual void CollisionEnter(PhysicsInteractionInfo info)
    {
        throw new System.NotImplementedException();
    }
    private void Awake()
    {
        physicsInfo = GetComponent<PhysicsInteractionInfo>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AllObjectInSceneInteraction();
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        var physicsInfo = collision.gameObject.GetComponentInChildren<PhysicsInteractionInfo>();
        for (int i = 0; i < interactionBehaviourData.Count; i++)
        {
            var currentinteractionData = interactionBehaviourData[i];
            for (int j = 0; j < currentinteractionData.interactionActions.Count; i++)
            {
                if (currentinteractionData.interactionActions[j].targetScope == InteractionAction.ApplyTargetScope.Colliding)
                {
                    RunInteractionFunction(currentinteractionData.targetType, currentinteractionData.interactionActions[j].actionType, currentinteractionData.interactionActions[j].jsonParams);
                }
            }

            //CollisionEnter();
        }

    }

    protected virtual void AllObjectInSceneInteraction()
    {
        for (int i = 0; i < interactionBehaviourData.Count; i++)
        {
            var currentinteractionData = interactionBehaviourData[i];
            for (int j = 0; j < currentinteractionData.interactionActions.Count; i++)
            {
                if (currentinteractionData.interactionActions[j].targetScope == InteractionAction.ApplyTargetScope.AllAvailableInScene)
                {
                    RunInteractionFunction(currentinteractionData.targetType, currentinteractionData.interactionActions[j].actionType, currentinteractionData.interactionActions[j].jsonParams);
                }
            }
        }
    }

    protected void RunInteractionFunction(PhysicsInteractionInfo.PhysicsInteractionType targetType, InteractionAction.InteractionActionType actionType, string jsonParams)
    {
        var allTargetObjects = ObjectManager.instance.typeTargetDict[targetType];
        for (int i = 0; i < allTargetObjects.Count; i++)
        {
            allTargetObjects[i].GetComponents<ObjectReaction>().ToList().ForEach(p => p.TriggerReaction(this, actionType, jsonParams));
        }

    }
}
