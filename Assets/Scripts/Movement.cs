using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float lifeNow;
    public float lifeMax;
    public float damage;
    public float resistence;
    public float lifeRegen;
    public float atackSpeed;
    public float atackRange;
    public float timeToAtack;
    public float velo = 0;
    public float debt = 10000;


    public float direcV = 0;
    public float direcH = 0;
    public int x, y = 0;
    public Vector3 move;
    public Rigidbody2D rig;

    public int animHorizontal;
    public int animVertical;
    [SerializeField] FixedJoystick joystickHere;
    [SerializeField] public FixedJoystick joystickHere2;
    public bool inColiPlacaCasaMove = false;
    public bool testTP = false;

    public Animator anim;
    public string currentAnim;


    public Colision inColiPlacaCasaB;

    public Vector3 mousePositionInScreen;

    public float sectionPlayerIsNow;

    public float timeToChannge;
    public float timeCounter;

    public Vector3 poitZeroPosition;
 

    public GameObject mouseObject;
    public GameObject pointZero;


    public bool atacked = false;


    public mapScript mapScriptHere;
    public storyWhenStart storyWhenStart;
    public startButton startButtonHere;

    public float timeToSkip = 0;

    public bool isPressesdActionSkip;

    public bool inputE = false;

    public bool gameStarted = true;
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inColiPlacaCasaB = FindAnyObjectByType<Colision>();

        //  atackHitPlayerHere = FindAnyObjectByType<atackHitColliderPlayer>();
        // atackPlayerHere = FindAnyObjectByType<atackColliderPlayer>();

       

        mapScriptHere = FindAnyObjectByType<mapScript>();
        storyWhenStart = FindAnyObjectByType<storyWhenStart>();
        startButtonHere = FindAnyObjectByType<startButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted == true)
        {
            /*  startButtonHere.gameObject.SetActive(true);
              mapScriptHere.gameObject.SetActive(false);
              storyWhenStart.gameObject.SetActive(true);
              gameStarted= false;*/
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mapScriptHere.gameObject.activeSelf != true)
            {
                mapScriptHere.gameObject.SetActive(true);
            }
            else
            {
                mapScriptHere.gameObject.SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inputE = true;

        }
        else
        {
            inputE = false;
        }


        /*   if (storyWhenStart.gameObject.activeSelf == true && timeToSkip > 0)
           {
               storyWhenStart.gameObject.SetActive(false);
           }else
           {

               if (Input.GetKeyDown(KeyCode.Return))
               {



                   isPressesdActionSkip = true;
               }
               if (isPressesdActionSkip == true)
               {

                   timeToSkip += 0.01f;
               }
               if (Input.GetKeyUp(KeyCode.Return))
               {
                   timeToSkip = 0;
                  isPressesdActionSkip = false;
               }
           }


           */
        sectionInNow();

        direcV = Input.GetAxisRaw("Vertical") + joystickHere.Vertical;
        direcH = Input.GetAxisRaw("Horizontal") + joystickHere.Horizontal;




        move = new Vector3(direcH, direcV, 0);
        move = Vector3.Normalize(move);

      // mousePositionInScreen = new Vector3(mouseObject.transform.position.x, mouseObject.transform.position.y, mouseObject.transform.position.z);

       // poitZeroPosition = new Vector3(pointZero.transform.position.x, pointZero.transform.position.y, 0);




    }


    public void FixedUpdate()
    {
        rig.transform.position += move * velo * Time.deltaTime;

        animationChoser();


    }
    public void teleportTo(Vector3 positionToTeleport)
    {
        rig.transform.position = positionToTeleport;
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


















    void sectionInNow()
    {


        if ((rig.transform.position.x > -197 && rig.transform.position.x < 197) &&
            (rig.transform.position.y > -197 && rig.transform.position.y < 197))
        {
            sectionPlayerIsNow = 1;

            if ((rig.transform.position.x > -148 && rig.transform.position.x < 148) &&
                (rig.transform.position.y > -148 && rig.transform.position.y < 148))
            {
                sectionPlayerIsNow = 2;

                if ((rig.transform.position.x > -99 && rig.transform.position.x < 99) &&
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





