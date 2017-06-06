using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MDUI
{
    // TODO https://docs.unity3d.com/ScriptReference/Screen-dpi.html
    // TODO fix ratio
    public class MDContent : MonoBehaviour
    {

        // fields visible in Unity3d inspector
        // TODO

        // Use this for initialization
        void Start()
        {
            CanvasScaler scaler = this.GetComponentInChildren<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            // https://docs.unity3d.com/ScriptReference/SystemInfo-deviceType.html
            if (SystemInfo.deviceType == DeviceType.Handheld)
                scaler.referenceResolution = new Vector2(640, 960);
            else if (SystemInfo.deviceType == DeviceType.Desktop)
                scaler.referenceResolution = new Vector2(1280, 720);
            else if (SystemInfo.deviceType == DeviceType.Console)
                scaler.referenceResolution = new Vector2(1920, 1080);
            else
            {
                Debug.LogError("DeviceType is unknown.");
                scaler.referenceResolution = new Vector2(1024, 1024);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Use this for editor reset component button
        void Reset()
        {
            Start();
        }


    }
}
