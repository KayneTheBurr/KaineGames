using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject winCircle;
    public HingeJoint2D playerHingeL;
    public HingeJoint2D playerHingeR;
    public JointMotor2D hingeMotor;
    public float motorSpd;

    // Start is called before the first frame update
    void Start()
    {
        playerHingeL.useLimits = false;
        playerHingeR.useLimits = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if( playerHingeL != null & playerHingeR != null)
            {
                playerHingeL.useLimits = true;
                playerHingeR.useLimits = false;
                playerHingeR.useMotor = false;
                playerHingeL.useMotor = true;
            }
            
           
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (playerHingeL != null & playerHingeR != null)
            {
                playerHingeR.useLimits = true;
                playerHingeL.useLimits = false;
                playerHingeL.useMotor = false;
                playerHingeR.useMotor = true;
            }
                
        }

        
    }

    
}
