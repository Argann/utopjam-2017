using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour {
    // Speed by employee, of the evolution of the game.
    public Ptimer Temps;
	public float vitesse;

	// Set to 0, depends on how many employees are actually working.

	private static int nbEmployees;

	private const int MIN = 0;
	private const int MAX = 1;

	private Slider slider;

	// Use this for initialization
	void Start () {
		slider = GameObject.FindGameObjectWithTag("progressBar").GetComponent<Slider>();
		nbEmployees = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(nbEmployees);
		slider.value = slider.value + vitesse * nbEmployees;
		if ( slider.value >= MAX ) {
			vitesse = -vitesse;
			ProgressBar.IncrementEmployees();
            // MOCK of end condition
            bonnesfins();
        }
	}

    public float GetSliderValue()
    {
        return slider.value;
    }

	public static void IncrementEmployees() {
		nbEmployees++;
	}

    public static void DecrementEmployees() {
		nbEmployees--;
	}

    void bonnesfins()
    {
        PlayerPrefs.SetInt("stade", 3);
        PlayerPrefs.SetInt("heure", Temps.GetHeuresPasses());
        PlayerPrefs.SetInt("minutes", Temps.GetMinutesPasses());
        PlayerPrefs.SetInt("fin", (true ? 1 : 0));

        SceneManager.LoadScene("GameOver");
    }
}
