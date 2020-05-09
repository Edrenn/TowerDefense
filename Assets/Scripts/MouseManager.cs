using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider == null || hit.collider.tag !=  "Interface")
            {
                foreach (var ts in FindObjectsOfType<TowerSpawner>())
                {
                    ts.HideInterface();
                }
            }
        }
    }
}
