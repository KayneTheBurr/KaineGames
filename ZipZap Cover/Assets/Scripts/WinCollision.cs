using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollision : MonoBehaviour
{
    public GameObject winCircle, innerCircle;
    public Vector3 bigScale, smallScale;
    public float scaleTimeX, scaleTimeY;
    public float scaleX = 0.374f, scaleY = 0.374f, velocityX = 0.0f, velocityY = 0.0f;

    //timer variables
    public bool inCircle, winRound;
    public float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        
        scaleTimeX = 0.25f;
        scaleTimeY = 0.25f;
        scaleX = 0.375f;
        scaleY = 0.375f;
    }

    // Update is called once per frame
    void Update()
    {
        if( winCircle != null)
        {
            float newScaleX = Mathf.SmoothDamp(winCircle.transform.localScale.x, scaleX, ref velocityX, scaleTimeX);
            float newScaleY = Mathf.SmoothDamp(winCircle.transform.localScale.y, scaleY, ref velocityY, scaleTimeY);
            winCircle.transform.localScale = new Vector3(newScaleX, newScaleY, 1.0f);
        }
       
        if( inCircle == true && winRound == false)
        {
            currentTime += Time.deltaTime;

            if( currentTime >= 2.5f)
            {
                winRound = true;
                currentTime = 0;
                winCircle.SetActive(false);
                Debug.Log("WinRound!");
            }
        }
        else
        {
            currentTime = 0;
        }

    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("WinItem"))
        {
            
            innerCircle.SetActive(false);
            scaleX = 0.75f;
            scaleY = 0.75f;
            inCircle = true;

        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("WinItem"))
        {
            innerCircle.SetActive(true);
            scaleX = 0.375f;
            scaleY = 0.375f;
            inCircle = false;
        }
    }
}
