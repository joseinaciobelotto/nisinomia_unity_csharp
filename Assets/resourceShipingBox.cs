using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class resourceShipingBox1 : MonoBehaviour
{


    public float huntersSalaryCoins;

    public coinColector coinColectorHere2;
    public coinColector coinColectorHere;

 

    public List<resourceTypes> resorceList;

    [System.Serializable]
    public class resourceTypes
    {
        public string name;
        public float price;
        public float quantityLeft;

        public resourceTypes(string name, float price, int amout)
        {
            this.name = name;
            this.price = price;
            this.quantityLeft = amout;
        }


    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     if (collision.gameObject.tag == "monsterFighter")
        {
            coinColectorHere = collision.gameObject.GetComponent<coinColector>();

            tranferList();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    void tranferList()
    {
        for (int aux = 0; aux < coinColectorHere.resourceColectedList.Count; aux++)
        {
            if (coinColectorHere.resourceColectedList[aux].quantityLeft > 0 )
            {

                resourceTypes item = new resourceTypes(coinColectorHere.resourceColectedList[aux].resourceName, coinColectorHere.resourceColectedList[aux].price, coinColectorHere.resourceColectedList[aux].quantityLeft);
                resorceList.Add(item);
                coinColectorHere.resourceColectedList.Remove(coinColectorHere.resourceColectedList[aux]);
            }

        }
    }

}
