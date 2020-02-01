﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckInReaction : ObjectReaction
{

    [SerializeField]
    private float suckForceRatio = 20f;
    [SerializeField]
    private float maximumSpeed = 5f;

    private bool startZooming = false;

    private void OnEnable()
    {
        startZooming = false;
    }

    public override void CollisionEnterReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, Collision2D collision)
    {
        if (actionType == InteractionAction.InteractionActionType.SuckToMe)
        {
            if (!startZooming)
            {
                startZooming = true;
                StartCoroutine(ZoomIn());

            }
        }

    }

    IEnumerator ZoomIn()
    {
        float time = 2f;
        Vector3 startScale = transform.localScale;
        while (time > 0)
        {
            time -= Time.deltaTime;
            float scale = Mathf.Lerp(transform.localScale.x, 0, (2f - time) / 2f);
            transform.localScale = Vector3.one * scale;
            yield return null;

        }
        gameObject.SetActive(false);
    }

    public override void TriggerReaction(BodyPartBehaviour from, InteractionAction.InteractionActionType actionType, string jsonParam, bool isCountinuous)
    {
        if (actionType == InteractionAction.InteractionActionType.SuckToMe)
        {
            rigidBody.AddForce((from.transform.position - transform.position).normalized * suckForceRatio, GetForceMode(isCountinuous));
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, maximumSpeed);

            if (Vector2.SqrMagnitude(transform.position - from.transform.position) <= 1f)
            {

            }
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
