using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopoutScript : MonoBehaviour {


	[Range(0.2f,5.0f)]
	public float time = 1.0f;
	TextMeshProUGUI text;
	Vector3 startPosition;
	public GameObject objParent;
	
	void Start() {
	text = GetComponent<TextMeshProUGUI>();
	startPosition = transform.position;	
	StartCoroutine(Destroy());
	
	}
	void Update () {
		if(objParent)
			transform.position=objParent.transform.position;

		transform.position = Vector3.Slerp(transform.position,startPosition+Vector3.up*5.0f,Time.deltaTime*2*time);

		transform.LookAt(Camera.main.transform);
		
		text.color = new Color(text.color.r,text.color.g,text.color.b,Mathf.Lerp(1.0f,0,Time.time));
	}

	public IEnumerator Destroy(){
		yield return new WaitForSecondsRealtime(time*3);
		Destroy(transform.parent.gameObject);
	}
}
