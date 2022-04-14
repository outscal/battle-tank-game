using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance.Runtime
{
    public class SubstanceRuntime : MonoBehaviour
    {
        public static SubstanceRuntime Instance
        {
            get
            {
                if (_instance != null)
                {
                    _instance.Initialize();
                    return _instance;
                }

                _instance = FindObjectOfType<SubstanceRuntime>();

                if (_instance != null)
                {
                    _instance.Initialize();
                    return _instance;
                }

                var go = new GameObject("SubstanceRuntime");
                _instance = go.AddComponent<SubstanceRuntime>();

                _instance.Initialize();
                return _instance;
            }
        }

        private static SubstanceRuntime _instance = null;

        private static bool _isInitialized = false;

        private void Initialize()
        {
            if (_isInitialized)
                return;

            var enginePath = PlatformUtils.GetEnginePath();
            var pluginPath = PlatformUtils.GetPluginPath();
            Engine.Initialize(pluginPath, enginePath);
            _isInitialized = true;
        }

        /// <summary>
        /// Loads a sbsar file into the engine. The engine will keep track of this file internally.
        /// </summary>
        /// <param name="assetPath">Path to a sbsar file.</param>
        public SubstanceNativeHandler InitializeInstance(SubstanceMaterialInstanceSO substanceInstance)
        {
            if (substanceInstance == null)
                return null;

            return Engine.OpenFile(substanceInstance.RawData.FileContent);
        }
    }
}