using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject target;    
    private float distance;
    public float minDist = 0.5f;
    private bool toInteract;

    private void Start()
    {
        toInteract = false;
    }

    // Update is called once per frame
    void Update()
    {        
        distance = Vector2.Distance(target.transform.position, this.gameObject.transform.position);
        if (distance < minDist)
        {
            toInteract = true;
            //Debug.Log("interactable");
        }
        else toInteract = true;        
    }
    
}
