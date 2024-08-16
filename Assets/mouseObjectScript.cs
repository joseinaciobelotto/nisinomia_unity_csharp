using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseObjectScript : MonoBehaviour
{
    Vector3 mousePositionVector;
    Vector3 worldPositionVector;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePositionVector = Input.mousePosition;
        mousePositionVector.z = Camera.main.nearClipPlane + 1;
        worldPositionVector = Camera.main.ScreenToWorldPoint(mousePositionVector);
        transform.position = worldPositionVector;
    }
}
