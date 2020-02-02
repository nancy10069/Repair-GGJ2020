using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    //public bool active;

    Vector3 posRand;
    Vector3 initPos;
    public int shakingAmounts
    {
        get
        {
            return _shakingAmounts;
        }
        set
        {
            _shakingAmounts = Mathf.Clamp(value, 0, 1000);
        }
    }
    [SerializeField]
    int _shakingAmounts = 0;

    public float scale = 0.3f;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        posRand = new Vector3(Mathf.PerlinNoise(Time.time * 12f, Time.time * 13f) - 0.5f, Mathf.PerlinNoise(Time.time * 12.3f, Time.time * 12.2f) - 0.5f, 0) * scale;
        if (shakingAmounts > 0)
            transform.position = initPos + posRand;
    }


}
