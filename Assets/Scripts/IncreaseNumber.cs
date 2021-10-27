using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseNumber : MonoBehaviour
{
    [SerializeField] private GameObject _textObject;

    private TextMesh _text;

    void Awake()
    {
        _text = _textObject.GetComponent<TextMesh>();
    }
    void Start()
    {
        _text.text = "10";
    }

    public void IncreaseTargetNumber()
    {
        int temp = int.Parse(_text.text);
        temp += 1;
        _text.text = temp.ToString();
    }
}
