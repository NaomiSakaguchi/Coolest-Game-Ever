using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour // script attached to the Coin object
{
    private void OnTriggerEnter2D(Collider2D collision) // metodo ativado caso algum objeto entre no collider da coin
    {
        
        if(collision.transform.tag == "Player") // se a tag do objeto que colide com a Coin for Player
        {
            GameController.numberOfCoins++; // o numberOfCoins do GameController � incrementado em 1
            AudioManager.instance.Play("Coins"); // o FSx Coins � tocado

            PlayerPrefs.SetInt("NumberOfCoins", GameController.numberOfCoins);
            // o PlayerPrefs armazena valores na memoria, no caso, vai armazenar na string "NumberOfCoins" a vari�vel numberOfCoins do GameController

            Destroy(gameObject); // o objeto attached to this script � destru�do. opcional tempo de delay para a destrui��o (gameObject, 0.5f)
        }
    }
}
