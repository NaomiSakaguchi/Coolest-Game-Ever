using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls; // para "referenciar" o Player Control
    public Animator animator; // referenciar na Unity o animator do Player
    public GameObject bullet; // referenciar o bullet na Unity
    public Transform bulletHole; // empty game object criado na frente do Player de onde sair� o bullet, refernciar na Unity
    public float force = 2000f; // for�a da bullet

    private void Awake()
    {
        controls = new PlayerControls(); // para pegar o Player Control
        controls.Enable(); // enable o Player Control

        controls.Land.Shoot.performed += ctx => Fire(); // atribui ao shoot a fun��o Fire
    }

    void Fire()
    {
        animator.SetTrigger("shoot"); // trigger a anima��o de "shoot"

        // instancia o bullet na posi��o do transform do bulletHole e na rota��o da pr�pria bullet e salva na vari�vel go
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);

        AudioManager.instance.Play("Bullet");

        if (GetComponent<PlayerMovement>().isFacingRight) // se o Player estiver facingRight (importar do PlayerMovements)
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force); // pega o rigidbody do go e atribui uma for�a (que move o bullet pra direita e com for�a da vari�vel force
        }
        else // se o Player estiver facingLeft
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force); // pega o rigidbody do go e atribui uma for�a (que move o bullet pra esquerda e com for�a da vari�vel force
        }
        Destroy(go, 1.4f); // o bullet � destru�do ap�s 1.5s
    }
}
