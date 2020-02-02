using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleExplosionCall : MonoBehaviour
{
    // Start is called before the first frame update

    public ExplosionController explosionController;

    public List<Texture> limbs;

    public static ExampleExplosionCall instance;

    private void Awake()
    {
        
    }

    void Start()
    {
        explosionController = GameObject.Find("ExplosionController").GetComponent<ExplosionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector3 newPos = new Vector3(Random.Range(-20, 20), Random.Range(0, 15), 0);
            explosionController.MakeExplosion(newPos, ExplosionSize.Small, limbs);
        }
    }
}
