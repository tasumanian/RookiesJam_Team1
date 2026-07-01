using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private AudioSource SESource;
    [SerializeField]
    private AudioSource BGMSource;
    [SerializeField]
    private AudioClip[] BGMClips;


    public  void PlaySE(AudioClip clip)
    {
        SESource.PlayOneShot(clip);
    }
    public void PlayBGM(int index)
    {
        if (index >= 0 && index < BGMClips.Length)
        {
            BGMSource.clip = BGMClips[index];
            BGMSource.Play();
        }
    }
    public void StopBGM()
    {
        BGMSource.Stop();
    }
    public void StartBGM()
    {
        BGMSource.Play();
    }
}