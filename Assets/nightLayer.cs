using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nightLayer : MonoBehaviour
{
    public Rigidbody2D rig;

    public Vector3 a;
    public Vector3 b;
   
   

    public float maxDistanceNight;
    public float maxDistanceDay;

    public DayCycle isDayHere;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        isDayHere = FindAnyObjectByType<DayCycle>();
        rig = GetComponent<Rigidbody2D>();
        Vector3 a = new Vector3(0, 10, 0);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDayHere.isNight == true && rig.transform.position.y > maxDistanceDay)
        {
            speed = -1;
        }
        else if(isDayHere.isNight == false && rig.transform.position.y < maxDistanceNight)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
        }
        rig.transform.position += a * speed * Time.deltaTime;
    }
}
