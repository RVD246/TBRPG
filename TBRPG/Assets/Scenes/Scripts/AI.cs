using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    float speed;

    PLAYENEMY enemy;

    float[] distances;
    float shortest;

    int index = 0;
    bool inverse = false;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = (waypoints[index].transform.position - transform.position).normalized;
        enemy = FindObjectOfType<PLAYENEMY>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, waypoints[index].transform.position);
        if (enemy.wayactivate)
        {
            if (distance < 0.25f)
            {
                if (!inverse)
                {
                    if (index >= waypoints.Length - 2)
                        inverse = true;
                    index++;
                }
                else
                {
                    if (index <= 1)
                        inverse = false;
                    index--;
                }
                direction = (waypoints[index].transform.position - transform.position).normalized;
            }            
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(waypoints[index].transform);
        }
        else
        {
            direction = (waypoints[index].transform.position - transform.position).normalized;
        }
    }
}
