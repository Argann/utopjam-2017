using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text TITRE;
    public Text FIN;

    [SerializeField]
    private bool Jeufini;
    [SerializeField]
    private int heure;
    [SerializeField]
    private int minute;
    [SerializeField]
    private int stade;

    private string[] Titre = new string[]
    {
        "FELICITATIONS !!",
        "TIME'S UP !!"
    };

    private string[] fins = new string[]
    {
        "Tu as trop procrastiné sur Game Jam Simulator",
        "Tu as maté tes collègues tir-au-flanc, te voilà la terreur de la Game Jam",
        "Il reste du temps. VITE, PLUS DE FEATURE FAINEANT !",
        "C'était moins une, la prochaine fois il faudra prendre le martinet !",
        "Tu y étais presque ! Force est de constater que tes collègues savent bien se cacher",
        "Les features essentielles pour faire un jeu ne sont pas là, mais tu peux toujours faire un financement participatif pour gagner du pognon.",
        "Le prototype n'est même pas prêt ! Au moins, les Developpeurs se sont éclatés à leurs LAN partie",
        "Le plus gros procrastinateur ici, C'est TOI !"
    };

    // Use this for initialization
    void Start () {
		if (Jeufini)
        {
            if (minute > 0)
                heure--;
            TITRE.text = Titre[0]+ "\n Tu as fait un jeu en " + (48 - heure) + " heures et " + (60 - minute) + " minutes";
            if ((48 - heure)<=24)
            {
                FIN.text = fins[0];
            }
            else if ((48 - heure) <= 30)
            {
                FIN.text = fins[1];
            }
            else if ((48 - heure) <= 36)
            {
                FIN.text = fins[2];
            }
            else
            {
                FIN.text = fins[3];
            }
        }
        else
        {
            TITRE.text = Titre[1];
            switch (stade)
            {
                case (3):
                    FIN.text = fins[4];
                    break;
                case (2):
                    FIN.text = fins[5];
                    break;
                case (1):
                    FIN.text = fins[6];
                    break;
                default:
                    FIN.text = fins[7];
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void retouraudebut()
    {
        SceneManager.LoadScene("debut");
    }
}
