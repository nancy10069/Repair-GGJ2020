using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    //level 1,2,3,4
    public List<string[]> diags = new List<string[]>{
        new string[]{"Hi! Nice to meet you..",
        "My most anticipated game 'HRP' is released, I need to get it in Nintendo shop.",
        "But I was injured in the accident.. Can you help repair my body?"},
        new string[]{"Hello there.","My girlfriend hates me for being too sissy.",
        "So I promised her a perfect date.",
        "Can you transform my body so I can be a man?",
        "By the way, she has many suitors. Give me a weapon that can drive away those nasty guys!"},
        new string[]{"Hi. I am doing delivery.",
        "Normally, I need to go down the mountain and go down the sea of ​​fire to break through countless obstacles and deliver food to people.",
        "This is the glory of our deliveryman.",
        "But someone called for a takeaway on nyu's lecture and asked me to enter lightly.",
        "This is stumping me! I'm a brave soldier, and the only thing I can't do is to be light-footed. can you help me?"},
        new string[]{"I am a game developer. And here comes TGA 2020! ",
        "I don't want to be a human being anymore! I decided to abandon this human body because human beings have limits. Only by pushing the limits can you develop the best game!",
        "Those guys like Hideo Miyazaki and Hideo Kojima will be obstacles on my way ...",
        "come on! Help me win this year's TGA Game of the Year award!"},

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
