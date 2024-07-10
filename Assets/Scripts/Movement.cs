using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float direcV = 0;
    public float direcH = 0;
    public float velo = 0;
    public int x, y = 0;
    public Vector3 move;
    public Rigidbody2D rig;

    public int animHorizontal;
    public int animVertical;
    [SerializeField]  FixedJoystick joystickHere;
    [SerializeField] public FixedJoystick joystickHere2;
    public bool inColiPlacaCasaMove = false;
    public bool testTP = false;

    public Animator anim;
    public string currentAnim;
 

    public Colision inColiPlacaCasaB;

    

    public float sectionPlayerIsNow;

    public float timeToChannge;
    public float timeCounter;


    void Start()
    {
      
         rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inColiPlacaCasaB = FindAnyObjectByType<Colision>();

    }

    // Update is called once per frame
    void Update()
    {

        sectionInNow();

        direcV = Input.GetAxisRaw("Vertical") + joystickHere.Vertical;
        direcH = Input.GetAxisRaw("Horizontal") + joystickHere.Horizontal;

      


        move =  new Vector3(direcH, direcV, 0);
        move = Vector3.Normalize(move);
       

        
      

    }
    
    

    void FixedUpdate()
    {
        rig.transform.position += move * velo * Time.deltaTime;

        animationChoser();


    }

 
void testAnim(string newAnim)
    {
        if (currentAnim == newAnim)
        {
            return;
        }
        else
        {
            currentAnim = newAnim;
            anim.Play(newAnim);
        }
;
    }

    void animationChoser()
    {

       

        if (direcV > 0.33)
        {
            testAnim("MaiaAnimCostas");
            animHorizontal = 0;
            animVertical = 1;
            timeCounter = timeToChannge;
        }
        else if (direcV < -0.33)
        {
           
            testAnim("MaiaAnimFrente");
            animHorizontal = 0;
            animVertical = -1;
            timeCounter = timeToChannge;
        }
        else if (direcH > 0.33)
        {
            testAnim("MaiaAnimDireita");
            animHorizontal = 1;
            animVertical = 0;
            timeCounter = timeToChannge;
        }
        else if (direcH < -0.33)
        {
            testAnim("MaiaAnimEsquerda");
            
            animHorizontal = -1;
            animVertical = 0;
            timeCounter = timeToChannge;

        }
        else
        {


        }

        if (timeCounter < 0)
        {
            if (animVertical < 0)
            {
                testAnim("MaiaAnimFrenteParada");
                timeCounter = timeToChannge;
            }   
            else if (animVertical > 0)
            {
                testAnim("MaiaAnimCostasParada");
                timeCounter = timeToChannge;
            }
            else if (animHorizontal > 0)
            {
                testAnim("MaiaAnimDireitaParada");
                timeCounter = timeToChannge;
            }
            else if (animHorizontal < 0)
            {
                testAnim("MaiaAnimEsquerdaParada");
                timeCounter = timeToChannge;    
            }
           
        }
        else
        {
            timeCounter -= Time.deltaTime;
        }




    }

    public void teleportTo(Vector3 positionToTeleport)
    {
        rig.transform.position = positionToTeleport;
    }

    void sectionInNow()
    {


        if ((rig.transform.position.x > -197 && rig.transform.position.x < 197) &&
            (rig.transform.position.y > -197 && rig.transform.position.y < 197))
        {
            sectionPlayerIsNow = 1;

            if ((rig.transform.position.x > -148  && rig.transform.position.x < 148) &&
                (rig.transform.position.y > -148 && rig.transform.position.y < 148))
            {
                sectionPlayerIsNow = 2;

                if ((rig.transform.position.x > -99  && rig.transform.position.x < 99) &&
                (rig.transform.position.y > -99 && rig.transform.position.y < 99))
                {
                    sectionPlayerIsNow = 3;

                    if ((rig.transform.position.x > -50 && rig.transform.position.x < 50) &&
                        (rig.transform.position.y > -50 && rig.transform.position.y < 50))
                    {
                        sectionPlayerIsNow = 4;
                    }

                }


            }
        }


            }
    }
