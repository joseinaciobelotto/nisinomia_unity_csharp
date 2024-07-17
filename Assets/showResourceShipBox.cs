using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static coinColector;
using static resourceShipingBox1;
using static shopItemPrices3;
using static Unity.Burst.Intrinsics.X86;
using static UnityEditor.Progress;

public class showResourceShipBox : MonoBehaviour
{



    public TextMesh a;
    public resourceShipingBox1 resourceShipingBox1Here;




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
        

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void formatingText()
    {
        a.text = "";
        for (int aux = 0; aux < resourceShipingBox1Here.resorceList.Count; aux++)
        {

            a.text += resourceShipingBox1Here.resorceList[aux].name + " " + resourceShipingBox1Here.resorceList[aux].quantityLeft + "\n";
        }

    }



}