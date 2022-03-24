using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour {
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            AudioManager.instance.Play("Chest");
            GetComponent<Animator>().SetTrigger("Chest");
            GameController.numberOfCoins += 50;
            PlayerPrefs.SetInt("NumberOfCoins", GameController.numberOfCoins);
            StartCoroutine(LoadNextLevel());

            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            collision.GetComponent<Collider2D>().enabled = false;

            
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<GameController>().NextLevel();
    }
}