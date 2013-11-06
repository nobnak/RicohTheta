using UnityEngine;

public static class Equirectangular {
	public const float TWO_PI = 6.28318530718f;
	public const float PI_OVER_TWO = 1.57079632679f;
	
	public static Mesh Create() {
		int ny = 10;
		int nx = ny * 2;
		
		float dx = 1f / nx;
		float dy = 1f / ny;
		
		var vertices = new Vector3[(nx + 1) * (ny + 1)];
		var uvs = new Vector2[vertices.Length];
		for (var iy = 0; iy <= ny; iy++) {
			for (var ix = 0; ix <= nx; ix++) {
				var x = dx * ix;
				var y = dy * iy;
				
				var lambda = TWO_PI * x;
				var phi = PI_OVER_TWO * (2f * y - 1f);
				
				var cosPhi = Mathf.Cos(phi);
				var pos = new Vector3(cosPhi * Mathf.Cos(lambda), Mathf.Sin(phi), cosPhi * Mathf.Sin(lambda));
				
				var index = iy * (nx + 1) + ix;
				vertices[index] = pos;
				uvs[index] = new Vector2(Mathf.Clamp01(x), Mathf.Clamp01(y));
			}
		}
		
		var triangles = new int[6 * nx * ny];
		for (var iy = 0; iy < ny; iy++) {
			for (var ix = 0; ix < nx; ix++) {
				var vertexIndex = iy * (nx + 1) + ix;
				var triangleIndex = 6 * (iy * nx + ix);
				triangles[triangleIndex]	= vertexIndex;
				triangles[triangleIndex+1]	= vertexIndex + 1;
				triangles[triangleIndex+2]	= vertexIndex + (nx + 2);
				triangles[triangleIndex+3]	= vertexIndex;
				triangles[triangleIndex+4]	= vertexIndex + (nx + 2);
				triangles[triangleIndex+5]	= vertexIndex + (nx + 1);
			}
		}
		
		var mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uvs;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		return mesh;
	}
}
