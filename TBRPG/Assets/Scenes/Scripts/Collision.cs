using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    GameObject player;
    GameObject overworld;
    GameObject battleworld;

    // Start is called before the first frame update
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        overworld = GameObject.FindGameObjectWithTag("GameWorld");
        battleworld = GameObject.FindGameObjectWithTag("BattleWorld");
        overworld.SetActive(true);
        battleworld.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(other.gameObject.tag == "enemy")
        {
            overworld.SetActive(false);
            battleworld.SetActive(true);
        }
    }
}
