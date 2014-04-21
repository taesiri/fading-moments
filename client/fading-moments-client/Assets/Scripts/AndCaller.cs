using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Assets.Scripts
{
    public class AndCaller : MonoBehaviour
    {
        private AndroidJavaClass _activityClass;
        private AndroidJavaObject _activityObject;
        public LocationHelper LocationAssistant = new LocationHelper();

        public GUISkin DefaultSkin;
        private Matrix4x4 _guiMatrix;
        public GameObject RObject;
        public string RetunedUrl = "null";
        private string _pathPrefix = @"file:///";
        public Texture2D Sample;
        private string _debguInfo;

        private void Start()
        {
            LocationAssistant.PointLocation = LocationHelper.Point.Center;
            LocationAssistant.UpdateLocation();


            Vector2 ratio = LocationAssistant.GuiOffset;
            _guiMatrix = Matrix4x4.identity;
            _guiMatrix.SetTRS(new Vector3(1, 1, 1), Quaternion.identity, new Vector3(ratio.x, ratio.y, 1));
        }

        private void Update()
        {
        }

        public void SelectImage()
        {
            _activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _activityObject = _activityClass.GetStatic<AndroidJavaObject>("currentActivity");

            _activityObject.Call("SelectfromGallery");
        }

        public void UpdateImageUrl(string url)
        {
            RetunedUrl = _pathPrefix + url;
            StartCoroutine(LoadImages());
        }

        private IEnumerator LoadImages()
        {
            _debguInfo += ".";

            var www = new WWW(RetunedUrl);
            yield return www;
            try
            {
                var texTmp = new Texture2D(512, 512);

                _debguInfo += ".";
                www.LoadImageIntoTexture(texTmp);
                RObject.renderer.material.SetTexture("_MainTex", texTmp);
            }
            catch (Exception e)
            {
                _debguInfo += e.Message;
            }
        }

        public void OnGUI()
        {
            GUI.matrix = _guiMatrix;
            if (GUI.Button(new Rect(LocationAssistant.Offset.x - 200, 50, 400, 100), "Load Image"))
            {
                SelectImage();
            }

            GUI.Label(new Rect(LocationAssistant.Offset.x - 200, 200, 400, 50), RetunedUrl, DefaultSkin.label);

            GUI.Label(new Rect(LocationAssistant.Offset.x - 200, 500, 400, 50), _debguInfo, DefaultSkin.label);

            GUI.matrix = Matrix4x4.identity;
        }
    }
}