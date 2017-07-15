using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	private Camera mainCamera;

	void Start () {

		mainCamera = FindObjectOfType<Camera> ();
		
	}
	

	void Update () {

		Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
		Plane GroundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayLength;

		if (GroundPlane.Raycast (cameraRay, out rayLength)) {

			Vector3 pointToLook = cameraRay.GetPoint (rayLength);
			Debug.DrawLine (cameraRay.origin, pointToLook, Color.green);

			transform.LookAt (new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
		}
	}
}
