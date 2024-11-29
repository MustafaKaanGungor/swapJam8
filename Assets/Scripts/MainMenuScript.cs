using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;
//Ana menü Allaha emanet çalışıyor ellemeyin sonra bir ayar daha çekecem
//Brightness Çalışmıyor

public class MainMenuScript : MonoBehaviour
{
    public string gameLoad;
    [Header("Brightness Settings")]
    [SerializeField] private TextMeshProUGUI brightnessTextValue = null;
    [SerializeField] private Slider brightnessSlider = null;
    [Header("Volume Settings")]
    [SerializeField] private TextMeshProUGUI volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    


    public void LoadGame()
    {
        SceneManager.LoadScene(gameLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Volume(float volume)
    {
        AudioListener.volume  = volume;
        volumeTextValue.text = Mathf.RoundToInt(volume).ToString();
    }


    //Brightness Çalışmıyor.
    public void Brightness(float brightness)
    {
        Screen.brightness = Mathf.Clamp01(brightness);
        brightnessTextValue.text = Mathf.RoundToInt(brightness).ToString();
    }

    

}
