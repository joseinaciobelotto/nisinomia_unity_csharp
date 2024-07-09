using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportExit1 : MonoBehaviour
{

    public Vector3 tpXYZB;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tpXYZB = new Vector3(transform.position.x, transform.position.y, transform.position.z);



    }
}
