using UnityEngine;
using UnityEditor;

public static class ThetaEditor {
	
	[MenuItem("Custom/GenerateEquirectangularSphere")]
	public static void GenerateEquirectangularSphere() {
		var assetName = "EquirectangularSphere.asset";
		
		var mesh = nobnak.Geometry.Equirectangular.Create();
		AssetDatabase.CreateAsset(mesh, System.IO.Path.Combine("Assets/Generated", assetName));
	}
	
}
			