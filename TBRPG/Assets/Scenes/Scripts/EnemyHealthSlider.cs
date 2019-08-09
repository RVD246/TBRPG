using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSlider : MonoBehaviour
{
    public Slider health;

    BattleEnemyHealthManager player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BattleEnemyHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        health.value = player.benemyhealth;
    }
}
