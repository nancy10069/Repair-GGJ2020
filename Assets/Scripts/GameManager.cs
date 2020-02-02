﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject textholder;
    public Text text;
    string[] texts=new string[]{"With the development of technology, people can transform their bodies as they wish.",
    "This technology was originally intended for people with disabilities, but it has since been used in all walks of life.",
    "You are the first trial operation promotion point of human repair project. Prove your ability by replacing body parts according to customer requirements!"};
    public void openText(){
        textholder.SetActive(true);
        render();

    }
    float elapsed=0;
    void FixedUpdate(){
        if (!isMenu)return;
        elapsed+=Time.deltaTime;
        if (elapsed>3){
            next();
            elapsed=0;
        }
    }
    public void next(){
        curr++;
        if (curr>=texts.Length){
            startGame();
            isMenu=false;
            
        }else{

        render();
        }
    }
     void render(){
        text.text = texts[curr];
    }
    int curr=0;
    public int level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }

    [SerializeField]
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

        Application.LoadLevel("Main0");
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
    bool isMenu=true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isMenu){
            next();
            elapsed=0;
        }

    }
}
