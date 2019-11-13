using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Draws a sine wave using a line renderer
/// </summary>

public class Graph : MonoBehaviour {

    public bool centre;
    public bool useControls;
    public string freqAxis;
    public string heightAixs;

    public float frequency;
    public float height;
    public float slant;

    public float dampenChange = 10;
    public int heightMax = 10;
    public int heightMin = -10;
    public float freqMax = 20;
    public float freqMin = 2;

    public int length = 1;
    

    LineRenderer lr;
    Vector3[] positions;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();

        
        DrawGraph();
    }
	
	// Update is called once per frame
	void Update () {

        DrawGraph();

        if (useControls)
            Controls();
	}

    //Calculate graph and set points on line renderer
    void DrawGraph()
    {
        positions = new Vector3[(2 + (int)frequency * 3) * length];
        lr.positionCount = positions.Length;


        for (int index = 0; index < positions.Length; ++index)
        {
            if (frequency > 0)
            {
                if (centre)
                    positions[index].x = ((index / frequency)  - length)/10 ;
                else
                    positions[index].x = (index / frequency)/10 ;
            }
            else
            {
                positions[index].x = index/10 ;
            }

            positions[index].y = 0;

            positions[index].z = height * Mathf.Sin(index);
        }

        lr.SetPositions(positions);
    }

    //Use Input Axis to alter FreqAxis and HeightAxis within min/max ranges
    void Controls()
    {
        //Height
        if(Input.GetAxis(heightAixs) > 0.1 || (Input.GetAxis(heightAixs) < 0.1))
        {
           // Debug.Log("Input");
            if (height <= heightMax && height >= heightMin)
                height += Input.GetAxis(heightAixs) / dampenChange;
            else if (height < heightMin)
                height = heightMin;
            else if (height > heightMax)
                height = heightMax;
        }

        //Frequency
        if (Input.GetAxis(freqAxis) > 0.1 || Input.GetAxis(freqAxis) < 0.1)
        {
            if (frequency <= freqMax && frequency >= freqMin)
               frequency -= Input.GetAxis(freqAxis) / dampenChange;
            else if (frequency < freqMin)
                frequency = freqMin;
            else if (frequency > freqMax)
                frequency = freqMax;
        }
    }

    //Returns Y on the graph given X
    public float FindHeight(float x)
    {
        float newHeight = 0.0f;
        newHeight = height * Mathf.Sin(x);
        return newHeight;
    }
}
