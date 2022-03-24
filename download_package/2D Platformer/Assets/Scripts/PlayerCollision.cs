using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour 
    // este script é attached ao Player e detecta as colisões dele contra todos os enemies com colliders para ativar o GameOver Panel
{
    Vector2 hitKick = new Vector2(50f, 50f);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.transform.tag == "Enemy")
        {
            GameController.isGameOver = true;
            // vai alterar o bool isGameOver do GameController (que é public static e pode então ser usado aqui) para verdadeiro

            AudioManager.instance.Play("GameOver");

            gameObject.SetActive(false); //  vai desabilitar o Player (game object que está com este script attached)
        }*/

        if (collision.transform.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().velocity = hitKick * new Vector2(-transform.localScale.x, 1.1f);
            FindObjectOfType<GameController>().ProcessPlayerDeath();

            /*GameController.isGameOver = true;
            // vai alterar o bool isGameOver do GameController (que é public static e pode então ser usado aqui) para verdadeiro

            AudioManager.instance.Play("GameOver");

            gameObject.SetActive(false); //  vai desabilitar o Player (game object que está com este script attached)*/
        }

        if (collision.transform.tag == "Hole")
        {
            GameController.isGameOver = true;
            // vai alterar o bool isGameOver do GameController (que é public static e pode então ser usado aqui) para verdadeiro

            AudioManager.instance.Play("GameOver");

            gameObject.SetActive(false); //  vai desabilitar o Player (game object que está com este script attached)
        }


        if (collision.transform.tag == "Zombie")
        {
            GetComponent<Rigidbody2D>().velocity = hitKick * new Vector2(-transform.localScale.x, 1.1f);
            FindObjectOfType<GameController>().ProcessPlayerDeath();

            /*GameController.isGameOver = true;
            // vai alterar o bool isGameOver do GameController (que é public static e pode então ser usado aqui) para verdadeiro

            AudioManager.instance.Play("GameOver");

            gameObject.SetActive(false); //  vai desabilitar o Player (game object que está com este script attached)*/
        }

    }
}
