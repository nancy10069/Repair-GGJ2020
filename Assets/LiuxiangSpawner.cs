using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiuxiangSpawner : MonoBehaviour
{
    public GameObject liuxiang;
    
    float elapsed=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    System.Random ran =new System.Random();
    void FixedUpdate(){
        elapsed+=Time.deltaTime;
        if (elapsed>0.5f){
            elapsed=0;
            GameObject ins = Instantiate(liuxiang);
       /*     ins.transform.position = new Vector3(
                ran.Next(-1200,1700)/100,
                ran.Next(-800,800)/100,
                0
            ); */

            ins.SetActive(true);
            //-3.5,-1.2
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
