using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : Deplacement {
	
	// Update est appelée à chaque frame
	void Update () {
        // Utilise le déplacement de la classe _Déplacement_...
        Move(
            // En récupérant un nouveau Vecteur2...
            new Vector2(
                // Contenant les axes de jeu (touches fléchées généralement)
                Input.GetAxisRaw("Horizontal"), 
                Input.GetAxisRaw("Vertical")
                )
            );
	}

}
