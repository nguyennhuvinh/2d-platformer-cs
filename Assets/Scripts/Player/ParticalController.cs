using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalController : MonoBehaviour
{
    [SerializeField] ParticleSystem moveParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVeloctity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;

    float counter;
    bool isOnGround;

    [SerializeField] ParticleSystem fallParticle;
    [SerializeField] ParticleSystem deathParticle;

    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if(isOnGround && Mathf.Abs(playerRb.velocity.x) > occurAfterVeloctity)
        {
            if(counter > dustFormationPeriod)
            {
                
                moveParticle.Play();
                counter = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            audioManager.PlayerSFX(audioManager.Jump);
            fallParticle.Play();
            isOnGround = true;
        }

        if (collision.CompareTag("Obstacle"))
        {
            deathParticle.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
