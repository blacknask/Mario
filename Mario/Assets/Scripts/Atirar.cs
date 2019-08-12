using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Transform posicaotiro;
    public bool podeatirar;
    public GameObject bala;
    public float tempoespera = 0.4f;
    private bool viradoparaesquerda;
    private Vector3 deslocapos = new Vector3(0.5f,0,0);

    void Start()
    {
        podeatirar = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && podeatirar)
        {

            if (GetComponent<SpriteRenderer>().flipX)
            {
                GameObject objeto = Instantiate(bala, transform.position - deslocapos, transform.rotation) as GameObject;
                objeto.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 300);
            }
            else
            {
                GameObject objeto = Instantiate(bala, transform.position + deslocapos, transform.rotation) as GameObject;
                objeto.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300);
            }
            podeatirar = false;
            StartCoroutine("HabilitaTiro");
        }
    }

    IEnumerator HabilitaTiro()
    {
        yield return new WaitForSeconds(tempoespera);
        podeatirar = true;
    }
}
