
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------ Audio Clip ------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip checkpoint;
    public AudioClip portalIn;
    public AudioClip portalOut;
    public AudioClip Jump;

   
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlayerSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
