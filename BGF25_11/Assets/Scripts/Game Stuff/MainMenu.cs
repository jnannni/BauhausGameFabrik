using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private bool gameExists;
    public Button loadGameButton;

    private void Start()
    {
        gameExists = false;
        if (!gameExists)
        {
            loadGameButton.enabled = false;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void LoadGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
