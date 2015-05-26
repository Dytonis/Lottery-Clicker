using UnityEngine;
using System.Collections;

public class MainClickHandler : MonoBehaviour 
{
	void OnMouseDown()
    {
        GetComponent<Animation>().Rewind();
        GetComponent<Animation>().Play();

        Spawn();
    }

    public void Spawn()
    {
        Debug.Log("fire");
    }
}
