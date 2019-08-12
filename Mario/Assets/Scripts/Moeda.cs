using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    bool naopegoumoeda = true;

    void FixedUpdate()
    {
        transform.Rotate(0, 10, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag.Equals("Player") && naopegoumoeda))
        {
            GetComponent<AudioSource>().Play();
            collision.GetComponent<Move>().nromoedas++;
            StartCoroutine("esperasommoeda");
            naopegoumoeda = false;
        }
    }

    IEnumerator esperasommoeda()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }





    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
           //Destroy(gameObject);
        }
    }

}
