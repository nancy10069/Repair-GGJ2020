using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiuxiangController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Transform target;
    float speed=0.1f;
    // Update is called once per frame
    void Update()
    {
        transform.position =Vector3.MoveTowards(transform
        .position,target.position,speed);
    }
}
