using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Deplacement : MonoBehaviour {

    /// <summary>
    /// Rigidbody du joueur.
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Vitesse de déplacement de l'entité.
    /// </summary>
    [SerializeField]
    [Range(0,50f)]
    private float speed;

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    // Appelé lors de l'apparition de l'objet attaché.
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Permet de déplacer l'objet dans une direction précise.
    /// Elle doit être appelée à chaque boucle d'affichage.
    /// </summary>
    /// <param name="direction">
    /// Vector2 représentant la direction vers laquelle l'objet doit se déplacer
    /// </param>
    public void Move(Vector2 direction) {
        rb.velocity = direction * speed;
    }



}
