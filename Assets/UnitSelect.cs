using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour {

	Camera cam;
	public GameObject selectionCirclePrefab;
	public bool selected = false;
	//public GameObject prevSelect; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			//Debug.Log ("Click");
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

			if (Physics.Raycast (ray, out hit)) 
			{
				//Debug.Log ("HIT");
				if (hit.collider.tag == "SelectableUnit") {
					//Debug.Log ("SelectableUnit");
					SelectableUnitComponent selectableObject = hit.collider.GetComponent<SelectableUnitComponent> ();

					if (selected == false) {
						//Debug.Log ("Foreach");
						selectableObject.selectionCircle = Instantiate (selectionCirclePrefab);
						selectableObject.selectionCircle.transform.SetParent (selectableObject.transform, false);
						selectableObject.selectionCircle.transform.eulerAngles = new Vector3 (90, 0, 0);
						selected = true;

						//prevSelect = selectableObject;
					}
					if (selected == true ) {
						if (Input.GetMouseButtonDown (0)) 
						{
							Destroy (selectableObject.selectionCircle.gameObject);
							selectableObject.selectionCircle = null;
							selected = false;
						}
					}
				} 
				/*
				else 
				{
					SelectableUnitComponent selectableObject = hit.collider.GetComponent<SelectableUnitComponent> ();
					//Destroy (prevSelect.selectionCircle.gameObject);
					//prevSelect.selectionCircle = null;
				}*/
			}

		}
	}
}
