using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level=0;//current level
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake(){
        instance=this;
    }
    void Start()
    {
        
    }
    public void nextLevel(){level++;
    renderLevel();
    }
    void renderLevel(){
        //reset

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
