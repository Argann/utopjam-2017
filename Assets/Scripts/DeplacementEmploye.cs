using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEmploye : Deplacement {

    /// <summary>
    /// Représente la distance minimale où on considère que l'employé à bien atteint le point.
    /// </summary>
    [SerializeField]
    private float distanceMinimale;

    public float DistanceMinimale {
        get { return distanceMinimale; }
        set { distanceMinimale = value; }
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

    /// <summary>
    /// Chemin que l'employé doit effectuer
    /// </summary>
    [SerializeField]
    private List<Transform> chemin;

    public List<Transform> Chemin {
        get { return chemin; }
        set { chemin = value; }
    }

    void FixedUpdate() {
        // Si il reste du chemin à parcourir.
        if(chemin.Count > 0) {
            // On récupère le prochain point de destination.
            Transform destination = chemin[0];
            // Si l'employé est déjà arrivé sur le point...
            if (Vector2.Distance(destination.position, transform.position) < distanceMinimale) {
                // On enlève le point de la liste des points à atteindre.
                chemin.Remove(destination);
                // Si c'était le dernier, on stoppe l'employé.
                if (chemin.Count == 0) {
                    Move(Vector2.zero, 0f);
                }
            } else {
                // S'il n'est pas encore arrivé à destination, on l'envoi au point.
                Move((destination.position - transform.position).normalized, vitesseTravail);
            }
        }
    }
}


