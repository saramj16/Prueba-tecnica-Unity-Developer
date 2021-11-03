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

    public void FillRightOption(int num, int op)
    {
        rightNumber = num;
        rightOption = op;
    }

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


    public void OnClickOption1()
    {

        //Check if it was the correct option
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
                //Activem opcio correcte i traiem totes les opcions
                ActiveCorrectOption(0);
            }
            
        }
    }

    public void OnClickOption2()
    {
        
        //Check if it was the correct option
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
                //Activem opcio correcte i traiem totes les opcions
                ActiveCorrectOption(1);
            }
        }
    }

    public void OnClickOption3()
    {
        //Check if it was the correct option
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
                //Activem opcio correcte i traiem totes les opcions
                ActiveCorrectOption(2);
            }
        }
    }

    void EliminemOpcioError1(int op)
    {
        //Hem d'activar-ne el seu color i despres desactivar-la
        this.gameObject.transform.GetChild(op).gameObject.GetComponent<Image>().color = red;
        gC.SumaIncorrecte();
        StartCoroutine(DesactiveOption(op));
        
    }

    void CorrectOption()
    {
        this.gameObject.transform.GetChild(rightOption).gameObject.GetComponent<Image>().color = green;
        gC.SumaCorrecte();
        ButtonsNoInteractables();
        Invoke("AnimacioSortida", 1f);
        StartCoroutine(ActiveOptions());
    }

    void ActiveCorrectOption(int op)
    {
 
        this.gameObject.transform.GetChild(op).gameObject.GetComponent<Image>().color = red;
        this.gameObject.transform.GetChild(rightOption).gameObject.GetComponent<Image>().color = green;
        gC.SumaIncorrecte();
        //Activa animació de sortida
        Invoke("AnimacioSortida", 1f);
        StartCoroutine(ActiveOptions());
    }

    IEnumerator DesactiveOption(int op)
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.transform.GetChild(op).gameObject.SetActive(false);
        yield return null;
    }

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

    void AnimacioSortida()
    {
        gC.AnimacioSortida();
    }

    public IEnumerator ButtonsInteractables(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < options.Length; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void ButtonsNoInteractables()
    {
        for (int i = 0; i < options.Length; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
        }
    }


}
