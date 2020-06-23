using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tile: MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        // if (Application.isEditor && !Application.isPlaying)
        // {
            transform.position = new Vector3(
                    Mathf.Round(transform.position.x),
                    Mathf.Round(transform.position.y),
                    Mathf.Round(transform.position.z)
                );
        // }
	}
}
