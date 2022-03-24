using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls; // para "referenciar" o Player Control
    public Animator animator; // referenciar na Unity o animator do Player
    public GameObject bullet; // referenciar o bullet na Unity
    public Transform bulletHole; // empty game object criado na frente do Player de onde sairá o bullet, refernciar na Unity
    public float force = 2000f; // força da bullet

    private void Awake()
    {
        controls = new PlayerControls(); // para pegar o Player Control
        controls.Enable(); // enable o Player Control

        controls.Land.Shoot.performed += ctx => Fire(); // atribui ao shoot a função Fire
    }

    void Fire()
    {
        animator.SetTrigger("shoot"); // trigger a animação de "shoot"

        // instancia o bullet na posição do transform do bulletHole e na rotação da própria bullet e salva na variável go
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);

        AudioManager.instance.Play("Bullet");

        if (GetComponent<PlayerMovement>().isFacingRight) // se o Player estiver facingRight (importar do PlayerMovements)
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force); // pega o rigidbody do go e atribui uma força (que move o bullet pra direita e com força da variável force
        }
        else // se o Player estiver facingLeft
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force); // pega o rigidbody do go e atribui uma força (que move o bullet pra esquerda e com força da variável force
        }
        Destroy(go, 1.4f); // o bullet é destruído após 1.5s
    }
}
