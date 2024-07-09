using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCoins : MonoBehaviour
{
   
    public int plaeyrCoinsAmount;

    public coinsShow coinsShowHere;

    // Start is called before the first frame update
    void Start()
    {
      
     coinsShowHere = FindAnyObjectByType<coinsShow>();
    }

    // Update is called once per frame
    void Update()
    {
      coinsShowHere.coinsShowing = plaeyrCoinsAmount;
    }
}
