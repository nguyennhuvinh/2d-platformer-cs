using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinsihPoint : MonoBehaviour
{

    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            SenceController.instance.NextLevel();
        }
       
    }
}
