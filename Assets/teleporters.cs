using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class teleporters : MonoBehaviour
{
    public teleportEnter1 teleportEnter1Here;
    public teleportEnter2 teleportEnter2Here;
    public teleportEnter3 teleportEnter3Here;
    public teleportEnter4 teleportEnter4Here;
    public teleportEnter5 teleportEnter5Here;
    public teleportEnter6 teleportEnter6Here;

    public Movement teleportToHere;


    public Movement joystick;
  
    // Start is called before the first frame update
    void Start()
    {



        joystick = FindAnyObjectByType<Movement>();
        teleportEnter1Here = FindAnyObjectByType<teleportEnter1>();
        teleportEnter2Here = FindAnyObjectByType<teleportEnter2>();
        teleportEnter3Here = FindAnyObjectByType<teleportEnter3>();
        teleportEnter4Here = FindAnyObjectByType<teleportEnter4>();
        teleportEnter5Here = FindAnyObjectByType<teleportEnter5>();
        teleportEnter6Here = FindAnyObjectByType<teleportEnter6>();



        teleportToHere = FindAnyObjectByType<Movement>();
       
    }


    // Update is called once per frame
    void Update()
    {


        
            if (teleportEnter1Here.colisionWithPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || joystick.joystickHere2.Vertical > 0)
                {

                    teleportToHere.teleportTo(teleportEnter1Here.transferVar);

                }
            }
            else if (teleportEnter2Here.colisionWithPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || joystick.joystickHere2.Vertical > 0)
            {

                teleportToHere.teleportTo(teleportEnter2Here.transferVar);

                }
            }
            else if (teleportEnter3Here.colisionWithPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || joystick.joystickHere2.Vertical > 0)
            {

                    teleportToHere.teleportTo(teleportEnter3Here.transferVar);

                }
            }
            else if (teleportEnter4Here.colisionWithPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || joystick.joystickHere2.Vertical > 0)
            {

                    teleportToHere.teleportTo(teleportEnter4Here.transferVar);
             

                }
            }
            else if (teleportEnter5Here.colisionWithPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || joystick.joystickHere2.Vertical > 0)
            {

                    teleportToHere.teleportTo(teleportEnter5Here.transferVar);

                }
            }
            else if (teleportEnter6Here.colisionWithPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || joystick.joystickHere2.Vertical > 0)

            {

                    teleportToHere.teleportTo(teleportEnter6Here.transferVar);

                }
            }







    }
   
    
}
*/