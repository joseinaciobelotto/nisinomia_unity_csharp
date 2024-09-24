using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static shopItemPrices3;


public class coinColector : MonoBehaviour
{

    public player_coins coinsHere; 
    public materiaData materiaDataHere;


   

    public List<resourceColected> resourceColectedList;

    public showResource showResourceHere;



    [System.Serializable]
    public  class resourceColected
    {
        public string name;
        public float price;
        public int amount;

    }

    // Start is called before the first frame update
    void Start()
    {
        coinsHere = GetComponentInChildren<player_coins>(); 
        showResourceHere = FindAnyObjectByType<showResource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            coinsHere.plaeyrCoinsAmount++;

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "materia1")
        {

            addNewInList(collision);
            Destroy(collision.gameObject);
        }
        




    }

    void addNewInList(Collider2D collision)
    {
        foreach (resourceColected resourceOfList in resourceColectedList)
        {
            if (collision.gameObject.GetComponent<materiaData>().materiaName == resourceOfList.name)
            {

                

                resourceOfList.amount++;
                showResourceHere.formatingText();

                return;
            }
            

        }
        resourceColected item = new resourceColected();
        item.name = collision.gameObject.GetComponent<materiaData>().materiaName;
        item.amount++;
        resourceColectedList.Add(item);
        showResourceHere.formatingText();


    }



    
}
