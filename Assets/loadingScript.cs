using UnityEngine;
using System.Collections;

//This script simply puts up a 'loading graphic' whilst the blocks are rendered from image file

public class loadingScript : MonoBehaviour {

    float timeRem = 1.5f;

    // Use this for initialization
    void Start ()
    {
     
    }
	
	// Update is called once per frame
	void Update () {
        timeRem -= Time.deltaTime;
        GameObject cubeGen = GameObject.Find("mainTerrain");
        CubeGen2Items CG2I = cubeGen.GetComponent<CubeGen2Items>();

        if (CG2I.isLoaded && timeRem < 0)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
	}
}
