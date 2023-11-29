using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using MuXunProxy.Controllers;
using MuXunProxy.Models;
//using WindowsJobAPI;

namespace MuXunProxy;

public static class Global
{

    //public static readonly JobObject Job = new();


    public static readonly string MuXunProxyDir;
    public static readonly string MuXunProxyExecutable;
 
    //static Global()
    //{
    //    MuXunProxyExecutable = Application.ExecutablePath;
    //    MuXunProxyDir = Application.StartupPath;
    //}


    //public static JsonSerializerOptions NewCustomJsonSerializerOptions() => new()
    //{
    //    WriteIndented = true,
    //    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    //};
}