using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PLAYENEMY : MonoBehaviour
{
    GameObject player;

    GameObject enemy;

    GameObject mainCamera;

    [HideInInspector] public bool wayactivate;

    Animator anim;

    RaycastHit hit;
    [SerializeField] NavMeshAgent agent;

    public float enemyspeed;

    [SerializeField] Vector3 vectoroffset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("enemy");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.transform.position = player.transform.position + vectoroffset;
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {     		
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        mainCamera.transform.position = player.transform.position + vectoroffset;

        mainCamera.transform.LookAt(player.transform);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("clicked", true);
            if (Physics.Raycast(Camera.main.transform.position, cameraRay.direction, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance == 0)
            anim.SetBool("clicked", false);

        if (Vector3.Distance(player.transform.position, enemy.transform.position) < 10)
        {
            wayactivate = false;

            Vector3 direction = (player.transform.position - enemy.transform.position).normalized;

            enemy.transform.LookAt(player.transform);
            enemy.transform.position += direction * enemyspeed * Time.deltaTime;                              
        }
        else
            wayactivate = true;
    }
}
