using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Controllers
{
    public sealed class PhotoController
    {
        private bool _isProcessed;
        private int _layers = 5;
        private int _resolution = 5;
        private Camera _camera;

        private readonly string _path;


        public PhotoController()
        {
            _path = Application.dataPath;
            _camera = Camera.main;
        }


        private IEnumerator DoTapExampleAsync()
        {
            _isProcessed = true;
            _camera.cullingMask = ~(1 << _layers);
            var sw = Screen.width;
            var sh = Screen.height;
            yield return new WaitForEndOfFrame();

            var sc = new Texture2D(sw, sh, TextureFormat.RGB24, true);
            sc.ReadPixels(new Rect(0, 0, sw, sh), 0, 0);

            var bytes = sc.EncodeToPNG();
            var fileName = String.Format("{0:ddMMyyyy_HHmmssfff}.png", DateTime.Now);
            File.WriteAllBytes(Path.Combine(_path, fileName), bytes);
            yield return new WaitForSeconds(2.3f);

            _camera.cullingMask |= 1 << _layers;
            _isProcessed = false;
        }

        public void FirstMethod()
        {
            var fileName = string.Format("{0:ddMMyyyy_HHmmssfff}.png", DateTime.Now);
            ScreenCapture.CaptureScreenshot(Path.Combine(_path, fileName), _resolution);
        }
    }
}