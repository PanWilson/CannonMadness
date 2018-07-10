using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsEvent : MonoBehaviour {

    public List<Ring> rings;

    private void Awake()
    {
        InitializeRings();
    }

    void InitializeRings()
    {
        rings = new List<Ring>();
        for (int i = 0; i < transform.childCount; i++)
        {
            rings.Add(transform.GetChild(i).GetComponent<Ring>());
        }
    }

}
