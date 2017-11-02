using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class LumierePiece : MonoBehaviour {

    private SpriteRenderer sr;

    private BoxCollider2D bc;

    [SerializeField]
    private float speed;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Joueur")) {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeOut");
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.CompareTag("Joueur")) {
            StopCoroutine("FadeOut");
            StartCoroutine("FadeIn");
        }
    }

    private void ChangeAlpha(float alpha) {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
    }

    private IEnumerator FadeIn() {
        while (sr.color.a < 0.8f) {
            ChangeAlpha(sr.color.a + Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator FadeOut() {
        while (sr.color.a > 0) {
            ChangeAlpha(sr.color.a - Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }
}
