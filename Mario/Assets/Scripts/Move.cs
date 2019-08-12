using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    

    public int nrovidas;
    public int nromoedas;

    public Text txtvidas;
    public Text txtmoedas;

    private Vector2 posInicial;

    public AudioSource sompulo;
    public AudioSource sommorte;

    bool nochao = false; //para verificar se o objeto esta em contato com o solo
    public Transform objeto; // para determinar os limites/centro do objeto
    public LayerMask layer; //a Layer que sera detectado o contato com o solo

    private void Start()
    {
        posInicial = transform.position;
    }

    void FixedUpdate()
    {
        txtvidas.text = nrovidas.ToString();
        txtmoedas.text = nromoedas.ToString();

        
    }
         
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("chao"))
        {
            GetComponent<Animator>().SetBool("pulando", false);
            GetComponent<Animator>().SetFloat("velocidade", 0);
        }

        if (collision.transform.tag.Equals("plataformamovel"))
        {
            GetComponent<Animator>().SetBool("pulando", false);
            GetComponent<Animator>().SetFloat("velocidade", 0);
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("plataformamovel"))
        {
            transform.parent = null;
        }
    }

    public void Morte()
    {
        nrovidas--;
        transform.position = posInicial;
        sommorte.Play();

        if (nrovidas <= 0)
        {
            StartCoroutine("esperasommorte");
        }
    }

    IEnumerator esperasommorte()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);

    }
}
