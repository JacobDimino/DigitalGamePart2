using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 2;

    Player player;
    Manager manager;
    Transform oldTransform;


    bool didAttach = false;
    bool shouldAttach = false;
    bool touchingPlayer = false;

    public bool destroyed = false;


    // Start is called before the first frame update
    void Start()
    {
       player = FindObjectOfType<Player>();
       manager = FindAnyObjectByType<Manager>();
       Transform oldTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //once the enemy has collided with the player. STOP!
        if (!touchingPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //stops as soon as it hits something
        speed = 0;
        transform.parent = player.transform;
        
        if (other.gameObject.tag == "Player")
        {
            touchingPlayer = true;
        }
        
        Debug.Log("collided");

        // if the colors are the same
        if (other.gameObject.tag == tag && !destroyed)
        {
            Debug.Log("Same type");
            //check to see if im in a list already BY
            //getting each list
            foreach (List<GameObject> listOfStrings in manager.orbStrings)
            {
                Debug.Log("new string of orbs");

                //getting each item in each list
                foreach (GameObject g in listOfStrings)
                {
                    Debug.Log("in new orbs");

                    //if THAT GUY is in the list 
                    if (other.gameObject == g)
                    {
                        //i should get in the list
                        Debug.Log("I should attach");
                        shouldAttach = true;
                    }
                }

                if (shouldAttach)
                {
                    //im a part of the lists
                    listOfStrings.Add(gameObject);
                    Debug.Log("added to prev list");
                    didAttach = true;
                    shouldAttach = false;
                }

                //if more than 2 guys in the list
                if (listOfStrings.Count >= 3)
                {
                    
                    for (int i = 0; i < listOfStrings.Count; i++)
                    {
                        //explode 
                        destroyed = true;
                        Destroy(listOfStrings[i].GameObject());
                        Debug.Log("destoryyyy");
                    }
                }
            }

            if (!didAttach)
            {
                //OTHERWISE
                //add self to orb strings
                manager.orbStrings.Add(new List<GameObject> { gameObject });

                Debug.Log("added new list w self");
            }
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("EXIT COLLID");
        speed = 2;
        transform.parent = oldTransform;
    }

}
