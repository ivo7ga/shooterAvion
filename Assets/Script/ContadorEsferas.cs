using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorEsferas : MonoBehaviour
{
    public int greenCount = 0;
    public int yellowCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Yellow")
        {
            yellowCount++;
            Destroy(other.gameObject);
            Debug.Log("LLevas " + yellowCount + "Esferas Amarillas");
            if (yellowCount == 6)
            {
                Debug.Log("Enhorabuena, has cogido todas las esferas amarillas");
            }
        }
        if (other.gameObject.tag == "Green")
        {
            greenCount++;
            Destroy(other.gameObject);
            Debug.Log("LLevas " + greenCount + "Esferas Verdes");
            if (greenCount == 4)
            {
                Debug.Log("Enhorabuena, has cogido todas las esferas verdes");
            }

        }


    }


}
