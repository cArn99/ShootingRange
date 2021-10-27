using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private GameObject _textObject;

    private TextMesh _text;
    private int targetNumber;

    public bool _hitAgain = false;

    void Awake()
    {
        _text = _textObject.GetComponent<TextMesh>();    
    }

    void Update()
    {
        targetNumber = int.Parse(_text.text);
    }
    public void Spawn()
    {
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        for(int i =0;i<targetNumber;i++)
        {
            GameObject cloneSphere = Instantiate(_sphere, new Vector3(Random.Range(-27f, -14f), Random.Range(1f, 3.5f), Random.Range(1f, 18f)), Quaternion.identity);
            cloneSphere.tag = "SphereTarget";
            yield return new WaitForSeconds(1.0f);
            Destroy(cloneSphere);
        }
        gameObject.layer = 0;
    }


}  
