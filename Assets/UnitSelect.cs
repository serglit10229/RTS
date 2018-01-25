using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour {

	Camera cam;
	public GameObject selectionCirclePrefab;
	public bool objectSelected = false;
	SelectableUnitComponent selectableObject;
	//public bool selected = false;
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
				selectableObject = hit.collider.GetComponent<SelectableUnitComponent> ();
				//Debug.Log ("HIT");
				if (hit.collider.tag == "SelectableUnit") {
					//Debug.Log ("SelectableUnit");
					//SelectableUnitComponent selectableObject = GetComponent(SelectableUnitComponent);
					selectableObject.selected = true;
					objectSelected = true;

				} 
				if (Input.GetMouseButtonDown (0)) 
				{
					
					if (objectSelected == true) {
						//SelectableUnitComponent selectableObject = GetComponent(SelectableUnitComponent) ();
						selectableObject.Deselect ();
					}
				}
			}
		}
	}
}
