using UnityEngine;

namespace LowTeeGames
{

    public static class GameObjectExtensions
    {
        /// <summary>
        /// Returns the component of Type type in the GameObject or any of its parents.
        /// Recurses upwards until it finds a valid component. Returns null if no component found. Only components on active GameObjects are returned.
        /// </summary>
        public static bool TryGetComponentInParent<T>(this Component comp, out T component)
        {
            component = comp.GetComponentInParent<T>();
            return HasFoundComponent(component);
        }

        /// <summary>
        /// Returns the component of Type type in the GameObject or any of its parents.
        /// Recurses upwards until it finds a valid component. Returns null if no component found. Only components on active GameObjects are returned.
        /// </summary>
        public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T component)
        {
            component = gameObject.GetComponentInParent<T>();
            return HasFoundComponent(component);
        }

        public static bool TryGetComponentInChldren<T>(this Component comp, out T component)
        {
            component = comp.GetComponentInChildren<T>();
            return HasFoundComponent(component);
        }

        public static bool TryGetComponentInChldren<T>(this GameObject gameObject, out T component)
        {
            component = gameObject.GetComponentInChildren<T>();
            return HasFoundComponent(component);
        }

        public static bool TryGetComponentsInParent<T>(this Component comp, out T[] components)
        {
            components = comp.GetComponentsInParent<T>();
            return HasFoundComponent(components);
        }

        public static bool TryGetComponentsInParent<T>(this GameObject gameObject, out T[] components)
        {
            components = gameObject.GetComponentsInParent<T>();
            return HasFoundComponent(components);
        }

        public static bool TryGetComponentsInChildren<T>(this Component comp, out T[] components)
        {
            components = comp.GetComponentsInChildren<T>();
            return HasFoundComponents(components);
        }

        public static bool TryGetComponentsInChildren<T>(this GameObject gameObject, out T[] components)
        {
            components = gameObject.GetComponentsInChildren<T>();
            return HasFoundComponents(components);
        }

        private static bool HasFoundComponent<T>(T component)
        {
            return component != null;
        }

        private static bool HasFoundComponents<T>(T[] components)
        {
            return components != null;
        }
    }
}