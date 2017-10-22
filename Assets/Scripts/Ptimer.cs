using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ptimer : MonoBehaviour {

    Text timer;

    [SerializeField]
    private float vitesseJeu;

    private int minutes;

    private float timeStart;

    private float hourStart;
    private int hour;
    private string[] jours = new string[]
    {
        "Fri",
        "Sat",
        "Sun"
    };
    private int jourStart;
    public ProgressBar barreprogression;

    private int jourpasses;

    // Use this for initialization
    void Awake() {
        timeStart = Time.time;
        hourStart = 18;
        jourStart = 0;
        timer = GetComponent<Text>();
        jourpasses = 0;
    }

    public int GetHeuresPasses() 
    {
        if (jourpasses == 0)
            return hour-18;
        else if (jourpasses == 1)
        {
            return hour+6;
        }
        else
        {
            return hour + 30;
        }
    }

    public int GetMinutesPasses()
    {
        return minutes;
    }

    // Update is called once per frame
    void Update () {
        if (jourStart == 2 && hour >= 18)
        {
            mauvaisesfins();
            // timeStart = Time.time;
        }
        else
        {
            float t = (Time.time - timeStart) * vitesseJeu;

            minutes = (int)(t % 60);

            hour = ((int)(hourStart + (t / 60)));

            if (hour >= 24)
            {
                timeStart = Time.time;
                hourStart = 0;
                hour = 0;
                jourStart++;
                jourpasses++;
            }

            string jour = jours[jourStart];

            timer.text = jour + " " + hour + " " + minutes;
        }
	}

    void mauvaisesfins()
    {
        int stade;
        float pourcentageprogression = barreprogression.GetSliderValue();
        if (pourcentageprogression>=.75f)
        {
            stade = 3;
        }
        else if(pourcentageprogression >= .5f)
        {
            stade = 2;
        }
        else if (pourcentageprogression >= .25f)
        {
            stade = 1;
        }
        else
        {
            stade = 0;
        }
        PlayerPrefs.SetInt("stade", stade);
        PlayerPrefs.SetInt("heure", 0);
        PlayerPrefs.SetInt("minutes", 0);
        PlayerPrefs.SetInt("fin", (false ? 1 : 0));

        SceneManager.LoadScene("GameOver");
    }
}
