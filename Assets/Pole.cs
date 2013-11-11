using UnityEngine;
using System.Collections;

public class Pole : MonoBehaviour {
	public float angularSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation *= Quaternion.AngleAxis(angularSpeed * Time.deltaTime, Vector3.up);
	}
}
