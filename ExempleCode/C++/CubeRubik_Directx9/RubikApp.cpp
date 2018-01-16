#include "stdafx.h"
#include "RubikApp.h"

RubikApp::RubikApp()
{
}

RubikApp::RubikApp(HINSTANCE hInstance, int nCmdShow)
	: D3DApp(hInstance, nCmdShow)
	, currRot(0.f)
	, eyePos(0.f, 5.f, 20.f)
	, target(0.f, 0.f, 0.f)
	, up(0.f, 1.0f, 0.f)
{
	CreateAllVertexDeclaration();
	const float CUBE_LENGTH = 27;
	const int CUBE_OFFSET = 3;
	D3DXMATRIX T;
	int chiffre = 0;

	for (int x = 0; x < CUBE_OFFSET; x++)
	{
		for (int y = 0; y < CUBE_OFFSET; y++)
		{
			for (int z = 0; z < CUBE_OFFSET; z++)
			{
				cube[chiffre] = new Cube(x, y, z);
				//cube[chiffre]->SetPosition(x*2, y*2, z * 2);
		        //cube[chiffre]->Test(D3DXMatrixTranslation(&T, x, y, z));
				chiffre++;
			}
		}
	}

	HR(D3DXCreateEffectFromFileW(
		gD3DDevice, L"Transform.fx", 0, 0, D3DXSHADER_DEBUG, 0, &mFx, &mErrors));

	if (mErrors)
	{
		MessageBoxW(0, (LPCWSTR)mErrors->GetBufferPointer(), 0, 0);
	}

	mhTech = mFx->GetTechniqueByName("FogTech");
	mFx->SetTechnique(mhTech);

	mhWVP = mFx->GetParameterByName(0, "gWVP");
	mhEyePos = mFx->GetParameterByName(0, "gEyePos");
	mhFogColor = mFx->GetParameterByName(0, "gFogColor");
	mhFogStart = mFx->GetParameterByName(0, "gFogStart");
	mhFogRange = mFx->GetParameterByName(0, "gFogRange");

	HR(mFx->SetVector(mhFogColor, &D3DXVECTOR4(0.5f, 0.5f, 0.5f, 1.0f)));
	HR(mFx->SetFloat(mhFogStart, 5.0f));
	HR(mFx->SetFloat(mhFogRange, 50000.0f));

	D3DXMatrixLookAtRH(&view, &eyePos, &target, &up);
	D3DXMatrixPerspectiveFovRH(&proj, D3DX_PI / 4,
		(float)d3dPP.BackBufferWidth / (float)d3dPP.BackBufferHeight, 1.f, 5000.0f);

	// Fixed pipeline
	//HR(gD3DDevice->SetTransform(D3DTS_VIEW, &view));
	//HR(gD3DDevice->SetTransform(D3DTS_PROJECTION, &proj));
	
	//HR(gD3DDevice->SetRenderState(D3DRS_LIGHTING, false));
	//HR(gD3DDevice->SetRenderState(D3DRS_CULLMODE, D3DCULL_NONE));
	//HR(gD3DDevice->SetRenderState(D3DRS_FILLMODE, D3DFILL_WIREFRAME));
}

RubikApp::~RubikApp()
{
	ReleaseCOM(mVB);
	ReleaseCOM(mIB);

	DestroyAllDeclaration();
}

void RubikApp::Update()
{
	currRot += 0.0001f;
}

void RubikApp::Draw()
{
	HR(gD3DDevice->Clear(0, 0, 
		D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER,
		D3DCOLOR_XRGB(128,128, 128), 1.0f, 0));

	HR(gD3DDevice->SetStreamSource(0, mVB, 0, sizeof(VertexPosCol)));
	HR(gD3DDevice->SetVertexDeclaration(VertexPosCol::decl));
	HR(gD3DDevice->SetIndices(mIB));

	HR(mFx->SetValue(mhEyePos, &eyePos, sizeof(D3DXVECTOR3)));

	D3DXMATRIX Ry;
	

	D3DXMatrixRotationAxis(&Ry, &D3DXVECTOR3(0, 1, 0), currRot);

	HR(gD3DDevice->BeginScene());

	for each(Cube* currentCube in cube)
	{
		D3DXMATRIX WVP =  Ry * view * proj;
		//*currentCube->cubeW()
		mFx->SetMatrix(mhWVP, &WVP);
		mFx->CommitChanges();
		currentCube->Draw(mFx);
	}

	HR(gD3DDevice->EndScene());
	HR(gD3DDevice->Present(0, 0, 0, 0));
}
