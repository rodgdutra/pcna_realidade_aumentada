using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Draws a sine wave using a line renderer
/// </summary>

public class Graph : MonoBehaviour {

    public float min_x = (float)-0.5;
    public float max_x = (float)0.5;
    public int resolution = 100;
    public float height = 1;
    public float phase = 0;
    public float frequency = 2;

    LineRenderer lr;
    Vector3[] positions;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        DrawGraph();
    }
	
	// Update is called once per frame
	void Update () {
        // updates the phase in each update event
        phase = Time.time;
        DrawGraph();
	}

    //Calculate graph and set points on line renderer
    void DrawGraph()
    {   
        float x_increment = ((min_x*-1) + max_x)/(resolution);

        positions = new Vector3[resolution];
        lr.positionCount = positions.Length;

        // Position 0
        positions[0].x = min_x;
        positions[0].y = 0;
        positions[0].z = height * Mathf.Sin(2*3);

        for (int index = 1; index < positions.Length; ++index)
        {
            // Update the positions by each index 
            positions[index].x = positions[index-1].x + x_increment;
            positions[index].y = 0;
            positions[index].z = height * Mathf.Sin(2*3*index+phase);

        }

        lr.SetPositions(positions);
    }

    //Returns Y on the graph given X
    public float FindHeight(float x)
    {
        float newHeight = 0.0f;
        newHeight = height * Mathf.Sin(x);
        return newHeight;
    }
}
