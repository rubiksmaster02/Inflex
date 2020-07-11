﻿using Audio;
using Beatmaps.Events;
using Ui.Game;
using UnityEngine;

namespace Logic.Creators
{
    public class HitObjectCreator : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        private int offset;

        private void Update() => this.WaitToSpawnEnemy();

        private void WaitToSpawnEnemy()
        {
            for (int i = this.offset; i < Assets.Instance.BeatMap.Enemies.Count; i++)
            {
                if (GameState.GetSpeed(this.offset) * (-AudioPlayer.Instance.TrueAudioTime + Assets.Instance.BeatMap.Enemies[i].SpawnTime) +
                    5.6 * Assets.Instance.Settings.ElementsSize > 1100)
                {
                    return;
                }

                this.CreateEnemy(Assets.Instance.BeatMap.Enemies[i], GameState.GetSpeed(this.offset));
                this.offset++;
            }
        }

        private void CreateEnemy(EnemyEvent self, float speed)
        {
            print(speed);
            GameObject enemyInstance = Instantiate(this.enemy, this.transform, false);
            enemyInstance.GetComponent<HitObject>().Construct(self, speed);
        }
    }
}