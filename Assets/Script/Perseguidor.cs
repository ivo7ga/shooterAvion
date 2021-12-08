using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguidor : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public GameObject gun;
    public NavMeshAgent miAgent;
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
    }


    void toPlayer()
    {
        Vector3 distPlayer = player.transform.position - this.transform.position;
        miAgent.SetDestination(player.transform.position);
        RaycastHit resultRay;
        if (Physics.Raycast(this.transform.position, distPlayer, out resultRay, 20))
        {
            if (resultRay.transform.tag == "Player")
            {
                float angle = Vector3.Angle(this.transform.forward, distPlayer);
                if (angle < angleView)
                {
                    if (distPlayer.magnitude < 4)
                    {
                        Shoot();
                        
                    }

                }
            }
        }
    }
    void Shoot()
    {
        if (bReady == true)
        {
            Count += Time.deltaTime;
            if (Count > 0.5f)
            {
                bReady = false;
                Count = 0;
            }
        }
        else
        {

            GameObject g = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            g.GetComponent<Rigidbody>().AddForce(g.transform.forward * 2000);
            bReady = true;
            Destroy(g.gameObject, 0.5f);


        }
    }
}




