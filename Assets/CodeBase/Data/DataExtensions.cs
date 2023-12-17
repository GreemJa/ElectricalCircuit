using UnityEngine;

namespace CodeBase.Data
{
  public static class DataExtensions
  {
    public static string ToJson(this object obj) => 
      JsonUtility.ToJson(obj);

    public static T ToDeserialized<T>(this string json) =>
      JsonUtility.FromJson<T>(json);

    public static Vector4 ToVector4(this Quaternion rotation) =>
      new Vector4(rotation.x, rotation.y, rotation.z, rotation.w);
  }
}