using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjactorLegBehaviour : LegBehaviour
{
    //public GameObject ejactorEffect;

    public override bool active
    {
        get
        {
            return base.active;
        }
        set
        {
            
            base.active = value;
            // if (value)
            //     ejactorEffect.SetActive(true);
            // else
            //     ejactorEffect.SetActive(false);
        }
    }
}
