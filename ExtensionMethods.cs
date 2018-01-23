using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Toolbox
{
    public static class ExtensionMethods
    {
        public static List<RectTransform> GetChildren(this RectTransform rt)
        {
            var children = new List<RectTransform>();
            for (var i = 0; i < rt.childCount; i++)
                children.Add(rt.GetChild(i) as RectTransform);
            return children;
        }

        public static float IntersectionArea(this RectTransform rt1, RectTransform rt2)
        {
            var worldCorners = new Vector3[4];
            rt1.GetWorldCorners(worldCorners);
            var r1 = new Rect(worldCorners[1].x, worldCorners[1].y, worldCorners[2].x - worldCorners[1].x, worldCorners[1].y - worldCorners[0].y);
            rt2.GetWorldCorners(worldCorners);
            var r2 = new Rect(worldCorners[1].x, worldCorners[1].y, worldCorners[2].x - worldCorners[1].x, worldCorners[1].y - worldCorners[0].y);

            var area = new Rect();

            if (r2.Overlaps(r1))
            {
                var x1 = Mathf.Min(r1.xMax, r2.xMax);
                var x2 = Mathf.Max(r1.xMin, r2.xMin);
                var y1 = Mathf.Min(r1.yMax, r2.yMax);
                var y2 = Mathf.Max(r1.yMin, r2.yMin);
                area.x = Mathf.Min(x1, x2);
                area.y = Mathf.Min(y1, y2);
                area.width = Mathf.Max(0.0f, x1 - x2);
                area.height = Mathf.Max(0.0f, y1 - y2);

                return area.width * area.height;
            }

            return 0;
        }

        public static T GetRandomValue<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandomValue<T>(this Array array)
        {
            return (T) array.GetValue(Random.Range(0, array.Length));
        }
    }
}