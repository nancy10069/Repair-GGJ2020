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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
