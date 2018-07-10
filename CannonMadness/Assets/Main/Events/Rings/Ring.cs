using UnityEngine;

public class Ring : MonoBehaviour {

    public bool active;

    public void Deactivate()
    {
        active = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

}
