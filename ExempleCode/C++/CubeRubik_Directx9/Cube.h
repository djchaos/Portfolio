#pragma once
#include "D3DApp.h"
#include "Vertex.h"
class Cube
	: public D3DApp
{
public:
	Cube();
	Cube(float x, float y, float z );
	~Cube();

	void Draw(ID3DXEffect* mFx);

	void Test(D3DXMATRIX* mat);
	D3DXMATRIX* cubeW() { return cubeMT; }
	void SetPosition(float x, float y, float z) { D3DXMatrixTranslation(&T, x, y, z); }

private:

	D3DXMATRIX* cubeMT;
	D3DXMATRIX T;

	IDirect3DVertexBuffer9* mVB;
	IDirect3DIndexBuffer9* mIB;
};

