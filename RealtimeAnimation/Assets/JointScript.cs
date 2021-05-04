using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointScript : MonoBehaviour
{
    public GameObject[] arrayOfJoints;
    public Server server;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 hips = (server.positionForJoints[9] + server.positionForJoints[6]) / 2;
        float testxValue = 0.00085322666F;
        float testyValue = 0.15233160621F;
        arrayOfJoints[11].transform.position = hips;
        //right arm,starting from the neck to shoulder
        arrayOfJoints[0].transform.localPosition = server.positionForJoints[0];
        //right shoulder to right elbow
        arrayOfJoints[1].transform.localPosition = server.positionForJoints[2];
        //right elbow to right wrist
        arrayOfJoints[2].transform.localPosition = server.positionForJoints[3];

        


    }
}
