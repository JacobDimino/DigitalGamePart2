using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource sound;

    private void Awake()
    {
       if (instance == null)
       {
            instance = this;
       }
    }

    public void PlaySfxClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameobject
        AudioSource audioSource = Instantiate(sound, spawnTransform.position, Quaternion.identity);

        //assign the clip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //length of sound clip
        float clipLength = audioSource.clip.length;

        //destory after clip is done playing
        Destroy(audioSource.gameObject, clipLength);

    }

}
