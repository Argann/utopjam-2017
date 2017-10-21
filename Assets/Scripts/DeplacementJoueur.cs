using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : Deplacement {

    private float horizontal;

    private float vertical;

    public static bool isFighting = false;

    /// <summary>
    /// Vitesse de déplacement de l'entité.
    /// </summary>
    [SerializeField]
    [Range(0, 5f)]
    private float speed;

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    // Update est appelée à chaque frame.
    // C'est mieux de récupérer les Input dans cette boucle, et de faire le mouvement
    // dans le Fixed Update.
    void Update () {
        if (!isFighting) {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
	}

    // On applique le mouvement récupéré dans le Update
    void FixedUpdate() {
        Move(new Vector2(horizontal, vertical), speed);
    }

    public static void setFightingStance(bool fight) {
        isFighting = fight;
    }
}
