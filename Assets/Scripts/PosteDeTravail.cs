using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosteDeTravail : MonoBehaviour {

    [SerializeField]
    private bool contientEmploye;

    public bool ContientEmploye {
        get { return contientEmploye; }
        set { contientEmploye = value; }
    }

}
