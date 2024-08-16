using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsShow : MonoBehaviour
{
    public float coinsShowing;
    public int materiaShowing;
    public Text aaaa;
    public Text bbbb;
    public Text cccc;
    public laucher pineaplesAmout;
    public Movement MovementHere;
    public DayCycle daytime;
    public int dayTimeFormatMin;
    public int dayTimeFormatSec;

    string zeroMin;
    string zeroSec;


    // Start is called before the first frame update
    void Start()
    {

        
        pineaplesAmout = FindAnyObjectByType<laucher>();
        MovementHere = FindAnyObjectByType<Movement>();


        daytime = FindAnyObjectByType<DayCycle>();
    }

    string zeroParameter(int dayTime)
    {
        if (dayTime < 10)
        {
            return "0";
        }
        else
        {
            return "";
        }
    }

    void formatingMinutosSeconds()
    {
        dayTimeFormatMin = (int)(daytime.dayTime / 60);
        dayTimeFormatSec = (int)(daytime.dayTime % 60);
        zeroMin = zeroParameter(dayTimeFormatMin);
        zeroSec = zeroParameter(dayTimeFormatSec);
    }

    // Update is called once per frame
    void Update()
    {

        formatingMinutosSeconds();

        aaaa.text =   "Vida: " + MovementHere.lifeNow + "/" + MovementHere.lifeMax + "\n"
                    + "Dano: " + MovementHere.damage + "\n"
                    + "Resistencia: " + MovementHere.resistence + "\n"
                    + "Moedas: " + coinsShowing.ToString() + "\n"
                    + "Recursos: " + materiaShowing + "\n"
                    + "Produtos: " + pineaplesAmout.bagLimit.ToString() + "\n";
     


        bbbb.text =  "Dias: " + daytime.dayCount + "\n" +"Divida: " + MovementHere.debt + "C\n";

        cccc.text = "" + zeroMin + dayTimeFormatMin.ToString() + ":" + zeroSec + dayTimeFormatSec.ToString() + "/"+ "1:00" ;
    }

    //   + "Setor: " + section.sectionPlayerIsNow.ToString() + "°" + "\n"
}

