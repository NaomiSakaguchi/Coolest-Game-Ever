using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour // script attached to the Parallax object
// este script cria um background image automaticamente para frente e para trás (sideBG) de um bgcentral (middleBG), dependendo da posição da camera
{
    // assign objects in Unity
    public Transform mainCamera;
    public Transform middleBG;
    public Transform sideBG;

    public float length = 57.6f; // o tamanho (lateral) da background image

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.position.x > middleBG.position.x)
        {
            sideBG.position = middleBG.position + Vector3.right * length;
        }

        if (mainCamera.position.x < middleBG.position.x)
        {
            sideBG.position = middleBG.position + Vector3.left * length;
        }

        if (mainCamera.position.x > sideBG.position.x || mainCamera.position.x < sideBG.position.x)
        {
            Transform z = middleBG;
            middleBG = sideBG;
            sideBG = z;
        }
    }
}
