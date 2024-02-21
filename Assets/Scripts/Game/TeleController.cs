using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleController : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    AudioManager audioManager;

    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                audioManager.PlayerSFX(audioManager.portalIn);
                player.transform.position = destination.transform.position;
            }
            
        }
    }

   
}
