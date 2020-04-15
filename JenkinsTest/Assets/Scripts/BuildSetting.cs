using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BuildSetting
{
    //版本号
    public string Version = "";
    //build次数
    public string Build = "";
    //程序名称
    public string Name = "";
    //是否debug
    public bool Debug = true;
    //渠道
    //public Place Place = Place.None;
    //多线程渲染
    public bool MulRendering = true;
    //是否IL2CPP
    public bool IL2CPP = false;
    //是否开启动态合批
    public bool DynamicBatching = false;
}