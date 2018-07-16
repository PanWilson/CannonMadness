using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField]
    public GameObject MainCamera;

    [SerializeField]
    public GameObject Cannon;

    [SerializeField]
    public bool debug;

    string CurrScene;

    void Awake()
    {
        if (Instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        debug = true;
        UberLoader uber;
        if(uber = (UberLoader)FindObjectOfType(typeof(UberLoader)))
        {
            MainCamera = uber.MainCamera;
            Cannon = uber.cannon;
        }
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(CurrScene);
        CurrScene = sceneName;
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            MainCamera.GetComponent<CameraController>().SetTarget(Cannon.transform.Find("CameraSlot").gameObject);
            Cannon.GetComponent<CannonController>().controlled = true;
        }

    }

    void OnGUI()
    {
        if (debug)
        {
            float deltaTime = 0.0f;
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 4 / 100;
            style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
            float msec = Time.deltaTime * 1000.0f;
            deltaTime += (Time.unscaledDeltaTime - deltaTime);
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, Mathf.Round(1.0f / deltaTime));
            GUI.Label(rect, text, style);
        }
    }

    public void SetCamera(GameObject go)
    {
        if(!go)
            MainCamera = go;
    }

    public void SetCannon(GameObject go)
    {
        if (!go)
            Cannon = go;
    }

    public void ChangeCameraMode(CameraMode cm, GameObject target = null)
    {
        CameraController cc = MainCamera.GetComponent<CameraController>();
        if (!target)
            cc.SetTarget(target);

        cc.SetMode(cm);
    }
}
