using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 1f;
    public float minHeight = -10f;
    public float maxHeight = 5f;
    // Update is called once per frame
    bool upwardFlag = true;

    
    void Update()
    {   
        Vector3 newPos = transform.position;

        // if within the movable range 
        if (newPos.y > minHeight && newPos.y < maxHeight)
        {
            if (upwardFlag) // move the object upward 
            {
                newPos.y += speed;
                transform.position = newPos;
            }
               
            else // move it downward
            {
                newPos.y -= speed;
                transform.position = newPos;
            }
            
        }
        //after moving, check if the flag needs to be flipped
        // with flipping, put transform into (min, max) range
        if (transform.position.y >= maxHeight)
        {
            upwardFlag = false;
            newPos.y = maxHeight - 0.001f;
            transform.position = newPos; 

        }
           
        if (transform.position.y <= minHeight)
        {
            upwardFlag = true;
            newPos.y = minHeight + 0.001f;
            transform.position = newPos; 
        }
    }
}
