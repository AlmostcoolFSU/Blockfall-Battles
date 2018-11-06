using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMaterial : MonoBehaviour {

    public Material[] randomMaterial;
    //private Material mat;

	void Start () {
        //mat = GetComponent<Renderer>().material;
        this.gameObject.GetComponent<Renderer>().material = randomMaterial[Random.Range(0, randomMaterial.Length)];
    }
}
