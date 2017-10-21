using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEmploye : Deplacement {

    enum EtatEmploye {
        Travaille,
        VaGlander,
        Glande,
        VaTravailler
    }

    /// <summary>
    /// Vitesse de déplacement de l'employé pour aller travailler.
    /// </summary>
    [SerializeField]
    [Range(0, 5f)]
    private float vitesseTravail;

    public float VitesseTravail {
        get { return vitesseTravail; }
        set { vitesseTravail = value; }
    }

    /// <summary>
    /// Vitesse de déplacement de l'employé pour aller glander.
    /// </summary>
    [SerializeField]
    [Range(0, 5f)]
    private float vitesseGlande;

    public float VitesseGlande {
        get { return vitesseGlande; }
        set { vitesseGlande = value; }
    }

    private List<Transform> chemin;

    public List<Transform> Chemin {
        get { return chemin; }
        set { chemin = value; }
    }

    

    void 


    void FixedUpdate() {

        if(chemin.Count > 0) {
            Transform destination = chemin[0];
            if (transform.Equals(destination)) {
                chemin.Remove(destination);
            } else {
                Vector2 direction = new Vector2(
                        Mathf.Abs(destination.position.x - transform.position.x) > 1 ? 1f : destination.position.x - transform.position.x,
                        Mathf.Abs(destination.position.y - transform.position.y) > 1 ? 1f : destination.position.y - transform.position.y
                    );
            }
        }

    }





}


