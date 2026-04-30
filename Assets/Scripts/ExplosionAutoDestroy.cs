using UnityEngine;

public class ExplosionAutoDestroy : MonoBehaviour
{
    [SerializeField] private float duration = 0.5f;

    void Start()
    {
        Destroy(gameObject, duration);
    }
}