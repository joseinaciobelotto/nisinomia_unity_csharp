using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static coinColector;
using static resourceShipingBox1;
using static shopItemPrices3;


public class showResourceShipBox : MonoBehaviour
{



    public TextMesh a;
    public resourceShipingBox1 resourceShipingBox1Here;

    public global_coins globalCoinsHere;
   


    public List<resourcesToShow> resourcesToShowList;


    [System.Serializable]
    public class resourcesToShow
    {

        public string name;
        public float price;
        public int quantityLeft;

        public resourcesToShow(string name, float price, int amout)
        {
            this.name = name;
            this.price = price;
            this.quantityLeft = amout;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        resourceShipingBox1Here = FindAnyObjectByType<resourceShipingBox1>();

        globalCoinsHere = FindAnyObjectByType<global_coins>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void FormatingText()
    {
        a.text = "";
        foreach (var item in globalCoinsHere.resourcesListSector1)
        {

            a.text += item.name + " " + item.amount + "\n";
        }

    }



}