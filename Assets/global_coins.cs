using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class global_coins : MonoBehaviour
{
    public float globalInflation;
    public float debt;
    public float debtFees;



    public sleep sleepCountHere;
    public DayCycle dayTime;


    public int dayCalculationsCount;

    public resourceShipingBox1 shipingBoxHere;
    public productionFactory2 productionMachineHere;
    public shopItemPrices3 shopItemPricesHere;





    // Start is called before the first frame update
    void Start()
    {
        dayTime = FindAnyObjectByType<DayCycle>();
        shopItemPricesHere = FindAnyObjectByType<shopItemPrices3>();
        productionMachineHere = FindAnyObjectByType<productionFactory2>();
        shopItemPricesHere = FindAnyObjectByType<shopItemPrices3>();



    }

    // Update is called once per frame
    void Update()
    {

        if (dayTime.isNight == false && dayTime.dayCount > dayCalculationsCount)
        {


             


            isNightCalc();
            dayCalculationsCount++;
        }

    }

    void isNightCalc()
    {

        

        globalInflation += Random.Range(1, 4);
       


            debt -= (debt * debtFees) / 100;

    }

    
    
}
