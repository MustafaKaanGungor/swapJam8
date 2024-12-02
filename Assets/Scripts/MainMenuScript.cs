using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
//Ana menü Allaha emanet çalışıyor ellemeyin sonra bir ayar daha çekecem
//Brightness Çalışmıyor
//abdül ben scene manager1 adlı bir script oluşturdum . orda oyun scene nine geçme ve exit fonksiyonları oluşturdum onları kullan , hepsi tek bir yerde olsun

public class MainMenuScript : MonoBehaviour
{
    public string gameLoad;
    [Header("Brightness Settings")]
    [SerializeField] private Volume brightnessVolume;
    private ColorAdjustments brightnessvalue;
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


    
    public void Brightness(float brightness)
    {
        brightnessVolume.profile.TryGet(out brightnessvalue);
        brightnessvalue.postExposure.value = brightness;
    }

    public void DontDestroyAudioManager(GameObject AudioManager)
    {
        DontDestroyOnLoad(AudioManager);
    }

    

   
    

}
