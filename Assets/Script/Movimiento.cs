using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public GameObject bullet;
    public GameObject point;
    public Rigidbody miRigid;
    public int vel;
    public float Count;
    public bool bReady;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        miRigid.velocity = transform.forward * vel;
        movePlane();
        Shoot();
    }

    void movePlane()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, -2, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, 2, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(new Vector3(-2, 0, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(new Vector3(2, 0, 0), Space.Self);
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
        else if (Input.GetKey(KeyCode.Space))
        {
            GameObject g = Instantiate(bullet, point.transform.position, point.transform.rotation);
            g.GetComponent<Rigidbody>().AddForce(g.transform.forward * 200);
            bReady = true;
        }
    }
}
