using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointScript : MonoBehaviour
{
    public GameObject[] arrayOfJoints;
    public Server server;
    [SerializeField]
    private Transform[] parent;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        arrayOfJoints[0].transform.localPosition = new Vector2(0, 0);
        float newb = Vector2.Distance(server.positionForJoints[2],arrayOfJoints[0].transform.position);
        arrayOfJoints[1].transform.localPosition = new Vector2(arrayOfJoints[0].transform.position.x+newb, arrayOfJoints[0].transform.position.y + newb);

        /* float newshoulderX = remap(server.positionForJoints[0].x,0, 368, 0,3);
         float newshouldery = remap(server.positionForJoints[0].y, 0, 368, 0,3);

         float newelbowX = remap(server.positionForJoints[2].x, 0, 368, 0, 3);
         float newelbowy = remap(server.positionForJoints[2].x, 0, 368, 0, 3);

         float newwristx = remap(server.positionForJoints[3].y, 0, 368, 0, 3);
         float newwristy = remap(server.positionForJoints[3].y, 0, 368, 0, 3);*/


        /*
        arrayOfJoints[0].transform.parent = null;
        arrayOfJoints[0].transform.position = server.positionForJoints[0];
        arrayOfJoints[0].transform.parent = parent[0];
        arrayOfJoints[0].transform.position = server.positionForJoints[0];

        arrayOfJoints[1].transform.parent = null;
        arrayOfJoints[1].transform.position = server.positionForJoints[2];
        arrayOfJoints[1].transform.parent = parent[1];
        arrayOfJoints[1].transform.position = server.positionForJoints[2];

        arrayOfJoints[2].transform.parent = null;
        arrayOfJoints[2].transform.position = server.positionForJoints[3];
        arrayOfJoints[2].transform.parent = parent[2];
        arrayOfJoints[2].transform.position = server.positionForJoints[3];*/

        //arrayOfJoints[3].transform.position = new Vector3(0,0,0);

        /*for (int i = 0; i < joints.Length; i++)
        {
            if (joints[i].name != "shoulder")
            {
                joints[i].transform.parent = null;
            }

            joints[i].transform.position = newpos[i];

            if (joints[i].name != "shoulder")
            {
                joints[i].transform.parent = parents[i];
                joints[i].transform.localPosition = newpos[i];
            }

        }*/

    }
    public static float remap(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}
