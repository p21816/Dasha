#include <Windows.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM); // ��� ����, ���� ���������, ���������

int APIENTRY WinMain(HINSTANCE hInstance,
	HINSTANCE hInstPrev,
	LPSTR str,
	int modShow)
{
	HWND hwnd; //����� ����, ����� ������� ����� ��������� �����
	WNDCLASSEX wndclass; // ����������� ����������, ������� ����� �������� ����������� ������ ����

	wndclass.cbWndExtra = 0; // ��� ������ ��� �����, ������� ����� ���������� � ������
	wndclass.cbWndExtra = 0;
	wndclass.cbSize = sizeof(wndclass);

	wndclass.hbrBackground = ((HBRUSH)CreateSolidBrush(RGB(200, 200, 200)));
	//wndclass.hbrBackground = ((HBRUSH)GetStockObject(BLACK_BRUSH));
	wndclass.hCursor = LoadCursor(NULL, IDC_HAND);
	wndclass.hIcon = LoadIcon(NULL, IDI_ERROR);
	wndclass.hIconSm = LoadIcon(NULL, IDI_ERROR);

	wndclass.hInstance = hInstance;
	wndclass.lpfnWndProc = WndProc;
	wndclass.lpszClassName = L"MyClass"; // L - ����������, ��� ������ UniCode
	wndclass.lpszMenuName = NULL;
	wndclass.style = CS_DBLCLKS;

	RegisterClassEx(&wndclass); // ���������������� ��� �����, ������� ������ ��� �������
	hwnd = CreateWindowEx(WS_EX_TOPMOST,
		L"MyClass",
		L"MyFirstWindow",
		WS_OVERLAPPEDWINDOW,
		100, 100, //100 , 100 - ��������� �����
		500, 300, // ������, ������
		NULL,
		NULL,
		hInstance,
		NULL);

	if (hwnd == NULL)
	{
		return -1;
	}

	//ShowWindow(hwnd, modShow); // ���������� �������� ����� ������
	ShowWindow(hwnd, SW_NORMAL); // ���������� �������� ����� ������

	UpdateWindow(hwnd);

	MSG msg; // ����������, ������� ����� ������� ���������

	while (GetMessage(&msg, hwnd, 0, 0) == TRUE)// 0, 0 - ������������ ��� ���������
	{
		DispatchMessage(&msg); //�������� ���� ��������� � WinProc
	}

	return 0;
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc;

	switch (msg)
	{
	case WM_PAINT:
		hdc = BeginPaint(hwnd, &ps);
		TextOut(hdc, 0, 0, L"Hello, Windows!", 15);
		EndPaint(hwnd, &ps);
		return 0;
	default:
		return DefWindowProc(hwnd, msg, wParam, lParam);

		// Process other messages.   
	}
}
