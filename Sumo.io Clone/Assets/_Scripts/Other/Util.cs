using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Globalization;
using UnityEngine;


namespace NOSurrender
{
    public class Util
    {
        
        public static bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }

        // Note: This method big numbers format is based on the following article:
        public static string FormatBigNumbers(float num)
        {
            if (num > 999999999f || num < -999999999f)
            {
                return num.ToString("0,,,.###B", CultureInfo.InvariantCulture);
            }
            else
            if (num > 999999f || num < -999999f)
            {
                return num.ToString("0,,.##M", CultureInfo.InvariantCulture);
            }
            else
            if (num > 999f || num < -999f)
            {
                return num.ToString("0,.#K", CultureInfo.InvariantCulture);
            }
            else
            {
                return num.ToString(CultureInfo.InvariantCulture);
            }
        }


        public static int GetRandomIndex(int length)
        {
            return Random.Range(0, length);
        }
    }
}
