using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class GrabEmploye : MonoBehaviour {

    private bool tientEmploye;
    public Canvas canvasTartes;
    public Slider cptTartes;
    private bool dualActive;

    [SerializeField]
    private Animator animHaut;

    void Start() {
        tientEmploye = false;
        estPresEmploye = null;
        estPresPoste = null;
        dualActive = false;
    }

    private GameObject estPresEmploye;

    private GameObject estPresPoste;

    public GameObject joueur;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Employe") && !tientEmploye) {
            estPresEmploye = coll.gameObject;
        }
        if (coll.CompareTag("Poste")) {
            estPresPoste = coll.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        // if (coll.CompareTag("Employe") && !tientEmploye) {
        //     estPresEmploye = null;
        // }
        if (coll.CompareTag("Poste")) {
            estPresPoste = null;
        }
    }

    void Update() {
        if (estPresEmploye && Input.GetAxisRaw("Jump") > 0
            && !tientEmploye
            && !estPresEmploye.GetComponent<ComportementEmploye>().IsWorking()) {
            PrendEmploye();
        }

        if (estPresPoste && Input.GetAxisRaw("Jump") > 0 && tientEmploye) {
            if (!estPresPoste.GetComponent<PosteDeTravail>().ContientEmploye) {
                PoseEmploye();
            }
        }
    }

    public void PrendEmploye() {
        if (!dualActive) {
            dualActive = true;
            animHaut.SetBool("grabbing", true);
            Epreuve();
            estPresEmploye.transform.SetParent(this.transform);
            estPresEmploye.SetActive(false);
        }
    }

    public void PoseEmploye() {
        tientEmploye = false;
        estPresEmploye.SetActive(true);
        estPresEmploye.GetComponent<ComportementEmploye>().VaTravailler();
        estPresEmploye.transform.SetParent(null);
        estPresEmploye.transform.position = estPresPoste.transform.position;
        animHaut.SetBool("grabbing", false);
        estPresEmploye = null;
    }

    private void Epreuve() {
        estPresEmploye.GetComponent<ComportementEmploye>().Fight();
        DeplacementJoueur.setFightingStance(true);
        SpamTarteDansTaTronche();
    }

    public void SpamTarteDansTaTronche() {
        joueur.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        canvasTartes.gameObject.SetActive(true);
        cptTartes.value = 0f;
    }

    public void IncrementTartes() {
        Debug.Log("ah que coucou");
        cptTartes.value += 0.1f;
        if (cptTartes.value >= 1f) {
            canvasTartes.gameObject.SetActive(false);
            DeplacementJoueur.setFightingStance(false);
            dualActive = false;
            tientEmploye = true;
        }
    }
}
