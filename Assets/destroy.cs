using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientDestroy : MonoBehaviour
{

    public GameObject materiaDropedPrefab;
    public BoxCollider2D colid;
    public Transform clientPosition;
    public clientSpawner clientMax; 
       public int prefabIndex;
    public bool isQuiting;
        // Start is called before the first frame update
    void Start()
    {
        clientMax = FindObjectOfType<clientSpawner>();

        //    BoxCollider2D colid = gameObject.AddComponent<BoxCollider2D>();
    }
    private void OnApplicationQuit()
    {
        isQuiting = true;
    }
    void OnDestroy()
    {
        if (clientMax != null && !isQuiting)
        {
            GameObject materiaDrop = Instantiate(materiaDropedPrefab, clientPosition.position, Quaternion.identity);
            clientMax.prefabDestroyed(prefabIndex);
        }
    }

  
    
}
