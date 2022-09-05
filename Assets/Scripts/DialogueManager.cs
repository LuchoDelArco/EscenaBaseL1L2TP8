using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public string[] arrayMisiones;
	[SerializeField] GameObject interactionText;
	bool interactionActive;
	[SerializeField] GameObject panelDialogos;
	

    // Start is called before the first frame update
    void Start()
    {
		interactionText.SetActive(false);
		panelDialogos.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        if(interactionActive && Input.GetKeyDown(KeyCode.R))
		{
			panelDialogos.SetActive(true);
		}
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("NPC"))
		{
			interactionText.SetActive(true);

			interactionActive = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("NPC"))
		{
			interactionText.SetActive(false);
		}
	}
}
