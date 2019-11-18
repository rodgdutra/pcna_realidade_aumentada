using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Draws a sine wave using a line renderer
/// </summary>

public class Graph_result : MonoBehaviour {

    public float min_x = (float)-0.5;
    public float max_x = (float)0.5;
    public int resolution = 100;
    public float height = 1;
    public float phase = 0;
    public float time = 0 ;
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
        time = Time.time + phase;
        DrawGraph();
	}

    //Calculate graph and set points on line renderer
    void DrawGraph()
    {   // Get the 2 waves parameters
        float wave1_height    = GameObject.Find("onda_1").GetComponent<Graph>().height;
        float wave1_phase     = GameObject.Find("onda_1").GetComponent<Graph>().phase;
        float wave1_frequency = GameObject.Find("onda_1").GetComponent<Graph>().frequency;

        float wave2_height    = GameObject.Find("onda_2").GetComponent<Graph>().height;
        float wave2_phase     = GameObject.Find("onda_2").GetComponent<Graph>().phase;
        float wave2_frequency = GameObject.Find("onda_2").GetComponent<Graph>().frequency;

        float wave1_z = 0;
        float wave2_z = 0;

        // x increment calculation
        float x_increment = ((min_x*-1) + max_x)/(resolution);

        positions = new Vector3[resolution];
        lr.positionCount = positions.Length;

        // Position 0
        positions[0].x = min_x;
        positions[0].y = 0;
        wave1_z = wave1_height * Mathf.Sin(2 * 3 * wave1_frequency + wave1_phase);
        wave2_z = wave2_height * Mathf.Sin(2*3*wave2_frequency*+wave2_phase);
        positions[0].z = wave1_z+ wave1_z;

        for (int index = 1; index < positions.Length; ++index)
        {
            // Update the positions by each index 
            positions[index].x = positions[index-1].x + x_increment;
            positions[index].y = 0;
            wave1_z = wave1_height * Mathf.Sin(2 * 3 * wave1_frequency * index + wave1_phase + time);
            wave2_z = wave2_height * Mathf.Sin(2 * 3 * wave2_frequency * index + wave2_phase + time);
            positions[index].z = wave1_z + wave2_z;

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
