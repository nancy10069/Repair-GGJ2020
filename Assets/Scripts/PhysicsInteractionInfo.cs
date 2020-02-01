using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsInteractionInfo : MonoBehaviour
{
    public enum PhysicsInteractionType
    {
        Arms = 1 << 0,
        Legs = 1 << 1,
        Heads = 1 << 2,
        Obstacles = 1 << 3,
        Characters = 1 << 4,

    }
    [BitMask(typeof(PhysicsInteractionType))]
    public PhysicsInteractionType interactionType;

    public bool MeetType(PhysicsInteractionType itneractionType)
    {
        if ((((int)this.interactionType) & ((int)interactionType)) > 0)
        {
            return true;
        }
        else return false;
    }

}
