using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollapse : MonoBehaviour
{
    WinCollision winScript;
    public bool hasFallen;
    public GameObject screwHead;


    // Start is called before the first frame update
    void Start()
    {
        winScript = FindObjectOfType<WinCollision>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] screws = GameObject.FindGameObjectsWithTag("Screw");
        
        Rigidbody2D[] rbs = FindObjectsOfType<Rigidbody2D>();
        

        if ( winScript.winRound == true && hasFallen == false)
        {
            Debug.Log("rbs:" + rbs.Length);
            for (int j = 0; j < screws.Length; j++)
            {
                Destroy(screws[j]);
            }

            for ( int i = 0; i < rbs.Length; i++)
            {
                rbs[i].constraints = RigidbodyConstraints2D.None;
                
            }
            Invoke(nameof(JointDestroyer), 0.5f);
            hasFallen = true;
        }
    }

    void JointDestroyer()
    {
        HingeJoint2D[] joints = GameObject.FindObjectsOfType<HingeJoint2D>();
        Debug.Log("joints:" + joints.Length);
        for (int j = 0; j < joints.Length; j++)
        {
            Destroy(joints[j]);
        }
        Debug.Log("all down");
    }
}
