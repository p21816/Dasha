// win32dll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"


extern "C"
{

	const int a = 1103515245;
	const int c = 12345;
	const int m = 1<<31 - 1;
	static int x = 0;

	 __declspec(dllexport)  int  rand()
	{
		x = (a*x + c) % m;
		return x & 0x7fffffff;
	}

	 __declspec(dllexport) void  srand(int x_) {
		x = x_;
	}
}