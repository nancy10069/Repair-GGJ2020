using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyReaction : ObjectReaction
{

    [SerializeField]
    public GameObject destroyParticleEffect;
    public override void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, bool isCountinous)
    {
        if (actionType == InteractionAction.InteractionActionType.Destroy)
        {
            Instantiate(destroyParticleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

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
