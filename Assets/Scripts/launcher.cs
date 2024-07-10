using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laucher : MonoBehaviour
{


    public GameObject pineapplePrefab;
    public Transform leavingPoint;
    public int bagLimit;
    public Colision inColiHere;
    public Movement joystick;

    public resourceBoxColision inColiTentBoxHere;

    // Start is called before the first frame update
    void Start()
    {
        inColiTentBoxHere = FindAnyObjectByType<resourceBoxColision>();
        inColiHere = FindAnyObjectByType<Colision>();
        joystick = FindAnyObjectByType<Movement>();
    }


    // Update is called once per frame
    void Update()
    {
        bulletBag();
    }



    void bulletBag()
    {
        //pega projeteis na caixa e nao deixa usar  se a quantidade for menor que 0
        if (inColiTentBoxHere.colisionTent == true)
        {
            if (Input.GetKeyDown(KeyCode.E) || joystick.joystickHere2.Horizontal > 0)
            {
                if (bagLimit <= 14)
                {
                    bagLimit++;
                }
            }
        }

        if (bagLimit > 0)
        {

            if (Input.GetKeyDown(KeyCode.Mouse1)|| joystick.joystickHere2.Horizontal < 0)
            {
                GameObject abacaxi = Instantiate(pineapplePrefab, leavingPoint.position, Quaternion.identity);
                bagLimit--;
            }
        }


    }



}
