using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	public CollectableDataSO data;
	DialogueManager a;

	// Start is called before the first frame update
	void Start()
    {
        if (data.collected) //Si ya se recolectó
		{
			DisableCollectableComponents();
			
		}

		a = FindObjectOfType<DialogueManager>();	//Busco al gameobject que tiene el script para acceder a el
    }

    // Update is called once per frame
    void Update()
    {
       
    }

	private void OnMouseDown()
	{
		
		data.collected = true;		//Modifico la variable del SO

		DisableCollectableComponents();

		a.objetosRecolectados += 1;	//Cuando se clickea sobre un recolectable, se suma al contador

	}


	void DisableCollectableComponents()
	{

		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
	}
}
