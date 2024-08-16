using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.tvOS;
using static global_coins;

public class resourceShipingBox1 : MonoBehaviour
{


    public float huntersSalaryCoins;

    public coinCollectorMonsterFighter coinColectorHere;
    public showResourceShipBox showResourceShipBoxHere;
    public global_coins globalCoinsHere;


    public bool inColiClient;

    public int auxNumResources;


    public coinColector coinColectorPlayer;

    public playerCoins playerCoinsHere;

    public showResource showResourceHere;
    public showResourceMonsterFighter showResourceMonsterFighterHere;

    // Start is called before the first frame update
    void Start()
    {
        showResourceShipBoxHere = FindAnyObjectByType<showResourceShipBox>();
        globalCoinsHere = FindAnyObjectByType<global_coins>();
        coinColectorHere = FindAnyObjectByType<coinCollectorMonsterFighter>();
        coinColectorPlayer = FindAnyObjectByType<coinColector>();
        playerCoinsHere = FindAnyObjectByType<playerCoins>();

        showResourceHere = FindAnyObjectByType<showResource>();
        showResourceMonsterFighterHere = FindAnyObjectByType<showResourceMonsterFighter>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }





    public void TranferListTranferList()
    {
        auxNumResources = 0;
        int auxPosition = 0;

        foreach (var collectedResource in coinColectorHere.resourceColectedList)
        {


            foreach (var resource in globalCoinsHere.resourcesListSector1)
            {
                if (collectedResource.name == resource.name)
                {
                    if (collectedResource.amount > 0 && globalCoinsHere.resourcesListSector1CashMachine - (collectedResource.price * collectedResource.amount) >= 0)
                    {
                        coinColectorHere.monsterFighterGoldAmout += collectedResource.price * collectedResource.amount;
                        globalCoinsHere.resourcesListSector1CashMachine -= collectedResource.price * collectedResource.amount;
                        resource.amount += collectedResource.amount;
                        coinColectorHere.resourceColectedList.RemoveAt(auxPosition);

                        showResourceShipBoxHere.FormatingText();
                        showResourceMonsterFighterHere.formatingText();
                        return;
                    }
                    return;

                }
                else
                {
                    auxNumResources++;

                }
            }


            if (globalCoinsHere.resourcesListSector1.Count == 0)
            {
                auxNumResources++;
            }

            if (auxNumResources >= globalCoinsHere.resourcesListSector1.Count && globalCoinsHere.resourcesListSector1CashMachine - (collectedResource.price * collectedResource.amount) >= 0)
            {
                coinColectorHere.monsterFighterGoldAmout += collectedResource.price * collectedResource.amount;
                globalCoinsHere.resourcesListSector1CashMachine -= collectedResource.price * collectedResource.amount;

                global_coins.ResourceTypes item = new global_coins.ResourceTypes(collectedResource.name, collectedResource.price, collectedResource.amount);

                globalCoinsHere.resourcesListSector1.Add(item);
                coinColectorHere.resourceColectedList.RemoveAt(auxPosition);

            }


            auxPosition++;
        }

        showResourceShipBoxHere.FormatingText();
        showResourceMonsterFighterHere.formatingText();
    }

   
    public void TranferListTranferListPlayer()
    {
        auxNumResources = 0;
        int auxPosition = 0;
        foreach (var collectedResource in coinColectorPlayer.resourceColectedList)
        {


            foreach (var resource in globalCoinsHere.resourcesListSector1)
            {
                if (collectedResource.name == resource.name)
                {
                    if (collectedResource.amount > 0 && globalCoinsHere.resourcesListSector1CashMachine - (collectedResource.price * collectedResource.amount) >= 0)
                    {
                        playerCoinsHere.plaeyrCoinsAmount += collectedResource.price * collectedResource.amount;
                        globalCoinsHere.resourcesListSector1CashMachine -= collectedResource.price * collectedResource.amount;
                        resource.amount += collectedResource.amount;
                        coinColectorPlayer.resourceColectedList.RemoveAt(auxPosition);
                        showResourceShipBoxHere.FormatingText();
                        showResourceHere.formatingText();
                        return;
                    }
                    return;

                }
                else
                {
                    auxNumResources++;

                }
            }


            if (globalCoinsHere.resourcesListSector1.Count == 0)
            {
                auxNumResources++;
            }

            if (auxNumResources >= globalCoinsHere.resourcesListSector1.Count && globalCoinsHere.resourcesListSector1CashMachine - (collectedResource.price * collectedResource.amount) >= 0)
            {
                playerCoinsHere.plaeyrCoinsAmount += collectedResource.price * collectedResource.amount;
                globalCoinsHere.resourcesListSector1CashMachine -= collectedResource.price * collectedResource.amount;

                global_coins.ResourceTypes item = new global_coins.ResourceTypes(collectedResource.name, collectedResource.price, collectedResource.amount);

                globalCoinsHere.resourcesListSector1.Add(item);
                coinColectorPlayer.resourceColectedList.RemoveAt(auxPosition);

            }

            auxPosition++;

        }

        showResourceShipBoxHere.FormatingText();
        showResourceHere.formatingText();   

    }

}

   
/*


    public void TranferListTranferListPlayer()
    {
        

        auxNumResources = 0;
        int auxPosition = 0;
        foreach (var collectedResource in coinColectorPlayer.resourceColectedList)
        {


            foreach (var resource in globalCoinsHere.resourcesListSector1)
            {
                if (collectedResource.name == resource.name)
                {
                    if (collectedResource.amount > 0 && globalCoinsHere.resourcesListSector1CashMachine - (collectedResource.price * collectedResource.amount) >= 0)
                    {
                        playerCoinsHere.plaeyrCoinsAmount += collectedResource.price * collectedResource.amount;
                        globalCoinsHere.resourcesListSector1CashMachine -= collectedResource.price * collectedResource.amount;
                        resource.amount += collectedResource.amount;
                        coinColectorPlayer.resourceColectedList.RemoveAt(auxPosition);
                        showResourceShipBoxHere.FormatingText();
                        showResourceHere.formatingText();
                        return;
                    }
                    return;

                }
                else
                {
                    auxNumResources++;

                }
            }


            if (globalCoinsHere.resourcesListSector1.Count == 0)
            {
                auxNumResources++;
            }

            if (auxNumResources >= globalCoinsHere.resourcesListSector1.Count && globalCoinsHere.resourcesListSector1CashMachine - (collectedResource.price * collectedResource.amount) >= 0)
            {
                playerCoinsHere.plaeyrCoinsAmount += collectedResource.price * collectedResource.amount;
                globalCoinsHere.resourcesListSector1CashMachine -= collectedResource.price * collectedResource.amount;

                global_coins.ResourceTypes item = new global_coins.ResourceTypes(collectedResource.name, collectedResource.price, collectedResource.amount);

                globalCoinsHere.resourcesListSector1.Add(item);
                coinColectorPlayer.resourceColectedList.RemoveAt(auxPosition);

            }

            auxPosition++;

        }

        showResourceShipBoxHere.FormatingText();
        showResourceHere.formatingText();

    }



    /*
    public void TrasnferingBetweenSectors2( )
    {
        List<coinColector.resourceColected> firstList  = coinColectorPlayer.resourceColectedList;
        List<ResourceTypes> secondList =globalCoinsHere.resourcesListSector1;
        auxNumResources = 0;


        

        bool removed = false;

        var itemsToRemove = new List<coinColector.resourceColected>();
        var itemsToAdd = new List<coinColector.resourceColected>();


        foreach (var productInFirstList in firstList)
        {


            foreach (var productInSecondList in secondList)
            {

                if (productInFirstList.name == productInSecondList.name)
                {
                    if (productInFirstList.amount > 0 && huntersSalaryCoins - (productInFirstList.price * productInFirstList.amount) >= 0)
                    {

                        Debug.Log("aaaaa");
                        playerCoinsHere.plaeyrCoinsAmount += productInFirstList.price * productInFirstList.amount;
                        huntersSalaryCoins -= productInFirstList.price * productInFirstList.amount;

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
            if (playerCoinsHere.plaeyrCoinsAmount - (item.price * item.amount) >= 0)
            {
                huntersSalaryCoins -= item.price * item.amount;
                playerCoinsHere.plaeyrCoinsAmount += item.price * item.amount;

                firstList.Remove(item);
            }
        }

        foreach (var item in itemsToAdd)
        {
            ResourceTypes a1 = new ResourceTypes(item.name,item.price,item.amount);
            secondList.Add(a1);     
        }

        showResourceShipBoxHere.FormatingText();
        showResourceHere.formatingText();



    }


    */




