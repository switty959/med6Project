using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    public GameObject[] joints;
    public Vector2[] newpos;
    public Transform[] parents;
    public Server server;
    // Start is called before the first frame update
    void Start()
    {
        server = GetComponent<Server>();
    }

    // Update is called once per frame
    void Update()
    {
        newpos[0] = transform.InverseTransformPoint(server.positionForJoints[0]) ;
        newpos[1] = transform.InverseTransformPoint(server.positionForJoints[2]);
        newpos[2] = transform.InverseTransformPoint(server.positionForJoints[3]);

        joints[0].transform.position = newpos[0];
        joints[1].transform.localPosition = newpos[1];
        joints[2].transform.localPosition = newpos[2];
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

        }
        for (int i = 0; i < joints.Length; i++)
        {
            if (i==0)
            {
                joints[i].transform.position = newpos[0];
            }
            else if (i == 1)
            {
                joints[i].transform.position = (newpos[1]+ newpos[0])/2;
            }
            else if (i == 2)
            {
                joints[i].transform.position = newpos[1];
            }
        }*/
    }
}
