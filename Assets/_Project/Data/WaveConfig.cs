using UnityEngine;

namespace Project.Data
{
    [CreateAssetMenu(menuName = "Data/Wave Config")]
    public class WaveConfig : ScriptableObject
    {
        public int EnemyCount = 5;
        public float SpawnInterval = 0.5f;
        public float DelayBeforeNextWave = 2f;
    }
}