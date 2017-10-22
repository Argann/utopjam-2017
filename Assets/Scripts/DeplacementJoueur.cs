using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : Deplacement {

    private static float horizontal;

    private static float vertical;

    public static bool isFighting = false;
    [SerializeField]
    private Animator animHaut;

    [SerializeField]
    private Animator animBas;

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

        animHaut.SetBool("idle", !(horizontal > 0 || horizontal < 0 || vertical < 0 || vertical > 0));
        animBas.SetBool("idle", !(horizontal > 0 || horizontal < 0 || vertical < 0 || vertical > 0));

        Vector3 direction = new Vector2(horizontal, vertical);

        Vector3 persoPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 destPos = Camera.main.WorldToScreenPoint(transform.position + direction);
        Vector3 dir = destPos - persoPos;
        animBas.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));


        Move(new Vector2(horizontal, vertical), speed);
    }

    public static void setFightingStance(bool fight) {
        isFighting = fight;
        horizontal = 0;
        vertical = 0;
    }
}
