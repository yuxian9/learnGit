using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--------Audio Clip--------")]
    public AudioClip background;
    public AudioClip driving;

    private static MusicController instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set the instance to this and don't destroy it on scene load
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    private void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
