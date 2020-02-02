using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjactorLegBehaviour : LegBehaviour {
    public ParticleSystem ejactorEffect;
    protected CharacterJumpController characterJumpController;

    protected override void Awake () {
        base.Awake ();
        characterJumpController = GetComponentInParent<CharacterJumpController> ();
        
    }

    protected override void Update () {
        base.Update ();
        if (characterJumpController.falling) {
            if (ejactorEffect.isPlaying)
                ejactorEffect.Stop (true);
        } else {
            if (ejactorEffect.isStopped)
                ejactorEffect.Play (true);
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D (Collider2D other) {
        // Debug.Log("EjactorLeg Collider with => " + other.gameObject.name);
        if (active) {
            if (other.gameObject.tag == "Ground") {
                characterJumpController.Bounce (5f);
            }
        }
    }

    public override bool active {
        get {
            return base.active;
        }
        set {

            base.active = value;
            characterJumpController.active = value;
            ejactorEffect.gameObject.SetActive (value);

        }
    }
}