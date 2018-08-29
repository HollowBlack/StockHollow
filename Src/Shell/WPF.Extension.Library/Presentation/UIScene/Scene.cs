using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Threading;

namespace WPF.Extension.Library.Presentation
{
    public class Scene
    {
        public SceneManager SceneMgr { get; set; }

        public object Content { get; private set; }

        public Scene PrevScene { get; set; }

        public Uri Uri { get; private set; }

        public bool IsActive
        {
            get { return SceneMgr.Currrent == this; }
        }

        public Scene GetPostScene()
        {
            if (SceneMgr == null)
                return null;

            return SceneMgr.Scenes.FirstOrDefault(i => i.PrevScene == this);
        }

        protected Scene(Uri uri, SceneManager sceneMgr, Scene prev = null)
        {
            Uri = uri;
            SceneMgr = sceneMgr;
            PrevScene = prev;
        }

        public static async Task<Scene> CreateSceneAsync(Uri uri, SceneManager sceneMgr, Scene prev = null)
        {
            var loader = new DefaultContentLoader();
            var localTokenSource = new CancellationTokenSource();
            var content = await loader.LoadContentAsync(uri, localTokenSource.Token);
            var scene = new Scene(uri, sceneMgr, prev) {Content = content};
            return scene;
        }
    }
}
