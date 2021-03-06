using System.IO;
using Packages.SFB;
using Scenes.InGameEditor.Logic;
using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.InGameEditor.Ui.Buttons
{
    public class Background : MouseNavigationControl
    {
        [SerializeField] private Text text;

        protected override void LeftClick()
        {
            var path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "png,jpg", false);

            if (path.Length == 1 && !string.IsNullOrEmpty(path[0]))
            {
                this.text.text                           = Path.GetFileName(path[0]);
                EditorInitializer.BeatMapMeta.Background = path[0];
            }
        }
    }
}