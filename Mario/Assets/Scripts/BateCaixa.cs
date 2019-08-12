using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateCaixa : MonoBehaviour
{

    public AnimationCurve curva;
    private float t;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.contacts[0].point.y < transform.position.y)
        {
            StartCoroutine("sample");
        }
    }

    IEnumerator sample()
    {
        Vector2 pos = transform.position;

        for (float t = 0; t < curva.keys[curva.length - 1].time; t += Time.deltaTime)
        {
            //if (pos.y + 0.5f > pos.y + curva.Evaluate(t) / 2)
            //{
                transform.position = new Vector2(pos.x, pos.y + curva.Evaluate(t) / 2);
                yield return null;
            //}
        }
        transform.position = new Vector2(pos.x, pos.y);
    }
}
