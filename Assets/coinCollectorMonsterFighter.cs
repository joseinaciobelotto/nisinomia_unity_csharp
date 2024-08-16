using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static shopItemPrices3;

public class coinCollectorMonsterFighter : MonoBehaviour
{




    public float monsterFighterGoldAmout;


    public materiaData materiaDataHere;


    public List<resourceColected> resourceColectedList;

    public showResourceMonsterFighter showResourceHere;



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
      
        showResourceHere = FindAnyObjectByType<showResourceMonsterFighter>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
          

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
        item.price = collision.gameObject.GetComponent<materiaData>().price;
        item.amount++;
        resourceColectedList.Add(item);
        showResourceHere.formatingText();


    }



    
}
