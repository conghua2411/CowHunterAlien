using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowText : MonoBehaviour
{

    [SerializeField]
    private GameObject textObj;

    private TextMesh textMesh;

    private void Awake()
    {
        if (textObj != null)
        {
            textMesh = textObj.GetComponent<TextMesh>();
        }
    }

    public void ChangeText(string text)
    {
        textMesh.text = text;
    }
}
