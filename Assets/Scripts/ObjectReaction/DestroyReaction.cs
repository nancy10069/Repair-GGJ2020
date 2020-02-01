using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyReaction : ObjectReaction
{

    [SerializeField]
    public GameObject destroyParticleEffect;

    public override void CollisionEnterReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, Collision2D collision)
    {
        if (actionType == InteractionAction.InteractionActionType.Destroy)
        {
            Instantiate(destroyParticleEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

        }
    }

    public override void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, bool isCountinous)
    {
        if (actionType == InteractionAction.InteractionActionType.Destroy)
        {
            Instantiate(destroyParticleEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

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
