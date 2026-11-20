using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private AudioSource SESource;
    [SerializeField]
    private AudioSource BGMSource;
    [SerializeField]
    private AudioClip[] BGMClips;

    [SerializeField]
    private InputActionMap rollBack;

    bool isBack = false;
    private void Start()
    {
        foreach(InputAction action in rollBack.actions)
        {
            action.Enable();
        }
    }
    private void Update()
    {
        if (rollBack.actions[0].IsPressed() && rollBack.actions[1].IsPressed() && isBack == false)
        {
            isBack = true;
            Debug.Log("gotitle");
            SceneManager.LoadScene("TitleScene");
        }
    }
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