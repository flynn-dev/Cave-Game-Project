using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

	public bool Active = true; //this variable controls whether or not the camera movement is on
	public float interpVelocity;
	//public float minDistance;
	//public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (target && Active)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.5f);

		}
	}

	//this allows other scripts to turn off the camera
	public void TurnOff() {
		Active = false;
	}
}