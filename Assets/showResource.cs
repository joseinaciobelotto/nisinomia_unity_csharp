using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static coinColector;
using static Unity.Burst.Intrinsics.X86;

public class showResource : MonoBehaviour
{

    public TextMesh a;
    public coinColector resource;
    public string[] oldName = new string[100];
    public int[] quantitys = new int[100];
    public int nameAmout;

    // Start is called before the first frame update
    void Start()
    {
        resource = FindAnyObjectByType<coinColector>();
        a.text = "";

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void showItemInList(string name, int quantityLeft)
    {

        for (int aux = 0; aux <= nameAmout; aux++)
        {

            if (oldName[aux] == name)
            {
                quantitys[aux] = quantityLeft;
                a.text = "";
                formatingText();
                return;
            }

        }

        oldName[nameAmout] = name;
        quantitys[nameAmout] = quantityLeft;
        nameAmout++;
        a.text = "";
        formatingText();
    }

    public void formatingText()
    {
        for (int aux = 0; aux < nameAmout; aux++)
        {

            a.text += oldName[aux] + " " + quantitys[aux] + "\n" ;
        }

    }
}