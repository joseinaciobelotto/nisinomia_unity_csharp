using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsShow : MonoBehaviour
{
    public int coinsShowing;
    public int materiaShowing;
    public Text aaaa;
    public laucher pineaplesAmout;
    public Movement section;
    public DayCycle daytime;
    public int dayTimeFormatMin;
    public int dayTimeFormatSec;


    // Start is called before the first frame update
    void Start()
    {

        
        pineaplesAmout = FindAnyObjectByType<laucher>();
        section = FindAnyObjectByType<Movement>();


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

    // Update is called once per frame
    void Update()
    {

        dayTimeFormatMin = (int)(daytime.dayTime / 60) ;
        dayTimeFormatSec = (int)(daytime.dayTime % 60);
        string zeroMin;
        string zeroSec;
        zeroMin = zeroParameter(dayTimeFormatMin);
        zeroSec = zeroParameter(dayTimeFormatSec);

        aaaa.text = "Moedas: " + coinsShowing.ToString()+ " " +  "Recursos: "+materiaShowing+" " + "Produtos: " + pineaplesAmout.bagLimit.ToString() + " " + "Setor: " + section.sectionPlayerIsNow.ToString()+"°" + " " + "Horas: " + zeroMin + dayTimeFormatMin.ToString() +":" + zeroSec + dayTimeFormatSec.ToString();
    }
}

