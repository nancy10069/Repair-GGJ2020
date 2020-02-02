using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level
    {
        get
        {
            return _level;
        }
        set
        {
            if (_level != value)
            {
                _level = value;

                AudioManager.instance.PlayBGM(_level);
                AudioManager.instance.StopSFX();
            }
        }
    }

    private int _level;
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (GameManager.instance != this)
        {
            DestroyImmediate(this.gameObject);
        }
        //if (GameManager.instance != null)
        //{
        //    DestroyImmediate(this.gameObject); return;
        //}
        //instance = this;

    }
    public void startGame()
    {
        level = 0;

        Application.LoadLevel("Main");
    }
    //void Start()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}
    public void nextLevel()
    {
        //        Debug.Log("?");
        Debug.Log(level);
        level = level + 1;
        Debug.Log(level);
        renderLevel();
    }
    void renderLevel()
    {
        GameObject.Find("Scene" + level);
        //reset

    }

    // Update is called once per frame
    void Update()
    {

    }
}
