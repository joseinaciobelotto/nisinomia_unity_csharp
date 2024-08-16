using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

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

    public int auxNumResources = 0;

    /*


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



    public List<Products> itemsList;

    [System.Serializable]
    public class Products
    {

        public string name;
        public float price;
        public int quantityLeft;

    }
    */
    public List<ResourceTypes> resourcesListSector1;
    public List<ResourceTypes> merchandisesListSector2;
    public List<ResourceTypes> productsListSector3;
    public List<ResourceTypes> supList;


    public float resourcesListSector1CashMachine;
    public float merchandisesListSector2CashMachine;
    public float productsListSector3CashMachine;
    public float supListCashMachine;


    [System.Serializable]
    public class ResourceTypes
    {
        public string name;
        public float price;
        public int amount;

        public ResourceTypes(string name, float price, int amount)
        {
            this.name = name;
            this.price = price;
            this.amount = amount;
        }
    }







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


             


            IsNightCalc();

            //Trasnfering Between Sectors



            TrasnferingBetweenSectors(productsListSector3, supList, productsListSector3CashMachine, supListCashMachine);
            TrasnferingBetweenSectors(merchandisesListSector2, productsListSector3, merchandisesListSector2CashMachine, productsListSector3CashMachine);
            TrasnferingBetweenSectors(resourcesListSector1, merchandisesListSector2, resourcesListSector1CashMachine, merchandisesListSector2CashMachine);
         
          
       
            dayCalculationsCount++;
        }

    }

    void IsNightCalc()
    {

        

        globalInflation += Random.Range(1, 4);
       


            debt -= (debt * debtFees) / 100;

    }


    /*
    void TrasnferingBetweenSectors(List<ResourceTypes> firstList, List<ResourceTypes> secondList)
    {

        auxNumResources = 0;
        Debug.Log("QUAAAAAAAAAAAAAAAAATNAS" + firstList.Count);
        Debug.Log("QUAAAAAAAAAAAAAAAAATNAS" + resourcesListSector1.Count);
        for (int aux3= firstList.Count; aux3 >=0 ;aux3--)
        {

            Debug.Log("11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111");
            foreach (var productInSecondList in secondList)
            {
                Debug.Log("5555555555555555555555555555555555555555");
                if (firstList[aux3].name == productInSecondList.name)
                {
                    if (firstList[aux3].amount > 0)
                    {
                        productInSecondList.amount += firstList[aux3].amount;
                        firstList.RemoveAt(aux3); Debug.Log("sassssssssdadsadadadadadasdsa");
                        return;
                    }
                    return;

                }
                else
                {
                    Debug.Log("777777777777777777777777");
                    auxNumResources++;
                }
            }
        

            if ( secondList.Count == 0)
            {
                auxNumResources++;
            }
            Debug.Log(auxNumResources+"222222222222222222222222");
            if (auxNumResources >= secondList.Count)
            {
               
                Debug.Log("444444444444444444444    44444444444");
               
                Debug.Log(aux3);
              
                Debug.Log(firstList[aux3]);
                
                
                secondList.Add(firstList[aux3]);

                firstList.RemoveAt(aux3);
                return;
            }



        }


    */



    void TrasnferingBetweenSectors(List<ResourceTypes> firstList, List<ResourceTypes> secondList, float cashMachineFirst, float cashMachineSecond)
    {

        auxNumResources = 0;


        Debug.Log("quaaaaaaaaantas" + firstList.Count);

        bool removed = false;

        var itemsToRemove = new List<ResourceTypes>();
        var itemsToAdd = new List<ResourceTypes>();


        foreach (var productInFirstList in firstList)
        {


            foreach (var productInSecondList in secondList)
            {

                if (productInFirstList.name == productInSecondList.name)
                {
                    if (productInFirstList.amount > 0 && cashMachineSecond - (productInFirstList.price * productInFirstList.amount) >= 0)
                    {

                        Debug.Log("aaaaa");
                        cashMachineFirst += productInFirstList.price * productInFirstList.amount;
                        cashMachineSecond -= productInFirstList.price * productInFirstList.amount;

                        productInSecondList.amount += productInFirstList.amount;

                    }
                    itemsToRemove.Add(productInFirstList);
                    removed = true;



                }
                else
                {
                    auxNumResources++;
                }


                if (removed == true)
                {
                    continue;
                }

                


            }
            if (secondList.Count == 0)
            {
                auxNumResources++;
            }

            if (auxNumResources >= secondList.Count)
            {

                Debug.Log("bbbbb");

                itemsToAdd.Add(productInFirstList);
                itemsToRemove.Add(productInFirstList);

            }

        }

        foreach (var item in itemsToRemove)
        {
            if (cashMachineSecond - (item.price * item.amount) >= 0)
            {
                cashMachineFirst += item.price * item.amount;
                cashMachineSecond -= item.price * item.amount;

                firstList.Remove(item);
            }
        }

        foreach (var item in itemsToAdd)
        {
            secondList.Add(item);
        }





        }



    



}
