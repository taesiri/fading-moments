﻿using UnityEngine;

namespace Assets.Scripts
{
    public class LocationHelper
    {
        public float OriginalWidth = 458f;
        public float OriginalHeigth = 687f;


        public float ActualWidth = Screen.width;
        public float ActualHeight = Screen.height;

        public enum Point
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Center
        }

        public Point PointLocation = Point.TopLeft;
        public Vector2 Offset;
        public Vector2 GuiOffset;
        public Vector2 CenterOfScreen;

        public void UpdateLocation()
        {
            ActualWidth = Screen.width;
            ActualHeight = Screen.height;

            CenterOfScreen = new Vector2(ActualWidth/2f, ActualHeight/2f);

            switch (PointLocation)
            {
                case Point.TopLeft:
                    Offset = new Vector2(0, 0);
                    break;
                case Point.TopRight:
                    Offset = new Vector2(OriginalWidth, 0);
                    break;
                case Point.BottomLeft:
                    Offset = new Vector2(0, OriginalHeigth);
                    break;
                case Point.BottomRight:
                    Offset = new Vector2(OriginalWidth, OriginalHeigth);
                    break;
                case Point.Center:
                    Offset = new Vector2(OriginalWidth/2f, OriginalHeigth/2f);
                    break;
            }

            GuiOffset.x = Screen.width/OriginalWidth;
            GuiOffset.y = Screen.height/OriginalHeigth;
        }
    }
}