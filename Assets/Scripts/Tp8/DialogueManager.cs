using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] GameObject NPC;

	

	[SerializeField] string[] arrayDialogos;
	[SerializeField] GameObject[] arrayMesas;

	[SerializeField] GameObject[] puertas;

	[SerializeField] GameObject interactionText;
	[SerializeField] GameObject recolectarText;

	[SerializeField] GameObject panelDialogos;
	[SerializeField] TextMeshProUGUI textoDelDialogo;

	[SerializeField] GameObject panelRecolectados;
	[SerializeField] TextMeshProUGUI textoRecolectados;
	

	[SerializeField] int posicionFrase;

	[SerializeField] int totalMacs = 0;
	public int objetosRecolectados = 0;


	bool interactionActive;
	bool startedDialogue;
	bool finishedTalking;

	

    // Start is called before the first frame update
    void Start()
    {
		arrayMesas = GameObject.FindGameObjectsWithTag("mesa");
		puertas = GameObject.FindGameObjectsWithTag("puerta");
		

		interactionText.SetActive(false);
		panelDialogos.SetActive(false);
		panelRecolectados.SetActive(false);

		posicionFrase = -1;

		AddComponentsToArray(arrayMesas);
		AddComponentsToArray(puertas);

		

		totalMacs = GameObject.FindGameObjectsWithTag("macs").Length;
	}

    // Update is called once per frame
    void Update()
    {
		if(interactionActive && Input.GetKeyDown(KeyCode.R) && !startedDialogue)    //Si se activó la interacción, se presiona R y es la primer interaccion
		{
			EmpezarDialogo();   //Se invoca...	
			
		}

		NextFrase();

		if (objetosRecolectados <= totalMacs)	
		{
			textoRecolectados.text = "Objetos recolectados: " + objetosRecolectados + "/" + totalMacs;	//Mostrar objetos recolectados
		}
		
    }

	

	void EmpezarDialogo()
	{
		startedDialogue = true;     //Empezó el dialogo
		panelDialogos.SetActive(true);      //Activo el panel para el texto
		interactionText.SetActive(false);   //Desactivo el mensaje para interactuar
	}

	void NextFrase()
	{
		if (Input.GetKeyDown(KeyCode.R) && startedDialogue)		//Si se aprieta R y ya se interactuó
		{
			posicionFrase++;        //Aumenta el indice del dialogo

			if (posicionFrase < arrayDialogos.Length) //Si todavía no se llego al final de los dialogos...
			{
				textoDelDialogo.text = arrayDialogos[posicionFrase];    //El texto que se muestra es el de la posición del indice
			}

			else    //Si ya terminó
			{
				panelDialogos.SetActive(false);
				finishedTalking = true;
				panelRecolectados.SetActive(true);
				
			}
		}
	}


	void OnTriggerEnter(Collider other)		//Al entrar en contacto
	{	
		if (other.gameObject.CompareTag("NPC"))
		{
			arrayDialogos = other.gameObject.GetComponent<NpcBehaviour>().data.dialogueFrases;	//Se le asigna al array las frases cargadas al SO

			if (!startedDialogue)  //Si no habló todavía...
			{
				interactionText.SetActive(true);    //Se activa la opcion de interaccion
				interactionActive = true;

			}
			else if (finishedTalking)	//Si ya hablo previamente...
			{

				textoDelDialogo.text = "Anda a buscar";
				

				if (objetosRecolectados > 0 && objetosRecolectados < totalMacs)		//Si ya encontró alguno...
				{
					textoDelDialogo.text = "Bien, encontraste " + objetosRecolectados + " segui buscando";
					
				}
				else if (objetosRecolectados == totalMacs)	//Si ya encontró todos...
				{
					textoDelDialogo.text = "Excelente! Ya nos podemos ir";
					panelRecolectados.SetActive(false);


					foreach (GameObject go in puertas)
					{
						go.transform.Rotate(0, -45, 0);
					}

					NPC.GetComponent<MeshRenderer>().enabled = false;
					NPC.GetComponent<BoxCollider>().enabled = false;

				}

				panelDialogos.SetActive(true);
			}	
			else //Si estaba hablando
			{
				panelDialogos.SetActive(true);	//Activa de nuevo el panel
			} 
			
		}

		if (other.gameObject.CompareTag("macs"))
		{
			recolectarText.SetActive(true);
		}

		
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("NPC"))
		{
			interactionText.SetActive(false);
			panelDialogos.SetActive(false);
		}

		if (other.gameObject.CompareTag("macs"))
		{
			recolectarText.SetActive(false);
		}

	}

	void AddComponentsToArray(GameObject[] objeto)
	{
		foreach (GameObject go in objeto)
		{
			go.AddComponent<BoxCollider>();
			
		}
	}

	
	
}
