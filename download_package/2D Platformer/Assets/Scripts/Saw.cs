using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour // script attached to the Saw object
/*{
    public float speed = 2;
    int dir = 1;

    //referenciar pelo Inspector
    public Transform rightCheck;
    public Transform leftCheck;

    // FixedUpdate é usando para mover objetos e com ele deve ser usado fixed.DeltaTime e não time.DeltaTime
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * dir * Time.fixedDeltaTime);

        // o Raycast forma um vetor que aponta 2 unidades para baixo que verifica se o objeto (rightcheck) está tocando a plataforma
        // quando ele não estiver mais tocando a plataforma a sua direção muda de sentido
        if (Physics2D.Raycast(rightCheck.position, Vector2.down, 2) == false)
        {
            dir = -1;
        }

        if (Physics2D.Raycast(leftCheck.position, Vector2.down, 2) == false)
        {
            dir = 1;
        }
    }
}
*/

{
public float speed; // velocidade em que a serra vai de um lado para outro
public float moveTime; // variável para definir o tempo em que a serra muda de direção

private bool dirRight; // define se a serra vai para o lado direito ou esquerdo
private float timer; // contador de tempo

// Update is called once per frame
void Update()
{
    if (dirRight) // se verdadeiro, a serra vai para a direita
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    else // se falso, a serra vai para a esquerda
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    timer += Time.deltaTime; // o timer começa em 0 e vai sendo incrementado pelo deltatime (que é o tempo do jogo)

    if (timer >= moveTime) // quando o tempo bater o moveTime (que será setado na Unity)
    {
        dirRight = !dirRight; // vai inverter o booleano
        timer = 0f; // o tempo reseta para 0, para iniciar nova contagem de tempo
    }
}
}
