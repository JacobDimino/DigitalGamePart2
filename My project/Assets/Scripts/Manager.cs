using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //strings of orbs
    public List<List<GameObject>> orbStrings = new List<List<GameObject>>();

    public List<GameObject> allOrbs = new List<GameObject>();

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("manager started");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            foreach (GameObject orb in allOrbs)
            {
                if (orb.gameObject.GetComponent<Enemy>() != null)
                {
                    orb.gameObject.GetComponent<Enemy>().gamedOver = true;
                }
            }

            SceneManager.LoadSceneAsync(2);
        }
    }
}
