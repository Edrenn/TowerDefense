using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] List<GameObject> allTargetInSight = new List<GameObject>();
    [SerializeField] private GameObject currentTarget;

    private void Update()
    {
        if (IsTargetInSight() && currentTarget == null)
        {
            SetCurrentTarget();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!allTargetInSight.Contains(other.gameObject))
        {
            allTargetInSight.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (allTargetInSight.Contains(other.gameObject))
        {
            allTargetInSight.Remove(other.gameObject);
            if (other.gameObject == currentTarget)
            {
                currentTarget = null;
                GetComponent<Animator>().SetBool("isTargetInSight", false);
            }
        }
    }

    private void SetCurrentTarget()
    {
        currentTarget = allTargetInSight.First();
        GetComponent<Animator>().SetBool("isTargetInSight", true);
    }

    private bool IsTargetInSight()
    {
        return allTargetInSight.Count > 0;
    }

    public void Fire()
    {
        if (currentTarget)
        {
            currentTarget.GetComponent<Health>().ReduceHealth(1);
            if (GetComponent<Animator>().speed < 3)
            {
                GetComponent<Animator>().speed += 0.5f;
            }

            if (!IsTargetInSight())
            {
                GetComponent<Animator>().SetBool("isTargetInSight", false);
            }
        }
    }
}
