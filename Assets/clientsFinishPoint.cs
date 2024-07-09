using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientsFinishPoint : MonoBehaviour
{

    public Vector3 finishPoint;
    // Start is called before the first frame update
    void Start()
    {
         }

    // Update is called once per frame
    void Update()
    {
        finishPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
}
