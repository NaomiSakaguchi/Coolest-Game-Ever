using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour // script attached to the Checkpoint object
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameController.lastCheckpointPos = transform.position;
            GetComponent<SpriteRenderer>().color = Color.white;
            AudioManager.instance.Play("Checkpoint");
        }
    }
}
