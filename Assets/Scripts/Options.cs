using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    int rightNumber;
    int rightOption;
    bool error;
    private CartaScriptableObject[] options;

    public GameController gC;

    Color green = new Color32(151, 241, 159, 255);
    Color red = new Color32(241, 154, 151, 255);
    Color white = new Color32(255, 255, 255, 255);
    void Start()
    {
        error = false;
        options = new CartaScriptableObject[3];
        ButtonsNoInteractables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Guarda la opcion correcta
    public void FillRightOption(int num, int op)
    {
        rightNumber = num;
        rightOption = op;
    }

    //Guarda todas las cartas
    public void FillOptions(CartaScriptableObject[] o)
    {
        GameObject child;
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            child = this.gameObject.transform.GetChild(i).gameObject;
            child.GetComponent<Image>().sprite = o[i].imageCarta;
            options[i] = o[i];

        }
    }

    //Cuando se clica la opción 1
    public void OnClickOption1()
    {

        //Mirar si es la opción correcta
        if (options[0].intNumber == rightNumber)
        {
            CorrectOption();

        } else
        {
            if(error == false)
            {
                EliminemOpcioError1(0);
                error = true;
            } else
            {
                //Activamos la opcion correcta y quitamos las opciones
                ActiveCorrectOption(0);
            }
            
        }
    }

    //Cuando se clica la opción 2
    public void OnClickOption2()
    {

        //Mirar si es la opción correcta
        if (options[1].intNumber == rightNumber)
        {
            CorrectOption();
        }
        else
        {
            if (error == false)
            {
                EliminemOpcioError1(1);
                error = true;
            }
            else
            {
                //Activamos la opcion correcta y quitamos las opciones
                ActiveCorrectOption(1);
            }
        }
    }

    //Cuando se clica la opción 2
    public void OnClickOption3()
    {
        //Mirar si es la opción correcta
        if (options[2].intNumber == rightNumber)
        {
            CorrectOption();
        }
        else
        {
            if (error == false)
            {
                EliminemOpcioError1(2);
                error = true;
            }
            else
            {
                //Activamos la opcion correcta y quitamos las opciones
                ActiveCorrectOption(2);
            }
        }
    }

    //Eliminamos la opcion
    void EliminemOpcioError1(int op)
    {
        //Activamos el color y despues la desactivamos
        this.gameObject.transform.GetChild(op).gameObject.GetComponent<Image>().color = red;
        gC.SumaIncorrecte();
        StartCoroutine(DesactiveOption(op));
        
    }

    //Se llama cuando es la opción correcta, la pinta de verde, suma en el marcador y desactiva las opciones
    void CorrectOption()
    {
        this.gameObject.transform.GetChild(rightOption).gameObject.GetComponent<Image>().color = green;
        gC.SumaCorrecte();
        ButtonsNoInteractables();
        Invoke("AnimacioSortida", 1f);
        StartCoroutine(ActiveOptions());
    }

    //Se llama cuando ya se han equivocado una vez, pinta la opción correcta en verde y la incorrecta en rojo
    void ActiveCorrectOption(int op)
    {
 
        this.gameObject.transform.GetChild(op).gameObject.GetComponent<Image>().color = red;
        this.gameObject.transform.GetChild(rightOption).gameObject.GetComponent<Image>().color = green;
        gC.SumaIncorrecte();
        //Activa animacion de salida
        Invoke("AnimacioSortida", 1f);
        StartCoroutine(ActiveOptions());
    }

    //Desactiva la opción
    IEnumerator DesactiveOption(int op)
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.transform.GetChild(op).gameObject.SetActive(false);
        yield return null;
    }

    //Activa todas las opciones y las prepara para la siguiente ronda
    IEnumerator ActiveOptions()
    {
        yield return new WaitForSeconds(4f);
        error = false;
        for (int i = 0; i < options.Length; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color = white;

        }
        yield return null;
    }

    //Llama la animación de salida
    void AnimacioSortida()
    {
        gC.AnimacioSortida();
    }

    //Activa todos los botones
    public IEnumerator ButtonsInteractables(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < options.Length; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
        }
    }

    //Desactiva todos los botones
    public void ButtonsNoInteractables()
    {
        for (int i = 0; i < options.Length; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
        }
    }


}
