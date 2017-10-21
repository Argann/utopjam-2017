using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : Deplacement {

    private float horizontal;

    private float vertical;
	
	// Update est appelée à chaque frame.
    // C'est mieux de récupérer les Input dans cette boucle, et de faire le mouvement
    // dans le Fixed Update.
	void Update () {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
	}

    // On applique le mouvement récupéré dans le Update
    void FixedUpdate() {
        Move(new Vector2(horizontal, vertical));
    }

}
