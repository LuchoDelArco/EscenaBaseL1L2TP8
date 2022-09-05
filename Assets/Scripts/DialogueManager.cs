using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] string[] arrayMisiones;
	[SerializeField] GameObject interactionText;
	[SerializeField] GameObject panelDialogos;

	bool interactionActive;
	bool startedDialogue;


    // Start is called before the first frame update
    void Start()
    {
		interactionText.SetActive(false);
		panelDialogos.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        if(interactionActive && Input.GetKeyDown(KeyCode.R))	//Si se activó la interacción y se presiona R
		{
			EmpezarDialogo();	//Se invoca...
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

	void EmpezarDialogo()
	{
		startedDialogue = true;		//Empezó el dialogo
		panelDialogos.SetActive(true);		//Activo el panel para el texto
		interactionText.SetActive(false);	//Desactivo el mensaje para interactuar
	}
}
