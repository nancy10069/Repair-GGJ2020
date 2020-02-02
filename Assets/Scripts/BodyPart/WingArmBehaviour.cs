using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingArmBehaviour : ArmBehaviour
{
    protected CharacterJumpController characterJumpController;
    protected override void Awake()
    {
        base.Awake();
        characterJumpController = GetComponentInParent<CharacterJumpController>();
    }

    public override bool active
    {
        get
        {
            return base.active;
        }
        set
        {
            base.active = value;

            characterJumpController.gravityScale = value ? 0.01f : -1f;
        }
    }
}
