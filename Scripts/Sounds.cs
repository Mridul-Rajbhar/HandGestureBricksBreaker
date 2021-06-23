using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    #region Private Variables
    private AudioSource audioSource;
    #endregion

    #region Public Variables
    public AudioClip platform, wallsound, bricksound;
    #endregion

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void platformSound()
    {
        audioSource.clip = platform;
        audioSource.Play();
    }

    public void wallSound()
    {
        audioSource.clip = wallsound;
        audioSource.Play();
    }

    public void brickSound()
    {
        audioSource.clip = bricksound;
        audioSource.Play();
    }
}
