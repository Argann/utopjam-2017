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

    void Start() {
        tientEmploye = false;
        estPresEmploye = null;
        estPresPoste = null;
        dualActive = false;
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
        if (estPresEmploye && Input.GetAxisRaw("Jump") > 0
            && !tientEmploye
            && !estPresEmploye.GetComponent<ComportementEmploye>().IsWorking()) {
            PrendEmploye();
        }

        if (estPresPoste && Input.GetAxisRaw("Jump") > 0 && tientEmploye) {
            PoseEmploye();
        }
    }

    public void PrendEmploye() {
        if (!dualActive) {
            dualActive = true;
            Epreuve();
            tientEmploye = true;
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
        
    }

    private void Epreuve() {
        estPresEmploye.GetComponent<ComportementEmploye>().Fight();
        DeplacementJoueur.setFightingStance(true);
        // Choix de l'epreuve en random
        int rand = 1;//Random.Range(0, 2);
        Debug.Log(rand);
        switch(rand) {
            case 0:
                QTETest();
                break;
            case 1:
                Debug.Log("ICI");
                SpamTarteDansTaTronche();
                break;
            default:
                // Afficher un ptit truc drole
                Debug.Log("A gagner sans effort, on triomphe sans gloire...");
                break;
        }
        DeplacementJoueur.setFightingStance(false);
        dualActive = false;
    }

    public bool QTETest() {
        Debug.Log("QTE !!!!");
        return true;
    }

    public bool SpamTarteDansTaTronche() {
        canvasTartes.gameObject.SetActive(true);
        // cptTartes.gameObject.SetActive(true);
        // bool isPressed = false;
        // Debug.Log(cptTartes.value);
        // while (cptTartes.value < 1) {
        //     cptTartes.value += 0.01f;
        //     Debug.Log(Input.GetKeyDown(KeyCode.Mouse0));
        //     if(Input.GetKeyDown(KeyCode.Mouse0) && !isPressed) {
        //         cptTartes.value += 0.05f;
        //         isPressed = true;
        //         Debug.Log(Input.GetAxisRaw("Jump"));
        //         Debug.Log(isPressed);
        //     }
        //     while(Input.GetKeyUp(KeyCode.Mouse0));
            
        // }
        // cptTartes.value = 0;
        // cptTartes.gameObject.SetActive(false);
        return false;
    }

    public void IncrementTartes() {
        cptTartes.value += 0.01f;
    }
}
