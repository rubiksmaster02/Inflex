namespace Beatmaps.Events
{
    public class EnemyEvent
    {
        public EnemyEvent(int killKey, float spawnDegrees, float rotationSpeed, float spawnTime)
        {
            this.KillKey       = killKey;
            this.SpawnDegrees  = spawnDegrees;
            this.RotationSpeed = rotationSpeed;
            this.SpawnTime     = spawnTime;
        }

        public EnemyEvent() { }

        public int   KillKey       { get; set; }
        public float SpawnDegrees  { get; set; }
        public float RotationSpeed { get; set; }
        public float SpawnTime     { get; set; }

        public override string ToString() => $"{nameof(KillKey)}: {KillKey}, {nameof(SpawnDegrees)}: {SpawnDegrees}, {nameof(RotationSpeed)}: {RotationSpeed}, {nameof(SpawnTime)}: {SpawnTime}";
    }
}