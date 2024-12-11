using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionItem : MonoBehaviour
{
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        levelManager.LevelComplete();
    }
}
