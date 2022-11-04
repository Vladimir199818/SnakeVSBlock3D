using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip FoodTakeAudio;
    public AudioClip BlockDestroy;
    public AudioClip Background;
    [Min(0)]
    public float Volume;

    private AudioSource Audio;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        Audio.Play();
    }

    public void TakeFoodAudio()
    {
        Audio.PlayOneShot(FoodTakeAudio, Volume);
    }

    public void DestroyBlock()
    {
        Audio.PlayOneShot(BlockDestroy);
    }

    private void OnEnable()
    {
        Audio.PlayOneShot(Background);
    }

    private void OnDisable()
    {
        Audio.Stop();
    }
}
