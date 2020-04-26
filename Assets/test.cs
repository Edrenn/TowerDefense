using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public VerticalLayoutGroup vlg;
    public GameObject btnPrefab;
    public TowerSpawner tsPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //vlg = tsPrefab.GetComponentInChildren<VerticalLayoutGroup>();
            GameObject gameObject = Instantiate(btnPrefab);
            gameObject.transform.SetParent(vlg.gameObject.transform, false);

        }
    }
}
