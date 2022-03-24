using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {
    Transform target; // para pegar o player
    public Transform borderCheck; // para referenciar o borderCheck na Unity

    public Animator animator; // para pegar o animator do objeto (referenciar na Unity)
    public int enemyHP = 100; // variável que controla o HP do inimigo

    public Slider enemyHealthBar; // referenciar na Unity

    // Start is called before the first frame update
    void Start()
    {
        enemyHealthBar.value = enemyHP; // o enemyHeathBar vai iniciar com o valor do enemyHP, no caso 100
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        // ignora a colisão entre o collider do Player e do Zombie

    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.45f, 0.45f);
        }
        else
        {
            transform.localScale = new Vector2(-0.45f, 0.45f);
        }
    }

    public void TakeDamage(int damageAmount) // chamar esta função no script do Bullet, passando o parametro de dano
    {
        enemyHP -= damageAmount; // a cada damage reduz o enemyHP (em 25, no caso)
        enemyHealthBar.value = enemyHP; // atualiza o value do enemyHealthBar

        if (enemyHP > 0) // se o enemyHP estiver maior que 0
        {
            animator.SetTrigger("damage"); // vai triggar a animação de damage
        }
        else // se o enemyHP estiver menor que 0
        {
            // GetComponent<CapsuleCollider2D>().enabled = false; // vai desabilitar o collider do zombie
            Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            animator.SetTrigger("death"); // vai triggar a animação de death
            this.enabled = false; // desabilita este (this) script
            Destroy(gameObject, 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Hole")
        {
            gameObject.SetActive(false); //  vai desabilitar o Player (game object que está com este script attached)
        }
    }

}
