using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Image barr;
    public int live = 5;
    public int maxLive = 5;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            live--;
            Destroy(collision.gameObject);
        }
        if (live <= 0)
        {
            Destroy(this.gameObject);
        }
        actuaBarr();
    }
    void actuaBarr()
    {
        float liveImagen = (float)live / maxLive;
        barr.fillAmount = liveImagen;


    }
}
