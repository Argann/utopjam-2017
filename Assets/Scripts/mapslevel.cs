using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapslevel : MonoBehaviour {

	public GameObject wallPrefab;
	private const float WALLWIDTH = 2f;
	private const float WALLHEIGHT = 20.1f;
	private const int NBPOSITIONS = 4;

	// Use this for initialization
	void Start () {
		
		// Liste des Vector3
		Vector3[] positions = new Vector3[NBPOSITIONS];
		positions[0] = new Vector3(0*WALLHEIGHT,0*WALLHEIGHT,0);
		positions[1] = new Vector3(1*WALLHEIGHT,0*WALLHEIGHT,0);
		positions[2] = new Vector3(0*WALLHEIGHT,1*WALLHEIGHT,0);
		positions[3] = new Vector3(1*WALLHEIGHT,1*WALLHEIGHT,0);

		// Liste des Quaternions
		Quaternion[] rotation = new Quaternion[NBPOSITIONS];
		rotation[0] = new Quaternion(0,0,0,0);
		rotation[1] = new Quaternion(0,0,90,0);
		rotation[2] = new Quaternion(0,0,90,0);
		rotation[3] = new Quaternion(0,0,0,0);

		for (int i = 0 ; i < NBPOSITIONS ; i++) {
			Instantiate(wallPrefab, positions[i], rotation[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
