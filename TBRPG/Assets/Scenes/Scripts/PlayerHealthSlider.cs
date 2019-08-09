using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSlider : MonoBehaviour
{
    public Slider health;

    BattlePlayerHealthManager player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BattlePlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        health.value = player.bplayerhealth;
    }
}
