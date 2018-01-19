using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	public Interactables focus;

	public LayerMask movementMask;

	Camera cam;
	PlayerMotor motor;


	// Use this for initialization
	void Start () {
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
			
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100, movementMask)) {
				motor.MoveToPoint (hit.point);
				//Move to

				RemoveFocus ();
			}


		}

		if (Input.GetMouseButtonDown (0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {
				Interactables interactable = hit.collider.GetComponent<Interactables> ();
				if (interactable != null) 
				{
					SetFocus (interactable);
				}

			}


		}
			
	}

	void SetFocus (Interactables newFocus)
	{
		if (newFocus != focus)
		{
			if (focus != null) 
				focus.OnDefocused ();
			focus = newFocus;
			motor.FollowTarget (newFocus);
		}
		newFocus.OnFocused (transform);
	}

	void RemoveFocus ()
	{
		if (focus != null)
			focus.OnDefocused ();
		focus = null;
		motor.StopFollowingTarget ();
	}
}
