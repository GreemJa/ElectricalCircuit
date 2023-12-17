using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider
  {
    public GameObject Instantiate(string path, Vector3 at)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, at, Quaternion.identity);
    }

    public GameObject Instantiate(string path, Transform at)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, at.position, new Quaternion());
    }

    public GameObject Instantiate(string path)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab);
    }
  }
}