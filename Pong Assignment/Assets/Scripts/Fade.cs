using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    SpriteRenderer rend;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    IEnumerator FadeIn() {
        for (float f = 0.05f; f <= 1; f += 0.05f) {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOut() {
        for (float f = 1f; f >= -0.0f; f -= 0.025f) {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFade() {
        StartCoroutine("FadeOut");
        // StartCoroutine("FadeIn");
        // StartCoroutine("FadeOut");
    }
}
