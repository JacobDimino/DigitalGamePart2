using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //strings of orbs
    public List<List<GameObject>> orbStrings = new List<List<GameObject>>();

    public List<GameObject> allOrbs = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("manager started");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
