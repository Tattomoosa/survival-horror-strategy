using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// so you can, for example, use a light in editor and it
// will turn itself off while testing
public class DisableOnPlay : MonoBehaviour {
	void Start () {
        gameObject.SetActive(false);
	}
}
