using UnityEngine;

namespace Extensions
{
    public static class CameraExtensions
    {
        public static Vector2 GetMaxBounds(this Camera camera)
        {
            return camera.ViewportToWorldPoint(new Vector2(1, 1));
        }

        public static Vector2 GetMinBounds(this Camera camera)
        {
            return camera.ViewportToWorldPoint(new Vector2(0, 0));
        }
    }
}

