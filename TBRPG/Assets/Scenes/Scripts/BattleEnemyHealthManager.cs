using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemyHealthManager : MonoBehaviour
{
    [HideInInspector] public int benemyhealth;

    [SerializeField] public int benemystarthealth;

    [HideInInspector] public int eattackdmg;

    [HideInInspector] public bool eattack;

    BattlePlayerHealthManager player;

    Animator anim;

    GameObject x;

    [SerializeField] GameObject overworld;
    [SerializeField] GameObject battleworld;

    float timer;

    public GameObject canvas;

    int etype;

    string layername;

    AI[] enemy;

    // Start is called before the first frame update
    void Start()
    {
        benemyhealth = benemystarthealth;
        player = FindObjectOfType<BattlePlayerHealthManager>();
        anim = GetComponent<Animator>();
        etype = LayerMask.GetMask();
        if (etype == 10)
        {
            eattackdmg = 5;
            layername = LayerMask.LayerToName(10);
        }
        if (etype == 10)
        {
            eattackdmg = 10;
            layername = LayerMask.LayerToName(10);
        }
        if (etype == 10)
        {
            eattackdmg = 1;
            layername = LayerMask.LayerToName(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (benemyhealth == 0)
        {
            anim.SetTrigger("dead");
            Destroy(gameObject);
            overworld.SetActive(true);
            battleworld.SetActive(false);
            player.bplayerhealth = 100;
        }
    }
}
