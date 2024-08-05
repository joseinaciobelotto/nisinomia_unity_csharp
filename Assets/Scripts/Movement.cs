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

    public Vector3 mousePositionInScreen;

    public float sectionPlayerIsNow;

    public float timeToChannge;
    public float timeCounter;


    public float lifeNow;
    public float lifeMax;
    public float damage;
    public float armor;
    public float lifeRegen;
    public float atackSpeed;
    public float atackRange;
    public float timeToAtack; 
    public bool positionAtibuited = false;

    public float timeCountAtack = 0;
    public float multiplyingZ = 1;


    public atackHitColliderPlayer atackHitPlayerHere;
    public atackColliderPlayer atackPlayerHere;

    void Start()
    {
      
         rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inColiPlacaCasaB = FindAnyObjectByType<Colision>();

        atackHitPlayerHere = FindAnyObjectByType<atackHitColliderPlayer>();
        atackPlayerHere = FindAnyObjectByType<atackColliderPlayer>();

    }

    // Update is called once per frame
    void Update()
    {



        sectionInNow();

        direcV = Input.GetAxisRaw("Vertical") + joystickHere.Vertical;
        direcH = Input.GetAxisRaw("Horizontal") + joystickHere.Horizontal;

      


        move =  new Vector3(direcH, direcV, 0);
        move = Vector3.Normalize(move);

        mousePositionInScreen = Input.mousePosition;

        Atacking();


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



    public void Atacking()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {


            Vector3 y = new Vector3(0, 3, 0);
            Vector3 x = new Vector3(3, 0, 0);

            Debug.Log("asd");


            float tanValue = 0;

            Vector3 relativePosition = transform.InverseTransformPoint(mousePositionInScreen);



            float tan = 0;
            //Quaternion q;
            // Vector3 v;
            HitColliderEnabled();


            if (relativePosition.x == 0)
            {
                if (relativePosition.y < 0)
                {
                    tan = 180;
                }
                else if (relativePosition.y > 0)
                {
                    tan = 0;
                }


            }
            else if (relativePosition.y == 0)
            {
                if (relativePosition.x < 0)
                {
                    tan = 90;
                }
                else if (relativePosition.x > 0)
                {
                    tan = 270;
                }

            }
            else if (relativePosition.x < relativePosition.y)
            {
                tan = relativePosition.x / relativePosition.y;
                tan = (180f / 3.14159265359f);

            }
            else if (relativePosition.x > relativePosition.y)
            {
                tan = relativePosition.y / relativePosition.x;
                tan = (180f / 3.14159265359f);

            }
            else
            {
                tan = 1;
                tan = (180f / 3.14159265359f);
            }





            if (positionAtibuited == false)
            {
                tanValue = tan;
                atackHitPlayerHere.transform.rotation = Quaternion.Euler(0f, 0f, tanValue - 20);
                positionAtibuited = true;


            }
            else if (timeCountAtack < 5f)
            {
                timeCountAtack += 0.1f;
                Debug.Log(Time.deltaTime);
                atackHitPlayerHere.transform.rotation = Quaternion.Euler(0f, 0f, multiplyingZ = multiplyingZ * atackSpeed);

                Debug.Log("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            }
            else
            {

                multiplyingZ = 1;
                timeCountAtack = 0;
                positionAtibuited = false;
                tanValue = 0;
                HitColliderDisabled();
            }



            
        }

            timeToAtack -= Time.deltaTime;
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
