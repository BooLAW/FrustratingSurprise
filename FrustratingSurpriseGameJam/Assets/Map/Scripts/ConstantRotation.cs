using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {

    public float speed = 2.0f;

	void Update () {
        transform.parent.Rotate(new Vector3(0.0f, 0.0f, speed));
	}
}
