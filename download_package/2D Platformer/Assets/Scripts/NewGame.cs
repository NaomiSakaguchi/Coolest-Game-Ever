using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
 
    public void New()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
        AudioManager.instance.Play("Click");
    }
}
