
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour, IPhysicsInteractable
{
    public List<InteractionBehaviourData> interactionBehaviourData;

    public virtual void CollisionEnter(PhysicsInteractionInfo info)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        var physicsInfo = collision.gameObject.GetComponentInChildren<PhysicsInteractionInfo>();
        CollisionEnter(physicsInfo);
    }

    protected virtual void AllObjectInSceneInteraction(PhysicsInteractionInfo info)
    {
    }
}
