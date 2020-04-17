using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvaderAudio : MonoBehaviour
{

    public static InvaderAudio Instance;

    [SerializeField] AudioClip[] invaderSounds;
    int audioArrayInt = 0;
    bool audioPlaying = false; // used to stop every invader playing the same sound


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    public bool IsAudioPlaying()
    {
        return audioPlaying;
    }

    public void PlayInvaderSounds()
    {
        StartCoroutine(InvaderSoundsCoroutine());
    }

    IEnumerator InvaderSoundsCoroutine()
    {
        if (!audioPlaying)
        {
            audioPlaying = true;
            AudioClip clip = invaderSounds[audioArrayInt];
            GetComponent<AudioSource>().PlayOneShot(clip);
            if (audioArrayInt >= 3) { audioArrayInt = 0; } else { audioArrayInt++; }
            yield return new WaitForSeconds(0.1f);
            audioPlaying = false;
        }
    }
}