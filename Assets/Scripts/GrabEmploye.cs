using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GrabEmploye : MonoBehaviour {

    private bool tientEmploye;

    void Start() {
        tientEmploye = false;
        estPresEmploye = null;
        estPresPoste = null;
    }

    private GameObject estPresEmploye;

    private GameObject estPresPoste;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Employe") && !tientEmploye) {
            estPresEmploye = coll.gameObject;
        }
        if (coll.CompareTag("Poste")) {
            estPresPoste = coll.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.CompareTag("Employe") && !tientEmploye) {
            estPresEmploye = null;
        }
        if (coll.CompareTag("Poste")) {
            estPresPoste = null;
        }
    }

    void Update() {
        if (estPresEmploye && Input.GetAxisRaw("Jump") > 0 && !tientEmploye) {
            PrendEmploye();
        }

        if (estPresPoste && Input.GetAxisRaw("Jump") > 0 && tientEmploye) {
            PoseEmploye();
        }
    }

    public void PrendEmploye() {
        tientEmploye = true;
        estPresEmploye.transform.SetParent(this.transform);
        estPresEmploye.SetActive(false);
        
    }

    public void PoseEmploye() {
        tientEmploye = false;
        estPresEmploye.SetActive(true);
        estPresEmploye.GetComponent<ComportementEmploye>().VaTravailler();
        estPresEmploye.transform.SetParent(null);
        estPresEmploye.transform.position = new Vector2(estPresPoste.transform.position.x, estPresPoste.transform.position.y);
        
    }
}
