using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoeudChemin : MonoBehaviour {

    [SerializeField]
    private List<NoeudChemin> voisins;

    public List<NoeudChemin> Voisins {
        get { return voisins; }
        set { voisins = value; }
    }


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
