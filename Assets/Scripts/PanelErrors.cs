using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelErrors : MonoBehaviour
{
    public TextMeshProUGUI errores;
    public TextMeshProUGUI aciertos;
    public GameController gC;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        errores.text = gC.mistakes.ToString();
        aciertos.text = gC.success.ToString();
    }
}
