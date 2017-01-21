using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buildBlueprint : MonoBehaviour 
{
	public Texture2D heightmap;

	// Use this for initialization
	void Start () 
	{
		BeginBlueprint ();
	}

	void Update() 
	{
	
	}

	void BeginBlueprint()
	{
		//Iterattion for pixels
		for(int z = 0; z < heightmap.height; z++)
		{
			for(int x = 0; x < heightmap.width; x++)
			{
				//Grab current pixel colour
				Color pixelCol = heightmap.GetPixel (x,z);
				float alpha = pixelCol.a;

				if(alpha>0f)
				{
					//CubeGen();
					//Add cube if pixel is not white
					//CubeGenn(new IntVector(X,Y), alpha);
				}
			}

		}

	}
}
