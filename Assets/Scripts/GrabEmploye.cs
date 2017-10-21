using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GrabEmploye : MonoBehaviour {

    private bool tientEmploye;

    void Start() {
        tientEmploye = false;
    }

	void OnTriggerStay2D(Collider2D coll) {
        if (coll.CompareTag("Employe") && Input.GetAxisRaw("Jump") > 0 && !tientEmploye) {
            PrendEmploye();
        }

        if (coll.CompareTag("Poste") && Input.GetAxisRaw("Jump") > 0 && tientEmploye) {
            PoseEmploye();
        }
    }

    public void PrendEmploye() {
        tientEmploye = true;
    }

    public void PoseEmploye() {
        tientEmploye = false;
    }
}
