using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEmploye : Deplacement {

    private List<Transform> chemin;

    public List<Transform> Chemin {
        get { return chemin; }
        set { chemin = value; }
    }

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


