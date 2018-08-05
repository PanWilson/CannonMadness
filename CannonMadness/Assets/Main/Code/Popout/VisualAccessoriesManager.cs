using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualAccessoriesManager : MonoBehaviour {

	private static VisualAccessoriesManager _instance;
	public static VisualAccessoriesManager Instance { get { return _instance; } }


	public GameObject TextPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CratePopOut(){
		Instantiate(TextPrefab);
	}
	public void CratePopOut(GameObject elementToBuckle){
		Instantiate(TextPrefab);
		TextPrefab.GetComponentInChildren<PopoutScript>().objParent = elementToBuckle;
	}
}
