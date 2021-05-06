using System.Collections;
using System.Collections.Generic;
using UnityEngine;

https://answers.unity.com/questions/52747/how-i-can-create-a-cube-with-specific-coordenates.html

public class twoDrig : MonoBehaviour
{
    public Transform parent;
    public GameObject prefab;
    public GameObject[] arrayOfjoints;
    public Server server;
    // Start is called before the first frame update
    void Start()
    {
        arrayOfjoints = new GameObject[3];
        server = GetComponent<Server>();
        for (int i = 0; i < 3; i++)
        {
          GameObject bob = Instantiate(prefab, parent);
         arrayOfjoints[i] = bob;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        arrayOfjoints[0].transform.position = server.positionForJoints[1];
        arrayOfjoints[1].transform.position = server.positionForJoints[4];
        arrayOfjoints[2].transform.position = server.positionForJoints[5];

    }
}
