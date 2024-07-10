using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nightLayer : MonoBehaviour
{
    public Rigidbody2D rig;

    Vector3 a;
    Vector3 b;
    public bool isDay = false;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Vector3 a = new Vector3(0, 1000, 0);
        Vector3 b = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDay == false)
        {
            
            rig.transform.position += a;
        }else if (isDay == true)
        {


            rig.transform.position -= a;
        }
    }
}
