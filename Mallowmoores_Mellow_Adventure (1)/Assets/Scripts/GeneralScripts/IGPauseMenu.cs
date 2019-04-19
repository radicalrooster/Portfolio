using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class IGPauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool isMuted;
    public float volume;

    private void Update()
    {
        if (isMuted == true)
        {
            volume = -80;
        }
        else
        {
            volume = 0;
        }
        
        audioMixer.SetFloat("Volume", volume);
    }

    public void muteSound(bool muteSound)
    {
        isMuted = muteSound;
    }

    public void MainMenu(string level)
    {
        SceneManager.LoadScene(level);
    }
}
