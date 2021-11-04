using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int success = 0;
    public int mistakes = 0;

    private CartaScriptableObject rightNumber;
    private int rightOption;
    private CartaScriptableObject[] options;
    private int asignedOptions = 0;
    public bool startRound;

    public GameObject numberPrefab;
    public GameObject op;
    public GameObject brazo;

    public CartaScriptableObject[] cartas;

    // Start is called before the first frame update
    void Start()
    {
        numberPrefab.SetActive(false);
        //op.SetActive(false);
        options = new CartaScriptableObject[3];
        startRound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startRound == true)
        {
            startRound = false;
            AssignOptions();
            CreateNumber();
            Invoke("ActiveOptions", 6f);
        }
        
    }

    // Asignar las cartas que tienen que salir como opciones
    void AssignOptions() {
        int numberAssigned;
        for(int i = 0; i < options.Length; i++) {
            do {
                numberAssigned = Random.Range(0, cartas.Length);

            } while (CheckOtherOptions(numberAssigned) == false);
            asignedOptions++;
            options[i] = cartas[numberAssigned];
            
        }
        DecideRightOption();
    }

    //Activar las opciones cuando sea necesario
    private void ActiveOptions()
    {
        op.GetComponent<Options>().FillOptions(options);
        op.GetComponent<Options>().FillRightOption(rightNumber.intNumber, rightOption);
        brazo.GetComponent<Animator>().SetBool("active", true);
        StartCoroutine(op.GetComponent<Options>().ButtonsInteractables(1f));
    }

    //Crear el numero aleatorio y mostrarlo por pantalla
    private void CreateNumber()
    {
        numberPrefab.GetComponent<TextMeshProUGUI>().text = rightNumber.wordNumber;
        numberPrefab.SetActive(true);
        numberPrefab.GetComponent<RandomNumber>().FadeIn();
    }

    //Mira si ya existe la opcion escogida para no repetir numeros
    private bool CheckOtherOptions(int num) {   
        if(asignedOptions == 0) {
            return true;
        }
        else {
            for (int i = 0; i < asignedOptions; i++) {
                if (options[i].intNumber == num+1) {
                    return false;
                }
            }
            return true;
        }
    }

    //Decide la opcion correcta de las tres escogidas
    private void DecideRightOption()
    {
        int option = Random.Range(0, options.Length);
        rightNumber = options[option];
        rightOption = option;
    }

    //Incrementa los errores
    public void SumaIncorrecte()
    {
        mistakes++;
    }

    //Incrementa los aciertos
    public void SumaCorrecte()
    {
        success++;
    }

    //Activa la animación de salida
    public void AnimacioSortida()
    {
        brazo.GetComponent<Animator>().SetBool("active", false);
        Invoke("NextRound", 2f);
    }

    //Activa la siguente ronda
    void NextRound()
    {
        asignedOptions = 0;
        startRound = true;
        
    }
}
