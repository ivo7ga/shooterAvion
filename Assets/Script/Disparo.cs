using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Disparo : MonoBehaviour
{
    public GameObject originalObject;
    public bool bReady;
    public float Count;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
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
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            try
            {
                RaycastHit resultRay;
                if (Physics.Raycast(this.transform.position, this.transform.forward, out resultRay, 100))
                {
                    GameObject g = Instantiate(originalObject, resultRay.point, this.transform.rotation);
                    Destroy(g.gameObject, 0.5f);
                    bReady = true;

                }
                if (resultRay.transform.tag == "Enemy")
                {
                    Destroy(resultRay.transform.gameObject);


                }
            }
            catch (NullReferenceException)
            {

            }
        }


    }
}

