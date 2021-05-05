using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointScript : MonoBehaviour
{
    public GameObject[] arrayOfJoints;
    public Server server;
    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = arrayOfJoints[0].transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 hips = (server.positionForJoints[9] + server.positionForJoints[6]) / 2;
 
        arrayOfJoints[11].transform.position = hips;
        parent = arrayOfJoints[0].transform.parent;
        arrayOfJoints[0].transform.parent = null;
        arrayOfJoints[0].transform.position = server.positionForJoints[0];
        arrayOfJoints[0].transform.parent = parent;




    }
}
