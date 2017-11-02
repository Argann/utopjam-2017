using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPersonnage : MonoBehaviour {

    [SerializeField]
    private GameObject joueur;

    [SerializeField]
    private bool followMouse;
	
	// Update is called once per frame
	void Update () {
        if (followMouse) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 distanceMousePlayer = (mousePos - joueur.transform.position).normalized;
            transform.position = new Vector3(joueur.transform.position.x + distanceMousePlayer.x, joueur.transform.position.y + distanceMousePlayer.y, transform.position.z);
        } else {
            transform.position = new Vector3(joueur.transform.position.x, joueur.transform.position.y, transform.position.z);
        }
        



	}
}
