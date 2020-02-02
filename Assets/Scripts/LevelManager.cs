using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BodyComp
{
    public int index;
    public Sprite sprite;
    public List<Sprite> sprites = new List<Sprite> { };
    public int score;
    public string anmName;
    //    public bool hasTwoLeg=true;
}


public class LevelManager : MonoBehaviour
{




    public UnityEngine.UI.Image[] imgs;
    public GameObject[] scenes;
    string[] typeName = new string[] { "Head", "Arm", "Leg" };
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.instance.level = 0;
        //AudioManager.instance.PlayBGM(0);
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                BodyComp bc = new BodyComp();
                bc.index = i;
                bc.anmName = typeName[j] + "Animation";//?列个表
                bc.sprite = Resources.Load
                    (typeName[j] + i, typeof(Sprite)) as Sprite;
                if (bc.index == 3 && j == 1)
                {
                    bc.anmName = "WingAnimation";
                }
                else if (j == 2)
                {
                    if (bc.index == 2 || bc.index == 1)
                    {
                        bc.anmName = "TankAnimation";
                    }
                }
                //                 bc.sprites.Add(Resources.Load
                //                  (typeName[j] + i, typeof(Sprite)) as Sprite);
                /* if (j == 0)
                 {

                 }
                 else
                 {
                     for (int k = 0; k < 2; k++)
                     {
                         bc.sprites.Add(Resources.Load
                            (typeName[j] + i + "_" + k, typeof(Sprite)) as Sprite);

                     }
                 } */
                switch (j)
                {
                    case 0: heads.Add(bc); break;
                    case 1: arms.Add(bc); break;
                    case 2: legs.Add(bc); break;
                }
            }
        }
    }
    public GameObject endPage;
    public void nextLevel()
    {

        GameManager.instance.nextLevel();
        Application.LoadLevel("Main");
        //
    }
    public int[] currBodyParts = new int[3];
    public void prev(int i)
    {
        currBodyParts[i]--;
        renderCharacter();
    }
    public void next(int i)
    {
        currBodyParts[i]++;
        renderCharacter();

    }
    public Animator chara;
    public Animator holder;
    public GameObject btnHodler;
    public void startGame()
    {
        btnHodler.SetActive(true);
    }
    public void startRunning()
    {

        scenes[GameManager.instance.level].SetActive(true);
        holder.Play("Small");
        StartCoroutine(running());
    }
    IEnumerator running()
    {
        yield return new WaitForSeconds(0.5f);
        ObjectManager.instance.RefreshAllObjectsDict();
        run();
    }
    IEnumerator endding()
    {
        yield return new WaitForSeconds(3f);
        chara.gameObject.GetComponentsInChildren<BodyPartBehaviour>().ToList().ForEach(p => p.OnEndRun());
        endPage.SetActive(true);
    }
    void run()
    {
        chara.gameObject.GetComponentsInChildren<BodyPartBehaviour>().ToList().ForEach(p =>
        {
            //p.active = true;
            p.OnRun();
        });
        StartCoroutine(endding());
        chara.Play("Running");
        BodyComp head = heads[currBodyParts[0]];
        headAnm.Play(head.anmName);
        BodyComp arm = arms[currBodyParts[1]];
        //        armAnm.Play(arm.anmName);//所有的anm
        foreach (GameObject obj in armObjects)
        {
            foreach (Animator a in obj.transform.GetComponentsInChildren<Animator>())
            {
                a.Play(arm.anmName);
            }
        }
        BodyComp leg = legs[currBodyParts[2]];
        //   legAnm.Play(leg.anmName);
        foreach (GameObject obj in legObjects)
        {
            foreach (Animator a in obj.transform.GetComponentsInChildren<Animator>())
            {
                a.Play(leg.anmName);
            }
        }
    }
    void renderCharacter()
    {
        for (int i = 0; i < currBodyParts.Length; i++)
        {
            currBodyParts[i] = Mathf.Clamp(currBodyParts[i], 0, 4);//max three comps?
        }
        BodyComp head = heads[currBodyParts[0]];
        headspr.sprite = head.sprite;//.sprites[0];
        imgs[0].sprite = head.sprite;
        BodyComp arm = arms[currBodyParts[1]];
        imgs[1].sprite = arm.sprite;
        //    int count = 0;
        /*
                foreach (SpriteRenderer sr in armsprs)
                {
                    sr.sprite = arm.sprite;//sprites[count];
                    count++;
                } */
        foreach (GameObject obj in armObjects)
        {
            obj.SetActive(false);
        }
        armObjects[arm.index].SetActive(true);

        BodyComp leg = legs[currBodyParts[2]];
        imgs[2].sprite = leg.sprite;
        foreach (GameObject obj in legObjects)
        {
            obj.SetActive(false);
        }
        legObjects[leg.index].SetActive(true);
        /*   // count = 0;
            foreach (SpriteRenderer sr in legsprs)
            {
                sr.sprite = leg.sprite;//sprites[count];
              //  count++;
            } */

    }
    public SpriteRenderer headspr;
    //    public SpriteRenderer[] armsprs;
    // public SpriteRenderer[] legsprs;//leg?

    public GameObject[] armObjects;
    public GameObject[] legObjects;
    public Animator headAnm;
    public Animator armAnm;
    public Animator legAnm;


    //所有资源
    public List<BodyComp> heads = new List<BodyComp>();
    public List<BodyComp> arms = new List<BodyComp>();
    public List<BodyComp> legs = new List<BodyComp>();

    // Update is called once per frame
    void Update()
    {

    }
}
