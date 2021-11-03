using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Carta", menuName = "ScriptableObjects/CartaScriptableObject", order = 1)]
public class CartaScriptableObject : ScriptableObject
{
    public string wordNumber;
    public int intNumber;
    public Sprite imageCarta;

}