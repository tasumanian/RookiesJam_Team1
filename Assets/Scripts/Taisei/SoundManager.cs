using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private AudioSource SESource;


    public  void PlaySE(AudioClip clip)
    {
        SESource.PlayOneShot(clip);
    }
}