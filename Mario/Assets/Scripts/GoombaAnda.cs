using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAnda : MonoBehaviour

{
    public float force;
    public float distancia;
    public float velocidade;
    Vector3 posInicial;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-velocidade, 0, 0);

        if ((transform.position.x < posInicial.x - distancia) || (transform.position.x > posInicial.x))
        {
            GetComponent<SpriteRenderer>().flipX = 
                !GetComponent<SpriteRenderer>().flipX;
            velocidade = -velocidade;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.contacts[0].point.y > transform.position.y)
        {
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
            GetComponent<Animator>().SetBool("morreu", true);
            StartCoroutine("iniciadestruicao");
        }
        else
        {
            coll.gameObject.GetComponent<Move>().Morte();
        }
    }


    IEnumerator iniciadestruicao()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
