using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ComportementEmploye))]
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
    /// Vitesse de déplacement de l'employé pour aller glander.
    /// </summary>
    [SerializeField]
    [Range(0, 5f)]
    private float vitesse;

    public float Vitesse {
        get { return vitesse; }
        set { vitesse = value; }
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
                GetComponent<Animator>().SetBool("idle", true);
                // On enlève le point de la liste des points à atteindre.
                chemin.Remove(destination);
                // Si c'était le dernier, on stoppe l'employé.
                if (chemin.Count == 0) {
                    Move(Vector2.zero, 0f);
                    // Et on dis aussi qu'il commence à glander
                    GetComponent<ComportementEmploye>().Etat = ComportementEmploye.EtatEmploye.Glande;
                }
            } else {
                GetComponent<Animator>().SetBool("idle", false);
                // S'il n'est pas encore arrivé à destination, on l'envoi au point.
                Vector3 persoPos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 destPos = Camera.main.WorldToScreenPoint(destination.position);
                Vector3 dir = destPos - persoPos;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));

                Move(
                    (destination.position - transform.position).normalized,
                    vitesse
                    );
            }
        }
    }
}


