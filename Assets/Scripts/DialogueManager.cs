﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] string[] arrayDialogos;

	[SerializeField] GameObject interactionText;

	[SerializeField] GameObject panelDialogos;
	[SerializeField] TextMeshProUGUI textoDelDialogo;

	[SerializeField] int posicionFrase;

	bool interactionActive;
	bool startedDialogue;
	bool talkFinished;


    // Start is called before the first frame update
    void Start()
    {
		interactionText.SetActive(false);
		panelDialogos.SetActive(false);

		posicionFrase = -1;
	}

    // Update is called once per frame
    void Update()
    {
		if(interactionActive && Input.GetKeyDown(KeyCode.R) && !startedDialogue)    //Si se activó la interacción, se presiona R y es la primer interaccion
		{
			EmpezarDialogo();   //Se invoca...		
		}
		NextFrase();
    }

	

	void EmpezarDialogo()
	{
		startedDialogue = true;     //Empezó el dialogo
		panelDialogos.SetActive(true);      //Activo el panel para el texto
		interactionText.SetActive(false);   //Desactivo el mensaje para interactuar
	}

	void NextFrase()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			posicionFrase++;        //Aumenta el indice del dialogo

			if (posicionFrase < arrayDialogos.Length) //Si todavía no se llego al final de los dialogos...
			{
				textoDelDialogo.text = arrayDialogos[posicionFrase];    //El texto que se muestra es el de la posición del indice

			}
			else
			{
				panelDialogos.SetActive(false);
				talkFinished = true;
				//interactionText.SetActive(true);
			}
		}
	}


	void OnTriggerEnter(Collider other)		//Al entrar en contacto
	{	
		if (other.gameObject.CompareTag("NPC"))
		{
			arrayDialogos = other.gameObject.GetComponent<NpcBehaviour>().data.dialogueFrases;

			if (!startedDialogue)  //Si no habló todavía...
			{
				interactionText.SetActive(true);    //Se activa la opcion de interaccion
				interactionActive = true;

			}
			else if (startedDialogue && posicionFrase == arrayDialogos.Length)	//Si ya hablo previamente...
			{
				textoDelDialogo.text = "ya hemos hablado";
				panelDialogos.SetActive(true);		
			}	
			else //Si estaba hablando
			{
				panelDialogos.SetActive(true);
			} 
			
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("NPC"))
		{
			interactionText.SetActive(false);
			panelDialogos.SetActive(false);
		}
	}

	


	//public void NextFrase()
	//{
		

	//}


}
