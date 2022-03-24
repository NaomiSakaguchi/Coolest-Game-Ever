using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MenuEvents : MonoBehaviour // script attached to the Canvas object
{
    // assign in Unity
    public Slider volumeSlider;
    public AudioMixer mixer;
    public TextMeshProUGUI coinsText;
    private float value;
        
    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
        
    }

    private void Start()
    {
        Time.timeScale = 1; // para que a animação ao retornar do Pause, volte ao tempo normal

        mixer.GetFloat("volume", out value); // quando o jogo inicia ele vai puxar o valor do volume setado no mixer
        volumeSlider.value = value; // e vai atribuir esse valor ao volumeSlider
    }

    private void Update()
    {
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("NumberOfCoins", 0);
    }

    public void LoadScene(int index)
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        AudioManager.instance.Play("Click");
        Application.Quit();
        Debug.Log("Game closed");
    }


}
