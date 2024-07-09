using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public BoxCollider2D coli;
    public bool inColi=false;
    public bool inColiPlacaCasa = false;
    public bool inColiPlacaCasa2 = false;
    public laucher bagLimitHere;
    public bool inColiTentBox1;
    public bool inColiBed1;
    public bool inColiClient;

    public materiaDrop coinRangeHere;

    // Start is called before the first frame update
    void Start()
    {
        coli = GetComponent<BoxCollider2D>();

        coinRangeHere = FindAnyObjectByType<materiaDrop>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Casa")
        {

            inColi = true;
        }
     
       
        if (collision.gameObject.tag == "tentBox1")
            {

            inColiTentBox1 = true;

            }
        if (collision.gameObject.tag == "bed1")
        {

            inColiBed1 = true;

        }
      
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Casa")
        {

            inColi = false;
        }
        if (collision.gameObject.tag == "tentBox1")
        {

            inColiTentBox1 = false;
        }
        if (collision.gameObject.tag == "bed1")
        {

            inColiBed1 = false;
        }

       

    }

        // Update is called once per frame
        void Update()
    {




}


    



       }


