using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseNumber : MonoBehaviour
{
    [SerializeField] private GameObject _textObject;

    private TextMesh _text;
    void Awake()
    {
        _text = _textObject.GetComponent<TextMesh>();
    }

    public void DecreaseTargetNumber()
    {
        int temp = int.Parse(_text.text);
        temp -= 1;
        _text.text = temp.ToString();
    }
}
