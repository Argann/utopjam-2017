using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeplacementEmploye))]
public class ComportementEmploye : MonoBehaviour {

    public enum EtatEmploye {
        Travaille,
        Glande,
        VaGlander
    }

    /// <summary>
    /// Etat actuel de l'employé. Est-ce que cette feignasse travaille ou pas ?
    /// </summary>
    [SerializeField]
    private EtatEmploye etat;

    public EtatEmploye Etat {
        get { return etat; }
        set { etat = value; }
    }

    /// <summary>
    /// Temps minimal que l'employé va passer à bosser.
    /// </summary>
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tempsTravailMinimum;

    public float TempsTravailMinimum {
        get { return tempsTravailMinimum; }
        set { tempsTravailMinimum = value; }
    }

    /// <summary>
    /// Temps maximal que l'employé va passer à travailler.
    /// </summary>
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tempsTravailMaximum;

    public float TempsTravailMaximum {
        get { return tempsTravailMaximum; }
        set { tempsTravailMaximum = value; }
    }

    /// <summary>
    /// Liste des chemins que l'employé peut suivre pour aller glander
    /// </summary>
    [SerializeField]
    private List<Chemin> chemins;

    public List<Chemin> Chemins {
        get { return chemins; }
        set { chemins = value; }
    }

    private float cooldown;

    // Use this for initialization
    void Start () {
        VaTravailler();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (etat == EtatEmploye.Travaille && cooldown > 0f) {
            cooldown -= Time.deltaTime;
        }

        if (etat == EtatEmploye.Travaille && cooldown < 0f) {
            VaGlander();
        }

	}

    /// <summary>
    /// Fonction à appeler quand on veut que l'employe bosse.
    /// </summary>
    public void VaTravailler() {
        GetComponent<DeplacementEmploye>().Chemin = new List<Transform>();
        etat = EtatEmploye.Travaille;
        cooldown = Random.Range(tempsTravailMinimum, tempsTravailMaximum);
    }

    /// <summary>
    /// Fonction à appeler quand on veut que l'employé aille glander.
    /// </summary>
    public void VaGlander() {
        etat = EtatEmploye.VaGlander;
        GetComponent<DeplacementEmploye>().Chemin = new List<Transform>(chemins[Random.Range(0, chemins.Count)].points);
    }
}
