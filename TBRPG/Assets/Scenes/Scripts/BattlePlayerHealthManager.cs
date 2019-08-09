using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerHealthManager : MonoBehaviour
{
    [HideInInspector] public int bplayerhealth;

    [SerializeField] public int bplayerstarthealth;

    [SerializeField] public int attackdmg;
    [SerializeField] public int splattackdmg;

    [HideInInspector] public bool attack;
    [HideInInspector] public bool defend;

    public GameObject canvas;

    public float time;

    Animator anim;

    GameObject lightning;

    [HideInInspector] public GameObject x;

    BattleEnemyHealthManager enemy;

    // Start is called before the first frame update
    void Start()
    { 
        bplayerhealth = bplayerstarthealth;
        anim = GetComponent<Animator>();
        enemy = FindObjectOfType<BattleEnemyHealthManager>();
        lightning = GameObject.FindGameObjectWithTag("Lightning");
        lightning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("special") == true)
        {
            attack = true;
            enemy.benemyhealth -= attackdmg;
        }
        else
            attack = false;
        if (attack)
        {
            enemy.eattack = true;
            bplayerhealth -= enemy.eattackdmg;
            enemy.GetComponent<Animator>().SetTrigger("eattack");
            attack = false;
        }

        enemy.eattack = false;

        if (defend)
        {
            defend = false;
        }

        if (bplayerhealth == 0)
        {
            anim.SetTrigger("dead");
        }
    }

    void Update3()
    {
        Update2();
    }

    IEnumerator Update2()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("eattack");
    }

    public void defense()
    {
        defend = true;
    }

    public void special()
    {
        enemy.benemyhealth -= splattackdmg;
    }
}

