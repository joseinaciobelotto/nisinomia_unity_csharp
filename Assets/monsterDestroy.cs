using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterDestroy : MonoBehaviour
{

    public GameObject materiaDropedPrefab;
    public BoxCollider2D colid;
    public Transform monsterPosition;
    public monsterSpawner monsterMax;
    public int prefabIndex;
    public bool isQuiting;
    // Start is called before the first frame update
    void Start()
    {
        monsterMax = FindObjectOfType<monsterSpawner>();

        //    BoxCollider2D colid = gameObject.AddComponent<BoxCollider2D>();
    }
    private void OnApplicationQuit()
    {
        isQuiting = true;
    }
    void OnDestroy()
    {
        if (monsterMax != null && !isQuiting)
        {
            GameObject materiaDrop = Instantiate(materiaDropedPrefab, monsterPosition.position, Quaternion.identity);
            monsterMax.prefabDestroyed(prefabIndex);
        }
    }



}
