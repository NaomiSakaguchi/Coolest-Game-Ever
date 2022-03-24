using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 1.5f; // velocidade do inimigo
    public float range = 2f; // range

    float startingY; //posição y inicial do inimigo
    int dir = 1; // direção, se positiva é para cima, se negativa é para baixo

    
    void Start()
    {
        startingY = transform.position.y; // atribui à variável startingY o valor do y do inimigo
    }

    // FixedUpdate é usado para mover objetos. Update é usado para pegar inputs
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime * dir);

        if(transform.position.y < startingY || transform.position.y > startingY + range)
        {
            dir *= -1;
        }
    }
}
