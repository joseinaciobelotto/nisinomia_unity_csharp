using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productionFactory2 : MonoBehaviour
{



    public float workersSalaryCoins;

    public List<Merchandises> merchandisesList;

    public DayCycle isNightHere;





    [System.Serializable]
    public class Merchandises
    {

        public string name;
        public float price;
        public int quantityLeft;

    }

    // Start is called before the first frame update
    void Start()
    {
        isNightHere = FindAnyObjectByType<DayCycle>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void itensPriceInfaltion()
    {



    }

    void gettingItensSource()
    {


    }

    public float buyingFromFactory(int merchandiseId)
    {
        if (merchandisesList[merchandiseId].quantityLeft > 0)
        {
            merchandisesList[merchandiseId].quantityLeft--;
            workersSalaryCoins += merchandisesList[merchandiseId].price;
            return merchandisesList[merchandiseId].price;
        }
        else
        {
            return -1;
        }


    }
   
}
