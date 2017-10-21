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
    private int heureConsomme;
    [SerializeField]
    private int minuteConsomme;
    [SerializeField]
    private int stadeJeu;

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
        heureConsomme = PlayerPrefs.GetInt("heure");
        minuteConsomme = PlayerPrefs.GetInt("minutes");
        stadeJeu = PlayerPrefs.GetInt("stade");
        Jeufini = (PlayerPrefs.GetInt("fin") != 0);
        if (Jeufini)
        {
            if (minuteConsomme > 0)
                heureConsomme--;
            TITRE.text = Titre[0]+ "\n Tu as fait un jeu en " + heureConsomme + " heures et " + minuteConsomme + " minutes";
            if ((heureConsomme)<=24)
            {
                FIN.text = fins[0];
            }
            else if ((heureConsomme) <= 30)
            {
                FIN.text = fins[1];
            }
            else if ((heureConsomme) <= 36)
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
            switch (stadeJeu)
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
