using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 1.5f; // velocidade do inimigo
    public float range = 2f; // range

    float startingY; //posi��o y inicial do inimigo
    int dir = 1; // dire��o, se positiva � para cima, se negativa � para baixo

    
    void Start()
    {
        startingY = transform.position.y; // atribui � vari�vel startingY o valor do y do inimigo
    }

    // FixedUpdate � usado para mover objetos. Update � usado para pegar inputs
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime * dir);

        if(transform.position.y < startingY || transform.position.y > startingY + range)
        {
            dir *= -1;
        }
    }
}
