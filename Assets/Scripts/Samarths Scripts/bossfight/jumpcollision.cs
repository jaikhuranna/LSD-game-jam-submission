using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpcollision : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("floor"))   
        {
            player.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            StartCoroutine(jumpDelay());
        }
    }

    IEnumerator jumpDelay()
    {
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<Collider2D>().enabled = true;
    }
}
