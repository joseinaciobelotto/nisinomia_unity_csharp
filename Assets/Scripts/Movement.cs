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
    [SerializeField]  FixedJoystick joystickHere;
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


    public bool positionAtibuited = false;

    public float timeCountAtack = 0;
    public float multiplyingZ = 0;
    public float multiplyingZRepeat = 0;

    public bool atacked = false;

    public float tanValue = 0;

    public atackHitColliderPlayer atackHitPlayerHere;
    public atackColliderPlayer atackPlayerHere;

    public GameObject poitZero;
    public GameObject mouseObject;

    public Vector3 relativePositionMouse;
    public Vector3 poitZeroPosition;
    public float tan = 0;

    public mapScript mapScriptHere;
    public storyWhenStart storyWhenStart;
    public startButton startButtonHere;

    public float timeToSkip =0 ;

    public bool isPressesdActionSkip;

    public bool inputE = false;

    public bool gameStarted = true;
    void Start()
    {
      
         rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inColiPlacaCasaB = FindAnyObjectByType<Colision>();

        atackHitPlayerHere = FindAnyObjectByType<atackHitColliderPlayer>();
        atackPlayerHere = FindAnyObjectByType<atackColliderPlayer>();

        mapScriptHere = FindAnyObjectByType<mapScript>();
        storyWhenStart = FindAnyObjectByType<storyWhenStart>();
        startButtonHere = FindAnyObjectByType<startButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted == true) 
        {
            startButtonHere.gameObject.SetActive(true);
            mapScriptHere.gameObject.SetActive(false);
            storyWhenStart.gameObject.SetActive(true);
            gameStarted= false;
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

        if(Input.GetKeyDown(KeyCode.E))
        {
            inputE = true;
          
        }
        else
        {
            inputE = false;
        }
        

        if (storyWhenStart.gameObject.activeSelf == true && timeToSkip > 0)
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



        sectionInNow();

        direcV = Input.GetAxisRaw("Vertical") + joystickHere.Vertical;
        direcH = Input.GetAxisRaw("Horizontal") + joystickHere.Horizontal;

      


        move =  new Vector3(direcH, direcV, 0);
        move = Vector3.Normalize(move);

        mousePositionInScreen = new Vector3(mouseObject.transform.position.x, mouseObject.transform.position.y, mouseObject.transform.position.z);

        poitZeroPosition = new Vector3(poitZero.transform.position.x, poitZero.transform.position.y, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (timeToAtack < 0)
            {
                timeToAtack = 0.3f;
                timeCountAtack = 0;
                tanValue = 0;



                Vector3 y = new Vector3(0, 3, 0);
                Vector3 x = new Vector3(3, 0, 0);


                multiplyingZ = multiplyingZRepeat;


                tan = 0;
             
               

               


            }
       
        }

        if (timeToAtack > 0)
        {
            timeToAtack -= 0.01f;
            Atacking( poitZeroPosition, mousePositionInScreen);
         
        }
        else
        {

            multiplyingZ = multiplyingZRepeat;

            positionAtibuited = false;
           
            HitColliderDisabled();
        }
        

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



    public void Atacking(Vector3 zero, Vector3 mouse)
    {

        float range = 0;
        float catOp = 0f;
        float catAdj = 0f;
        float angle = 0f;

       

        //Quaternion q;
        // Vector3 v;
        HitColliderEnabled();


        if (positionAtibuited == false)
        {

           
            if (zero.x == mouse.x)
        {
            if (zero.y < mouse.y)
            {
            angle = 180f;
            }
            else if (zero.y > mouse.y)
            {
            angle = 0;
            }


        }
        else if (zero.y == mouse.y)
        {
            if (zero.x > mouse.x)
            {
                angle = 90f;
            }
            else if (zero.x < mouse.x)
            {
                angle = 270f;

            }
        }
        else if (zero.x > mouse.x)
        {

            if (zero.y < mouse.y)
            {
                angle = 0f;
                catOp = Mathf.Abs(zero.x - mouse.x);
                catAdj = Mathf.Abs(zero.y - mouse.y);

                tan = Mathf.Atan2( catOp,catAdj) * Mathf.Rad2Deg + angle;
               

            }
            else if (zero.y > mouse.y)
            {
               angle = 90f;
               catOp = Mathf.Abs(zero.x - mouse.x);
               catAdj = Mathf.Abs(zero.y - mouse.y);

               tan = Mathf.Atan2(catAdj, catOp) * Mathf.Rad2Deg + angle;
            

            }      
        }
        else if (zero.x < mouse.x)
        {
            if (zero.y < mouse.y)
            {
                angle = 270f;
                catOp = Mathf.Abs(zero.x - mouse.x);
                catAdj = Mathf.Abs(zero.y - mouse.y);

                tan = Mathf.Atan2( catAdj,catOp) * Mathf.Rad2Deg + angle;

            }
            else if (zero.y > mouse.y)
            {
                angle = 180f;
                catOp = Mathf.Abs(zero.x - mouse.x);
                catAdj = Mathf.Abs(zero.y - mouse.y);
    
                tan = Mathf.Atan2(catOp, catAdj) * Mathf.Rad2Deg + angle;
            
            }
        }
        else
        {
            angle = 360f;


        }

            /*Debug.Log("aaaaaaaaa" + angle);
            Debug.Log("ttttttttt" + tan);

            Debug.Log("aaaaaaaaa" + angle);*/


            /* if (tan - range < 180)
             {
                 tan -= range;
             }
             else if (tan - range < 180)
             {
                 tan = range-180;
             }*/

            range = 60;

            atackHitPlayerHere.transform.rotation = Quaternion.Euler(0f, 0f, tan - 60);
                positionAtibuited = true;
            tanValue = tan - 60;

            }
            else if (timeCountAtack < 1f)
            {
            if (multiplyingZ  < 120)
            {
                
                atackHitPlayerHere.transform.rotation = Quaternion.Euler(0f, 0f, tanValue + multiplyingZ);
                multiplyingZ += multiplyingZ;
                timeCountAtack += 0.1f;
            }
       

           
            

               
            }
          


        



       
   }



    

    public void ColliderEnabled()
    {
        atackPlayerHere.colliderAtack.enabled = true;
    }
    public void ColliderDisabled()
    {
        atackPlayerHere.colliderAtack.enabled = false;
    }

    public void HitColliderEnabled()
    {
        atackHitPlayerHere.colliderHitAtack.enabled = true;
        atackHitPlayerHere.spritHitBox.enabled = true;
    }
    public void HitColliderDisabled()
    {
        atackHitPlayerHere.colliderHitAtack.enabled = false;
        atackHitPlayerHere.spritHitBox.enabled = false;
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
