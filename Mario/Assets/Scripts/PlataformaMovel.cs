using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{

    public float distancia;
    public float velocidade;
    public bool esquerda;
    Vector3 posInicial;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (esquerda)
        {
            transform.Translate(-velocidade, 0, 0);

            if ((transform.position.x < posInicial.x - distancia) || (transform.position.x > posInicial.x))
            {
                velocidade = -velocidade;
            }
        }
        else
        {
            transform.Translate(velocidade, 0, 0);

            if ((transform.position.x > posInicial.x + distancia) || (transform.position.x < posInicial.x))
            {
                velocidade = -velocidade;
            }
        }
    }


}
