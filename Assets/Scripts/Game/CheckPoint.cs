using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameController gameController;
    AudioManager audioManager;

    SpriteRenderer spriteRenderer;
    Collider2D coll;
    public Sprite passive,active;

    public Transform respawnPoint;
    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlayerSFX(audioManager.checkpoint);
            gameController.UpdateCheckpoint(respawnPoint.position);
            spriteRenderer.sprite = active;
            coll.enabled = false;
        }
    }

}
