using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ptimer : MonoBehaviour {

    Text timer;

    [SerializeField]
    private float vitesseJeu;

    private float timeStart;

    private float hourStart;
    private int hour;
    private string[] jours= new string[]
    {
        "vendredi",
        "samedi",
        "dimanche"
    };
    private int jourStart;

	// Use this for initialization
	void Awake () {
        timeStart = Time.time;
        hourStart = 18;
        jourStart = 0;
        timer = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (jourStart == 2 && hour >= 18)
        {
            timer.text = "Game Over";
        }
        else
        {
            float t = (Time.time - timeStart) * vitesseJeu;

            int minutes = (int)(t % 60);

             hour = ((int)(hourStart + (t / 60)));

            if (hour >= 24)
            {
                timeStart = Time.time;
                hourStart = 0;
                hour = 0;
                jourStart++;
            }

            string jour = jours[jourStart];

            timer.text = jour + " " + hour + " " + minutes;
        }
	}
}
