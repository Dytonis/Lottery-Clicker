using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{
    public bool Clockwise = true;
	
	// Update is called once per frame
	void Update () 
    {
        if (Clockwise)
            transform.Rotate(new Vector3(0f, 0f, 0.5f));
        else
            transform.Rotate(new Vector3(0f, 0f, -0.5f));
	}
}
