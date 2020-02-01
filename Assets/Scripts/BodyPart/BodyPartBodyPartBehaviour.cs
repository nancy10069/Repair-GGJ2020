
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BodyPartBehaviour : MonoBehaviour
{
    public List<InteractionBehaviourData> interactionBehaviourData;
    PhysicsInteractionInfo physicsInfo;

    private void Awake()
    {
        physicsInfo = GetComponent<PhysicsInteractionInfo>();
    }


    public bool active
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (active)
            AllObjectInSceneInteraction();
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!active)
            return;
        var physicsInfo = collision.gameObject.GetComponentInChildren<PhysicsInteractionInfo>();
        for (int i = 0; i < interactionBehaviourData.Count; i++)
        {
            var currentinteractionData = interactionBehaviourData[i];
            if (physicsInfo.MeetType(currentinteractionData.targetType))
            {
                for (int j = 0; j < currentinteractionData.interactionActions.Count; j++)
                {
                    if (currentinteractionData.interactionActions[j].targetScope == InteractionAction.ApplyTargetScope.Colliding)
                    {
                        RunSingleInteractionFunction(collision.gameObject, currentinteractionData.interactionActions[j].actionType, currentinteractionData.interactionActions[j].jsonParams, false);
                    }
                    RunSingleCollisionFunction(collision.gameObject, currentinteractionData.interactionActions[j].actionType, currentinteractionData.interactionActions[j].jsonParams, collision);
                }
            }


        }

    }

    protected virtual void AllObjectInSceneInteraction()
    {
        for (int i = 0; i < interactionBehaviourData.Count; i++)
        {
            var currentinteractionData = interactionBehaviourData[i];

            for (int j = 0; j < currentinteractionData.interactionActions.Count; j++)
            {
                if (currentinteractionData.interactionActions[j].targetScope == InteractionAction.ApplyTargetScope.AllAvailableInScene)
                {
                    RunInteractionFunction(currentinteractionData.targetType, currentinteractionData.interactionActions[j].actionType, currentinteractionData.interactionActions[j].jsonParams, true);
                }
            }
        }
    }

    protected virtual void RunInteractionFunction(PhysicsInteractionInfo.PhysicsInteractionType targetType, InteractionAction.InteractionActionType actionType, string jsonParams, bool isCountinuous)
    {
        if (ObjectManager.instance == null)
            return;
        var allTargetObjects = ObjectManager.instance.GetAllObjectsMeetsType(targetType);
        for (int i = 0; i < allTargetObjects.Count; i++)
        {
            if (allTargetObjects[i] != null)
                RunSingleInteractionFunction(allTargetObjects[i], actionType, jsonParams, isCountinuous);
        }

    }

    public virtual void RunSingleInteractionFunction(GameObject targetObject, InteractionAction.InteractionActionType actionType, string jsonParams, bool isCountinuous)
    {
        targetObject.GetComponents<ObjectReaction>().ToList().ForEach(p => p.TriggerReaction(this, actionType, jsonParams, isCountinuous));
    }

    public virtual void RunSingleCollisionFunction(GameObject targetObject, InteractionAction.InteractionActionType actionType, string jsonParams, Collision2D collision)
    {
        targetObject.GetComponents<ObjectReaction>().ToList().ForEach(p => p.CollisionEnterReaction(this, actionType, jsonParams, collision));
    }
}
