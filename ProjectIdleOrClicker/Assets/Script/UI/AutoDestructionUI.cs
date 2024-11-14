using System.Collections;
using UnityEngine;

public class AutoDestructionUI : MonoBehaviour
{
    private Coroutine routine;

    private void Awake()
    {
        routine = StartCoroutine(CountToEnd());
    }

    private IEnumerator CountToEnd()
    {
        yield return new WaitForSeconds(ConstantCollection.ItemLogDestructionTime);
        DestroyThis();
    }

    private void DestroyThis()
    {
        StopCoroutine(routine);
        Destroy(gameObject);
    }
}