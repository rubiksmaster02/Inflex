﻿using System.Collections.Generic;
using Beatmaps;
using Database;
using Ui.LevelSelection;
using UnityEngine;

namespace Logic.Creators
{
    public class ButtonCreator : MonoBehaviour
    {
        private readonly         List<GameObject> beatMaps = new List<GameObject>();
        [SerializeField] private GameObject       beatMapButtonTemp;
        [SerializeField] private GameObject       options;

        public void Start() => this.CreateAllButtons();

        private void CreateAllButtons()
        {
            foreach (BeatMapMetadata beatMapData in InflexContext.Load())
            {
                this.CreateSingleButton(beatMapData);
            }

            BeatMapButton.Options = this.options;
        }

        private void CreateSingleButton(BeatMapMetadata beatMapMeta)
        {
            GameObject button = Instantiate(this.beatMapButtonTemp, this.gameObject.transform, false);
            button.GetComponent<BeatMapButton>().SetData(beatMapMeta);
            this.beatMaps.Add(button);
        }

        private void Update()
        {
            if (InputManager.MacroDown("RefreshMaps"))
            {
                this.RefreshBeatMaps();
            }
        }

        private void RefreshBeatMaps()
        {
            this.DeleteAllButtons();
            this.beatMaps.Clear();
            InflexContext.Save();
            this.CreateAllButtons();
        }

        private void DeleteAllButtons() => this.beatMaps.ForEach(Destroy);
    }
}