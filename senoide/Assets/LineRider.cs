using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRider : MonoBehaviour {

    public Graph myGraph;
    public float weight;
    Vector3 newPos = Vector3.zero;

    

	// Use this for initialization
	void Start () {
        myGraph = FindObjectOfType<Camera>().GetComponent<Graph>();
    }
	
	// Update is called once per frame
	void Update () {
        newPos = transform.position;
        newPos.y = myGraph.FindHeight(newPos.x);
        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * weight);
        Debug.Log(newPos);
	}
}

