﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Lib.Editor
{
    public partial class CommonUtility
    {
        private static void QuickOpenFolder(string path)
        {
            Debug.Log(path);
            if (!Directory.Exists(path))
            {
                Debug.LogError("没有这个路径:" + path);
                return;
            }

            EditorUtility.RevealInFinder(path);
        }

        [MenuItem("Assets/QuickOpenFolder/Application.dataPath", false, 101)]
        private static void OpenDataPath()
        {
            QuickOpenFolder(Application.dataPath);
        }

        [MenuItem("Assets/QuickOpenFolder/Application.persistentDataPath", false, 102)]
        private static void OpenPersistentDataPath()
        {
            QuickOpenFolder(Application.persistentDataPath);
        }

        [MenuItem("Assets/QuickOpenFolder/Application.streamingAssetsPath", false, 103)]
        private static void OpenStreamingAssets()
        {
            QuickOpenFolder(Application.streamingAssetsPath);
        }

        [MenuItem("Assets/QuickOpenFolder/Application.temporaryCachePath", false, 104)]
        private static void OpenCachePath()
        {
            QuickOpenFolder(Application.temporaryCachePath);
        }
        

        [MenuItem("Assets/QuickOpenFolder/EditorApplication.applicationPath", false, 106)]
        private static void OpenUnityEditorPath()
        {
            var directoryInfo = new FileInfo(EditorApplication.applicationPath).Directory;
            if (directoryInfo != null)
                QuickOpenFolder(directoryInfo.FullName);
        }

        [MenuItem("Assets/QuickOpenFolder/Editor.log", false, 107)]
        private static void OpenEditorLogFolderPath()
        {
#if UNITY_EDITOR_OSX
			string rootFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(rootFolderPath, "Library");
			var logsFolder = Path.Combine(libraryPath, "Logs");
			var UnityFolder = Path.Combine(logsFolder, "Unity");
			QuickOpenFolder(UnityFolder);
#elif UNITY_EDITOR_WIN
            var rootFolderPath = System.Environment.ExpandEnvironmentVariables("%localappdata%");
            var unityFolder = Path.Combine(rootFolderPath, "Unity");
            QuickOpenFolder(Path.Combine(unityFolder, "Editor"));
#endif
        }

        private const string ASSET_PACK_PATH = "Asset Store-5.x";

        private static string GetAssetStorePathOnMac()
        {
            var rootFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(rootFolderPath, "Library");
            var unityFolder = Path.Combine(libraryPath, "Unity");
            return Path.Combine(unityFolder, ASSET_PACK_PATH);
        }

        private static string GetAssetStorePathOnWindows()
        {
            var rootFolderPath = System.Environment.ExpandEnvironmentVariables("%appdata%");
            var unityFolder = Path.Combine(rootFolderPath, "Unity");
            return Path.Combine(unityFolder, ASSET_PACK_PATH);
        }
        
        [MenuItem("Assets/QuickOpenFolder/Unity.Store", false, 108)]
        private static void OpenAssetStorePackagesFolder()
        {
            
#if UNITY_EDITOR_OSX
            string path = GetAssetStorePathOnMac();
#elif UNITY_EDITOR_WIN
            string path = GetAssetStorePathOnWindows();
#endif
            QuickOpenFolder(path);
        }
        
        [MenuItem("Assets/QuickOpenFolder/ProgramData.Unity", false, 109)]
        private static void OpenUnityUlfFolder()
        {
            
#if UNITY_EDITOR_OSX
            string path = string.Empty;
#elif UNITY_EDITOR_WIN
            string path = @"C:\ProgramData\Unity\";
#endif
            QuickOpenFolder(path);
        }
    }
}