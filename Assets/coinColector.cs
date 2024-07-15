using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static shopItemPrices3;
using static UnityEditor.Progress;

public class coinColector : MonoBehaviour
{

    public playerCoins coinsHere; 
    public materiaData materiaDataHere;
 
    public List<resourceColected> resourceColectedList;

    public showResource showResourceHere;

    [System.Serializable]
    public  class resourceColected
    {
        public string resourceName;
        public float price;
        public int quantityLeft;

    }

    // Start is called before the first frame update
    void Start()
    {
        coinsHere = FindAnyObjectByType<playerCoins>(); 
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
            if (collision.gameObject.GetComponent<materiaData>().materiaName == resourceOfList.resourceName)
            {

                

                resourceOfList.quantityLeft++;
                showResourceHere.showItemInList(resourceOfList.resourceName, resourceOfList.quantityLeft);

                return;
            }
            

        }
        resourceColected item = new resourceColected();
        item.resourceName = collision.gameObject.GetComponent<materiaData>().materiaName;
        item.quantityLeft++;
        resourceColectedList.Add(item);
        showResourceHere.showItemInList(item.resourceName, item.quantityLeft);
    }



    
}
