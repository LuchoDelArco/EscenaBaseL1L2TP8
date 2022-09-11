using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	public CollectableDataSO data;
	DialogueManager A;
    // Start is called before the first frame update
    void Start()
    {
        if (!data.collected)
		{
			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
       
    }

	private void OnMouseDown()
	{
		
		data.collected = true;
		Destroy(gameObject);
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

	}
}
