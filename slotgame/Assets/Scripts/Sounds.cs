using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    [SerializeField]
    private AudioSource winMoneyAudio;

    [SerializeField]
    private AudioSource pullHandleAudio;

    [SerializeField]
    private AudioSource buttonClikAudio;

    [SerializeField]
    private AudioSource insertMoneyAudio;

    [SerializeField]
    private AudioSource payOutWinAudio;

    [SerializeField]
    private AudioSource payOutLoseAudio;

    public AudioSource mainThemeAudio;

    public void WinSound()
    {
        winMoneyAudio.time = 0.1f;
        winMoneyAudio.Play();
    }
    
    public void PullHandleSound()
    {
        pullHandleAudio.time = 0.1f;
        pullHandleAudio.Play();
    }

    public void ButtonClickSound()
    {
        buttonClikAudio.time = 0.1f;
        buttonClikAudio.Play();
    }

    public void InsertMoneySound()
    {
        insertMoneyAudio.time = 0.1f;
        insertMoneyAudio.Play();
    }

    public void PayOutWinSound()
    {
        payOutWinAudio.time = 1f;
        payOutWinAudio.Play();
    }

    public void PayOutLoseSound()
    {
        payOutLoseAudio.time = 0.1f;
        payOutLoseAudio.Play();
    }

    public void PauseMusic()
    {
        mainThemeAudio.Pause();
    }

    public void PlayMusic()
    {
        mainThemeAudio.Play();
    }
}
