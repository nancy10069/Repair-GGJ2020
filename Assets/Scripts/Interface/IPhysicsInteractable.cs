using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysicsInteractable
{
    void CollisionEnter(PhysicsInteractionInfo info);
}
