using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UberLoader : MonoBehaviour {

    [SerializeField]
    string managerSceneName;

    [SerializeField]
    public GameObject MainCamera;

    [SerializeField]
    public GameObject cannon;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            SceneManager.LoadSceneAsync(managerSceneName, LoadSceneMode.Additive);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
