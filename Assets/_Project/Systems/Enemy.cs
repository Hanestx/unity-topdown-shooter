using UnityEngine;
using Project.Components;

namespace Project.Systems
{
    [RequireComponent(typeof(HealthComponent))]
    public class Enemy : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<HealthComponent>().OnDied += OnDied;
        }

        private void OnDisable()
        {
            GetComponent<HealthComponent>().OnDied -= OnDied;
        }

        private void OnDied()
        {
            Destroy(gameObject);
        }
    }
}