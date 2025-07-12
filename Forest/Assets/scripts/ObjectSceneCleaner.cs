using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSceneCleaner : MonoBehaviour
{
    [SerializeField] private Transform _enemiesContainer;
    [SerializeField] private Transform _bulletsContainer;

    public void Clean()
    {
        CleanContainer(_bulletsContainer);
        CleanContainer(_enemiesContainer);
    }

    private void CleanContainer(Transform container)
    {
        while (container.childCount > 0)
        {
            Transform child = container.GetChild(0);

            child.SetParent(null);

            Destroy(child.gameObject);
        }
    }
}
