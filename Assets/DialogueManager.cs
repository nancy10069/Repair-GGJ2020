using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    //level 1,2,3,4
    public List<string[]> diags = new List<string[]>{
        new string[]{"111111","22222"},
        new string[]{"133311111","22222"},
        new string[]{"11114411","22222"},
        new string[]{"111155511","22222"},

    };
    // Start is called before the first frame update
    void Start()
    {
        renderText();
    }
    void renderText()
    {
        text.text = diags[GameManager.instance.level][currNode];
    }
    public LevelManager level;
    public void next()
    {
        currNode++;

        if (currNode == diags[GameManager.instance.level].Length)
        {
            gameObject.SetActive(false);
            level.startGame();
        }
        else
        {
            renderText();
        }
    }
    public UnityEngine.UI.Text text;

    int currNode = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) { next(); }
    }
}
