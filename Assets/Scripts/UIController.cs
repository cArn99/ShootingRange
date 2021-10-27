using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _scoreLabel;

    public void Test()
    {
        Debug.Log("Working");
    }
    public void UpdateScore(int amount)
    {
        int temp = int.Parse(_scoreLabel.text);
        temp += amount;
        _scoreLabel.text = temp.ToString();
    }

    public void ResetScore()
    {
        _scoreLabel.text = "0";
    }


}
