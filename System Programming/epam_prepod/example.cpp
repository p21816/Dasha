#include <windows.h>
#include <tchar.h>                          
                                            
LRESULT CALLBACK WndProc (HWND, UINT, WPARAM, LPARAM) ;

int APIENTRY _tWinMain( HINSTANCE hInstance,HINSTANCE hPrevInstance,LPTSTR szCmdLine,int iCmdShow)              
{
    HWND hwnd;
    MSG  msg;      
    WNDCLASSEX  wndclass; 
    
    wndclass.cbSize        = sizeof (wndclass) ;                       
    wndclass.style         = CS_HREDRAW | CS_VREDRAW ;                 
    wndclass.lpfnWndProc   = WndProc ;                                 
    wndclass.cbClsExtra    = 0 ;                                       
    wndclass.cbWndExtra    = 0 ;                                       
    wndclass.hInstance     = hInstance ;                               
    wndclass.hIcon         = LoadIcon (NULL, IDI_APPLICATION) ;        
    wndclass.hCursor       = LoadCursor (NULL, IDC_ARROW) ;            
    wndclass.hbrBackground = (HBRUSH) GetStockObject (WHITE_BRUSH) ;   
    wndclass.lpszMenuName  = NULL ;                                    
    wndclass.lpszClassName = L"HelloWin" ;                             
    wndclass.hIconSm       = LoadIcon (NULL, IDI_APPLICATION) ;        
     
    RegisterClassEx (&wndclass) ;

    hwnd = CreateWindowEx ( WS_EX_TOPMOST,                  
                            L"HelloWin",                    
                            L"The Hello Students Program",  
                            WS_OVERLAPPEDWINDOW,            
                            CW_USEDEFAULT,                  
                            CW_USEDEFAULT,                  
                            CW_USEDEFAULT,                  
                            CW_USEDEFAULT,                  
                            NULL,                           
                            NULL,                           
                            hInstance,                      
		                    NULL) ;		                    

    if (!hwnd)
        return false;
        
    ShowWindow (hwnd,iCmdShow) ; 
    UpdateWindow (hwnd) ;   
    
    BOOL bRet;
    
    while( (bRet = GetMessage( &msg, NULL, 0, 0 )) != 0) { 
        if (bRet == -1) {
             return false;
        }
        else {
            TranslateMessage(&msg); 
            DispatchMessage(&msg);                                         
        }
    }  
    return msg.wParam ;
}


LRESULT CALLBACK WndProc (HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) 
{
    HDC hdc ;       
    PAINTSTRUCT ps ;        
    RECT rect ;      
    switch (iMsg) {            
        case WM_PAINT :                
            hdc = BeginPaint (hwnd, &ps) ;
                GetClientRect (hwnd,&rect) ;
                DrawText (hdc, L"Hello, students ! ! !",-1,&rect,DT_SINGLELINE | DT_CENTER | DT_VCENTER) ;                                                                                                                                                       
            EndPaint (hwnd, &ps) ;    
            return 0 ;

        case WM_DESTROY :            
            PostQuitMessage (0) ; 
            return 0 ;
    }
    return DefWindowProc (hwnd, iMsg, wParam, lParam) ;
}