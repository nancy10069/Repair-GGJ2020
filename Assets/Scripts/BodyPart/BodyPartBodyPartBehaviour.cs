
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BodyPartBehaviour : MonoBehaviour
{
    public List<InteractionBehaviourData> interactionBehaviourData;
    PhysicsInteractionInfo physicsInfo;


    protected virtual void Awake()
    {
        physicsInfo = GetComponent<PhysicsInteractionInfo>();
        onRunAudioClipIndex = AudioManager.SFXCategory.None;
    }

    AudioManager.SFXCategory onRunAudioClipIndex;

    public virtual void OnRun()
    {
        active = true;
        if (onRunAudioClipIndex != AudioManager.SFXCategory.None)
            AudioManager.instance.PlaySFX(onRunAudioClipIndex);
    }

    public virtual void OnEndRun()
    {
        active = false;
    }

    public virtual bool active
    {
        get
        {
            return _active;
        }
        set
        {
            _active = value;
            if (!_active)
            {
                GetComponent<Collider2D>().isTrigger = true;
            }
            else
            {
                GetComponent<Collider2D>().isTrigger = shouldIgnorePhysics;
                //GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }

    private bool shouldIgnorePhysics = false;

    [SerializeField]
    private bool _active = false;

    private void OnEnable()
    {
        onRunAudioClipIndex = AudioManager.SFXCategory.None;
        shouldIgnorePhysics = false;
        _active = false;

        for (int i = 0; i < interactionBehaviourData.Count; i++)
        {
            for (int j = 0; j < interactionBehaviourData[i].interactionActions.Count; j++)
            {
                var targetAction = interactionBehaviourData[i].interactionActions[j];
                if (targetAction.actionType == InteractionAction.InteractionActionType.NoPhysicsInteraction)
                {
                    shouldIgnorePhysics = true;
                }
                else if (targetAction.actionType == InteractionAction.InteractionActionType.SuckToMe)
                {
                    onRunAudioClipIndex = AudioManager.SFXCategory.VacuumCleanerLooping;
                }
                else if (targetAction.actionType == InteractionAction.InteractionActionType.Destroy)
                {
                    onRunAudioClipIndex = AudioManager.SFXCategory.ChainsawLooping;
                }
            }
        }
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
