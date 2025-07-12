using UnityEngine;

public class SceneReferenceInizializer : MonoBehaviour
{
    [SerializeField] private SceneReferences _references;
    [SerializeField] private Transform _dynamicObjectsParent;

    private void Awake()
    {
        _references.Bullets = _dynamicObjectsParent;
    }
}
