using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Patrulla : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject player;
    public GameObject bullet;
    public GameObject gun;
    public NavMeshAgent miAgent;
    public int Destiny;
    public float margen = 1;
    public float range = 4;
    public float angleView = 45;
    public float Count;
    public bool bReady;

    // Start is called before the first frame update
    void Start()
    {
        miAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        toPlayer();
        Patrol();
    }


    void toPlayer()
    {

        Vector3 distPlayer = player.transform.position - this.transform.position;
        if (distPlayer.magnitude < range)
        {
            RaycastHit resultRay;
            if (Physics.Raycast(this.transform.position, distPlayer, out resultRay, 20))
            {
                if (resultRay.transform.tag == "Player")
                {
                    float angle = Vector3.Angle(this.transform.forward, distPlayer);
                    if (angle < angleView)
                    {
                        miAgent.SetDestination(player.transform.position);
                        Shoot();
                    }
                }
            }
        }
    }
    void Patrol()
    {
        Vector3 dist = this.transform.position - miAgent.destination;
        if (dist.magnitude < margen)
        {
            if (Destiny == 1)
            {
                Destiny = 2;
                miAgent.SetDestination(p2.transform.position);
            }
            else
            {
                Destiny = 1;
                miAgent.SetDestination(p1.transform.position);
            }
        }
    }
    void Shoot()
    {
        if (bReady == true)
        {
            Count += Time.deltaTime;
            if (Count > 0.2f)
            {
                bReady = false;
                Count = 0;
            }
        }
        else
        {
            GameObject g = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            g.GetComponent<Rigidbody>().AddForce(g.transform.forward * 1000);
            bReady = true;
            Destroy(g.gameObject, 0.5f);
        }
    }
}
