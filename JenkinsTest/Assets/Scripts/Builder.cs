using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Builder : MonoBehaviour
{
    /// <summary>
    /// 根据jenkins的参数读取到buildsetting里
    /// </summary>
    /// <returns></returns>
    public static BuildSetting GetPCBuildSetting()
    {
        string[] parameters = Environment.GetCommandLineArgs();
        BuildSetting buildSetting = new BuildSetting();
        foreach (string str in parameters)
        {
            if (str.StartsWith("Version"))
            {
                var tempParam = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (tempParam.Length == 2)
                {
                    buildSetting.Version = tempParam[1].Trim();
                }
            }
            else if (str.StartsWith("Build"))
            {
                var tempParam = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (tempParam.Length == 2)
                {
                    buildSetting.Build = tempParam[1].Trim();
                }
            }
            else if (str.StartsWith("Name"))
            {
                var tempParam = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (tempParam.Length == 2)
                {
                    buildSetting.Name = tempParam[1].Trim();
                }
            }
            else if (str.StartsWith("Debug"))
            {
                var tempParam = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (tempParam.Length == 2)
                {
                    bool.TryParse(tempParam[1], out buildSetting.Debug);
                }
            }
        }
        return buildSetting;
    }

    /// <summary>
    /// 根据读取的数据在unity里面设置对应
    /// </summary>
    static string SetPcSetting(BuildSetting setting)
    {
        string suffix = "_";
        if (!string.IsNullOrEmpty(setting.Version))
        {
            PlayerSettings.bundleVersion = setting.Version;
            suffix += setting.Version;
        }
        if (!string.IsNullOrEmpty(setting.Build))
        {
            PlayerSettings.macOS.buildNumber = setting.Build;
            suffix += "_" + setting.Build;
        }
        if (!string.IsNullOrEmpty(setting.Name))
        {
            PlayerSettings.productName = setting.Name;
        }
        if (setting.Debug)
        {
            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.connectProfiler = true;
            suffix += "_Debug";
        }
        else
        {
            EditorUserBuildSettings.development = false;
        }
        return suffix;
    }
}