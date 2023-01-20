using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using JetBrains.Annotations;

namespace AutoDoors
{
    public static class Utility
    {
        [CanBeNull]
        private static readonly Func<int, UnityEngine.Object> _findObjectFromInstanceID = null;
        static Utility()
        {
            var methodInfo = typeof(UnityEngine.Object)
                .GetMethod("FindObjectFromInstanceID",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            if (methodInfo == null)
                Debug.LogError("FindObjectFromInstanceID was not found in UnityEngine.Object");
            else
                _findObjectFromInstanceID = (Func<int, UnityEngine.Object>)Delegate.CreateDelegate(typeof(Func<int, UnityEngine.Object>), methodInfo);
        }

        [CanBeNull]
        public static UnityEngine.Object FindObjectFromInstanceID(int instanceID)
        {
            if (_findObjectFromInstanceID == null)
                return null;

            return _findObjectFromInstanceID(instanceID);
        }

        public static T FindObjectFromInstanceID<T>(int instanceID) where T : class
        {
            if (_findObjectFromInstanceID == null)
                return null;

            return _findObjectFromInstanceID(instanceID) as T;
        }
    }
}
