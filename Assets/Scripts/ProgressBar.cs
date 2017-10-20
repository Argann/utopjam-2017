using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour {
	// Speed by employee, of the evolution of the game.
	public float vitesse;

	// Set to 0, depends on how many employees are actually working.
	private static int nbEmployees;

	private const int MIN = 0;
	private const int MAX = 1;

	private Slider slider;

	// Use this for initialization
	void Start () {
		slider = GameObject.FindGameObjectWithTag("progressBar").GetComponent<Slider>();
		nbEmployees = 4;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = slider.value + vitesse * nbEmployees;
		if ( slider.value >= MAX ) {
			vitesse = -vitesse;
			ProgressBar.IncrementEmployees();
			// MOCK of end condition
			Debug.Log("YOU WIN !!");
		}
	}

	static void IncrementEmployees() {
		nbEmployees++;
	}

	static void DecrementEmployees() {
		nbEmployees--;
	}
}
