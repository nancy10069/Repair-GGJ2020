using System.Collections.Generic;
using UnityEngine;

public class DestinationController : MonoBehaviour
{
    LevelManager level;
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Chara")
        {
            level.end();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
