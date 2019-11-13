using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class rotacao : MonoBehaviour {
    public GameObject arrows; 
    public float velocidadeRotacao;
    void Update () {
            transform.RotateAround(arrows.transform.position, new Vector3(0,1,0), velocidadeRotacao * Time.deltaTime);
    }
}