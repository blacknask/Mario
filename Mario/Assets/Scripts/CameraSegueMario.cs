using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegueMario : MonoBehaviour
{

    public GameObject player;
    Rigidbody2D rb;
    Vector3 deslocamento = new Vector3(6, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.position = player.transform.position + deslocamento;
    }

}
