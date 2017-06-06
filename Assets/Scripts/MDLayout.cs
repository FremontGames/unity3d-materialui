using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MDUI
{
    // TODO https://docs.unity3d.com/ScriptReference/Screen-dpi.html
    // TODO fix ratio
    public class MDLayout : MonoBehaviour
    {

        // fields visible in Unity3d inspector
        public MDLayoutType layout = MDLayoutType.Column;
        public MDLayoutAlign layoutAlign = MDLayoutAlign.CenterCenter;

        // Use this for initialization
        void Start()
        {

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

    public enum MDLayoutType
    {
        Row, Column
    }

    public enum MDLayoutAlign
    {
        StartStart,
        StartCenter,
        StartEnd,
        StartStretch,

        CenterStart,
        CenterCenter,
        CenterEnd,
        CenterStretch,

        EndStart,
        EndCenter,
        EndEnd,
        EndStretch,

        SpaceAroundStart,
        SpaceAroundCenter,
        SpaceAroundEnd,
        SpaceAroundStretch,

        SpaceBetweenStart,
        SpaceBetweenCenter,
        SpaceBetweenEnd,
        SpaceBetweenStretch,
    }

}
