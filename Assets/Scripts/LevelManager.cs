using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyComp
{
    public int index;
    public List<Sprite> sprites = new List<Sprite> { };
    public int score;
    public string anmName;
    //    public bool hasTwoLeg=true;
}

public class LevelManager : MonoBehaviour
{
    string[] typeName = new string[] { "Head", "Arm", "Leg" };
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                BodyComp bc = new BodyComp();
                bc.index = i;
                bc.anmName = typeName[j] + "Animation";//?列个表
                if (j == 0)
                {
                    bc.sprites.Add(Resources.Load
                    (typeName[j] + i, typeof(Sprite)) as Sprite);
                }
                else
                {
                    for (int k = 0; k < 2; k++)
                    {
                        bc.sprites.Add(Resources.Load
                           (typeName[j] + i + "_" + k, typeof(Sprite)) as Sprite);

                    }
                }
                switch (j)
                {
                    case 0: heads.Add(bc); break;
                    case 1: arms.Add(bc); break;
                    case 2: legs.Add(bc); break;
                }
            }
        }
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
    public void startRunning()
    {
        chara.Play("Running");
        BodyComp head = heads[currBodyParts[0]];
        headAnm.Play(head.anmName);
        BodyComp arm = arms[currBodyParts[1]];
        armAnm.Play(arm.anmName);
        BodyComp leg = legs[currBodyParts[2]];
        legAnm.Play(leg.anmName);
    }
    void renderCharacter()
    {
        for (int i = 0; i < currBodyParts.Length; i++)
        {
            currBodyParts[i] = Mathf.Clamp(currBodyParts[i], 0, 1);//max three comps?
        }
        BodyComp head = heads[currBodyParts[0]];
        //   headAnm.Play(head.anmName);
        headspr.sprite = head.sprites[0];
        BodyComp arm = arms[currBodyParts[1]];
        //   armAnm.Play(arm.anmName);
        int count = 0;
        foreach (SpriteRenderer sr in armsprs)
        {
            sr.sprite = arm.sprites[count];
            count++;
        }
        BodyComp leg = legs[currBodyParts[2]];
        // armAnm.Play(leg.anmName);
        count = 0;
        foreach (SpriteRenderer sr in legsprs)
        {
            sr.sprite = leg.sprites[count];
            count++;
        }

    }
    public SpriteRenderer headspr;
    public SpriteRenderer[] armsprs;
    public SpriteRenderer[] legsprs;//leg?


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
