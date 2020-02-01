using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public Dictionary<PhysicsInteractionInfo.PhysicsInteractionType, List<GameObject>> typeTargetDict;
    private void Awake()
    {
        instance = this;
        typeTargetDict = new Dictionary<PhysicsInteractionInfo.PhysicsInteractionType, List<GameObject>>();
        var allPhysicInfo = FindObjectsOfType<PhysicsInteractionInfo>();

        foreach (PhysicsInteractionInfo.PhysicsInteractionType type in Enum.GetValues(typeof(PhysicsInteractionInfo.PhysicsInteractionType)))
        {
            typeTargetDict[type] = new List<GameObject>();
            for (int i = 0; i < allPhysicInfo.Length; i++)
            {
                if (allPhysicInfo[i].MeetType(type))
                {
                    typeTargetDict[type].Add(allPhysicInfo[i].gameObject);
                }
            }
        }
    }



    // Start is called before the first frame update

}
