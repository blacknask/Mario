using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiBala : MonoBehaviour
{
    public float tempo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("iniciadestruicao");
    }


    IEnumerator iniciadestruicao()
    {
        yield return new WaitForSeconds(tempo);
        Destroy(this.gameObject);
    }
    
      

    // Update is called once per frame
    void Update()
    {
        
    }
}
