using UnityEngine;
using System.Collections;

public class CubeGen2Items : MonoBehaviour
{
    #region Variables
	Texture2D heightmap;
	public Texture2D bottomFloor;
	public Texture2D midFloor;
	public Texture2D topFloor;
	int cubeAmount = 0;
	string cAmount = "Cube amount Total:";
	int YValue = 1;
	Color32[] colors;
	public Transform[] prefabs;
	string[] cubeNames;

    public bool isLoaded = false;

    #region TransformDecs and Name Decs
	public Transform PrefabCube; //Black default cube
	public Transform WPrefabCube; // White cube
	public Transform RPrefabCube; // Red cube
	public Transform LPrefabCube; // Lime Green cube
	public Transform BPrefabCube; // Blue cube
	public Transform YPrefabCube; // Yellow cube
	public Transform CPrefabCube; // Cyan cube
	public Transform MPrefabCube; // Magenta cube
	public Transform SPrefabCube; // Silver cube
	public Transform GreyPrefabCube; // Grey cube
	public Transform MaroonPrefabCube; // Maroon cube
	public Transform OPrefabCube; // Olive cube
	public Transform GPrefabCube; // Green cube
	public Transform PPrefabCube; // Purple cube
	public Transform TPrefabCube; // Teal cube
	public Transform NPrefabCube; // Navy cube
    #endregion

    #endregion
	// Use this for initialization
	void Start ()
	{

		colors = new Color32[16]; //holds the 16 colours
		prefabs = new Transform[16];//holds the prefabs connected to colours
		cubeNames = new string[16];//holds names of prefabs

		#region PrefabsAndColours
		//Following variables hold names, color values to compare to current pixel and their partner cube

		prefabs [0] = PrefabCube;
		cubeNames [0] = "BlackCube";
		colors [0] = new Color32 (0, 0, 0, 255); //Black	
		
		prefabs [1] = WPrefabCube; // White cube
		cubeNames [1] = "WhiteCube";
		colors [1] = new Color32 (255, 255, 255, 255); //White
		
		prefabs [2] = RPrefabCube; // Red cube
		cubeNames [2] = "RedCube";
		colors [2] = new Color32 (255, 0, 0, 255); //Red
		
		prefabs [3] = LPrefabCube; // Lime Green cube
		cubeNames [3] = "LimeCube";
		colors [3] = new Color32 (0, 255, 0, 255); //Lime Green
		
		prefabs [4] = BPrefabCube; // Blue cube
		cubeNames [4] = "BlueCube";
		colors [4] = new Color32 (0, 0, 255, 255); //Blue
		
		prefabs [5] = YPrefabCube; // Yellow cube
		cubeNames [5] = "Yellow";
		colors [5] = new Color32 (255, 255, 0, 255); //Yellow
		
		prefabs [6] = CPrefabCube; // Cyan cube
		cubeNames [6] = "CyanCube";
		colors [6] = new Color32 (0, 255, 255, 255); //Cyan
		
		prefabs [7] = MPrefabCube; // Magenta cube
		cubeNames [7] = "MagentakCube";
		colors [7] = new Color32 (255, 0, 255, 255); //Magenta
		
		prefabs [8] = SPrefabCube; // Silver cube
		cubeNames [8] = "SilverCube";
		colors [8] = new Color32 (192, 192, 192, 255); //Silver
		
		prefabs [9] = GreyPrefabCube; // Gray cube
		cubeNames [9] = "GreyCube";
		colors [9] = new Color32 (128, 128, 128, 255); //Gray
		
		prefabs [10] = MaroonPrefabCube; // Maroon cube
		cubeNames [10] = "MaroonCube";
		colors [10] = new Color32 (128, 0, 0, 255); //Maroon
		
		prefabs [11] = OPrefabCube; // Olive cube
		cubeNames [11] = "OliveCube";
		colors [11] = new Color32 (128, 128, 0, 255); //Olive
		
		prefabs [12] = GPrefabCube; // Green cube
		cubeNames [12] = "GreenCube";
		colors [12] = new Color32 (0, 128, 0, 255); //Green
		
		prefabs [13] = PPrefabCube; // Purple cube
		cubeNames [13] = "PurpCube";
		colors [13] = new Color32 (128, 0, 128, 255); //Purple
		
		prefabs [14] = TPrefabCube; // Teal cube
		cubeNames [14] = "TealCube";
		colors [14] = new Color32 (0, 128, 128, 255); //Teal
		
		prefabs [15] = NPrefabCube; // Navy cube
		cubeNames [15] = "NavyCube";
		colors [15] = new Color32 (0, 0, 128, 255); //Navy
		#endregion

		heightmap = bottomFloor; //Setting itteration to bottomFloor image
		CubeCheck ();
		YValue = 6;
		heightmap = midFloor;
		CubeCheck ();
		YValue = 10;
        //heightmap = topFloor;
        //CubeCheck ();
        isLoaded = true;
	}	

	void Update ()
	{
		
	}

	void OnGUI ()
	{
		GUI.Label (new Rect (10, 5, 100, 50), cAmount + cubeAmount.ToString ());		
	}

	void CubeCheck ()
	{
		int oldY = YValue;
		//Iterattion for pixels
		for (int z = 0; z < heightmap.height; z++) {			
			for (int x = 0; x < heightmap.width; x++) {
				//Grab current pixel colour
				Color32 pixelCol = heightmap.GetPixel (x, z);
				float alpha = pixelCol.a;	

				if (alpha != 0f) //if it's not transparent
				{
					for (int i = 0; i < 15; i++) //Checks through 16 colours 
					{
						if (pixelCol.Equals (colors [i])) //against the pixel colour
						{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
							
							if (i == 0) 
							{
								oldY = YValue;
								YValue = YValue + 2;
							} else if (i == 5) 
							{
								oldY = YValue;
								var prefabdwc = Instantiate (prefabs[1], new Vector3 (x, YValue, z), Quaternion.identity);
								prefabdwc = Instantiate (prefabs[i], new Vector3 (x, YValue+5, z), Quaternion.identity);
								YValue = YValue - 1;
							}
							var prefabdItem = Instantiate (prefabs[i], new Vector3 (x, YValue, z), Quaternion.identity);
							prefabdItem.name = cubeNames [i] + cubeAmount.ToString ();
							cubeAmount++;
							YValue = oldY;
						}
					}											
				}
			}			
		}
	}		
}