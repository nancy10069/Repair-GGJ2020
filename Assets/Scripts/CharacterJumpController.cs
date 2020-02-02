using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpController : MonoBehaviour
{

    public bool active = false;
    // Start is called before the first frame update

    public float velocity
    {
        get
        {
            return _velocity;
        }
        set
        {
            _velocity = Mathf.Clamp(value, -1.5f, 1.5f);
            if (_velocity > 0)
                falling = false;
            else falling = true;
        }
    }

    public bool falling;
    public float _velocity;
    public float defaultGravity;
    public float gravityScale;

    bool applygravitythisFrame = true;

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
            if (applygravitythisFrame)
            {
                if (gravityScale > 0 && falling)
                    ApplyForce(defaultGravity * gravityScale);
                else
                    ApplyForce(defaultGravity);
            }

            transform.position += new Vector3(0, velocity, 0);
            applygravitythisFrame = true;
        }
    }

    void ApplyForce(float gravity)
    {
        velocity += gravity * Time.deltaTime;
        applygravitythisFrame = false;
    }

    public void Bounce(float impulse)
    {
        if (active)
            velocity = impulse;
        Debug.Log("Velocity => " + velocity);
    }

}