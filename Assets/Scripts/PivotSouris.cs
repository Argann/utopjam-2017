using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotSouris : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - objectPos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));
    }
}
