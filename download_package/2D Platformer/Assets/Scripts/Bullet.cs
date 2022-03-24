using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        */

        if(collision.tag == "Zombie")
        {
            collision.GetComponent<Zombie>().TakeDamage(25); // chama a fun��o TakeDamage da classe Zombie e passa um dano de 25
            Destroy(gameObject);
        }
    }
}
