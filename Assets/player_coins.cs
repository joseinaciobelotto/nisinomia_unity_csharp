using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_coins : MonoBehaviour
{
   
    public float plaeyrCoinsAmount;

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
