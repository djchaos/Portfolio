#include "stdafx.h"
#include "Cube.h"


Cube::Cube()
{
	// Build Vertex Buffer
	HR(gD3DDevice->CreateVertexBuffer(
		8 * sizeof(VertexPosCol), D3DUSAGE_WRITEONLY, 0, D3DPOOL_MANAGED, &mVB, 0));

	VertexPosCol* vertices;

	HR(mVB->Lock(0, 0, (void**)&vertices, 0));

	// V1______V4
	// |      /|
	// |    /  |
	// |  /    |
	//V2/______V3

	// Local de mes vertices
	vertices[0] = VertexPosCol(-1.f, -1.f, -1.f, 0xFFFFFFFF);
	vertices[1] = VertexPosCol(-1.f, 1.f, -1.f, 0xFF000000);
	vertices[2] = VertexPosCol(1.f, 1.f, -1.f, 0x00FF0000);
	vertices[3] = VertexPosCol(1.f, -1.f, -1.f, 0x0000FF00);

	vertices[4] = VertexPosCol(-1.f, -1.f, 1.f, 0xFFFFFFFF);
	vertices[5] = VertexPosCol(-1.f, 1.f, 1.f, 0xFF000000);
	vertices[6] = VertexPosCol(1.f, 1.f, 1.f, 0x00FF0000);
	vertices[7] = VertexPosCol(1.f, -1.f, 1.f, 0x0000FF00);

	HR(mVB->Unlock());

	// Build Index Buffer
	HR(gD3DDevice->CreateIndexBuffer(
		36 * sizeof(WORD), D3DUSAGE_WRITEONLY, D3DFMT_INDEX16, D3DPOOL_MANAGED, &mIB, 0));

	WORD* k;

	HR(mIB->Lock(0, 0, (void**)&k, 0));

	// Front face.      
	k[0] = 0; k[1] = 1; k[2] = 2;
	k[3] = 0; k[4] = 2; k[5] = 3;
	// Back face.      
	k[6] = 4; k[7] = 6; k[8] = 5;
	k[9] = 4; k[10] = 7; k[11] = 6;
	// Left face.      
	k[12] = 4; k[13] = 5; k[14] = 1;
	k[15] = 4; k[16] = 1; k[17] = 0;
	// Right face.      
	k[18] = 3; k[19] = 2; k[20] = 6;
	k[21] = 3; k[22] = 6; k[23] = 7;
	// Top face.      
	k[24] = 1; k[25] = 5; k[26] = 6;
	k[27] = 1; k[28] = 6; k[29] = 2;
	// Bottom face.      
	k[30] = 4; k[31] = 0; k[32] = 3;
	k[33] = 4; k[34] = 3; k[35] = 7;

	HR(mIB->Unlock());
}

Cube::Cube(float x, float y, float z)
{
	// Build Vertex Buffer
	HR(gD3DDevice->CreateVertexBuffer(
		8 * sizeof(VertexPosCol), D3DUSAGE_WRITEONLY, 0, D3DPOOL_MANAGED, &mVB, 0));

	VertexPosCol* vertices;

	HR(mVB->Lock(0, 0, (void**)&vertices, 0));

	float const OFFSET = 2.1f;

	// V1______V4
	// |      /|
	// |    /  |
	// |  /    |
	//V2/______V3

	// Local de mes vertices
	vertices[0] = VertexPosCol(-1.f + (x*OFFSET), -1.f + (y*OFFSET), -1.f + (z*OFFSET), 0xFFFFFFFF);
	vertices[1] = VertexPosCol(-1.f + (x * OFFSET), 1.f + (y * OFFSET), -1.f + (z * OFFSET), 0xFF000000);
	vertices[2] = VertexPosCol(1.f + (x * OFFSET), 1.f + (y * OFFSET), -1.f + (z * OFFSET), 0x00FF0000);
	vertices[3] = VertexPosCol(1.f + (x * OFFSET), -1.f + (y * OFFSET), -1.f + (z * OFFSET), 0x0000FF00);

	vertices[4] = VertexPosCol(-1.f + (x * OFFSET), -1.f + (y * OFFSET), 1.f + (z * OFFSET), 0xFFFFFFFF);
	vertices[5] = VertexPosCol(-1.f + (x * OFFSET), 1.f + (y * OFFSET), 1.f + (z * OFFSET), 0xFF000000);
	vertices[6] = VertexPosCol(1.f + (x * OFFSET), 1.f + (y * OFFSET), 1.f + (z * OFFSET), 0x00FF0000);
	vertices[7] = VertexPosCol(1.f + (x * OFFSET), -1.f + (y * OFFSET), 1.f + (z * OFFSET), 0x0000FF00);

	HR(mVB->Unlock());

	// Build Index Buffer
	HR(gD3DDevice->CreateIndexBuffer(
		36 * sizeof(WORD), D3DUSAGE_WRITEONLY, D3DFMT_INDEX16, D3DPOOL_MANAGED, &mIB, 0));

	WORD* k;

	HR(mIB->Lock(0, 0, (void**)&k, 0));

	// Front face.      
	k[0] = 0; k[1] = 1; k[2] = 2;
	k[3] = 0; k[4] = 2; k[5] = 3;
	// Back face.      
	k[6] = 4; k[7] = 6; k[8] = 5;
	k[9] = 4; k[10] = 7; k[11] = 6;
	// Left face.      
	k[12] = 4; k[13] = 5; k[14] = 1;
	k[15] = 4; k[16] = 1; k[17] = 0;
	// Right face.      
	k[18] = 3; k[19] = 2; k[20] = 6;
	k[21] = 3; k[22] = 6; k[23] = 7;
	// Top face.      
	k[24] = 1; k[25] = 5; k[26] = 6;
	k[27] = 1; k[28] = 6; k[29] = 2;
	// Bottom face.      
	k[30] = 4; k[31] = 0; k[32] = 3;
	k[33] = 4; k[34] = 3; k[35] = 7;

	HR(mIB->Unlock());
}

Cube::~Cube()
{
}

void Cube::Draw(ID3DXEffect* mFx)
{
	HR(gD3DDevice->SetStreamSource(0, mVB, 0, sizeof(VertexPosCol)));
	HR(gD3DDevice->SetVertexDeclaration(VertexPosCol::decl));
	HR(gD3DDevice->SetIndices(mIB));

	UINT nbPass;
	HR(mFx->Begin(&nbPass, 0));

	for (int i = 0; i < nbPass; i++)
	{
		HR(mFx->BeginPass(i));

		HR(gD3DDevice->DrawIndexedPrimitive(D3DPT_TRIANGLELIST, 0, 0, 8, 0, 12));

		HR(mFx->EndPass());
	}

	HR(mFx->End());
}

void Cube::Test(D3DXMATRIX*  mat)
{
	cubeMT = mat;
}
