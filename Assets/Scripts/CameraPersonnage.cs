using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPersonnage : MonoBehaviour {

    [SerializeField]
    private GameObject joueur;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(joueur.transform.position.x, joueur.transform.position.y, transform.position.z);
	}
}
