using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MovingObstacle
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            collision.transform.parent = this.transform;
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && transform.parent != null && transform.parent.gameObject.activeInHierarchy)
        {
            collision.transform.parent = null;
            
        }
    }
}
