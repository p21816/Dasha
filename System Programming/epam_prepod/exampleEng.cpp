/* The following example shows how to register a local window class
   and use it to create a simple main window. */

// The main library for create win32-applications
#include <windows.h>

/* The library for using TCHAR data type 
   The TCHAR data type is a Win32 character string that can be used to describe ANSI, 
   double-byte character set (DBCS), or Unicode strings.   */    
#include <tchar.h>                          
                                            /*  #ifdef UNICODE
                                                    typedef WCHAR TCHAR;
                                                #else
                                                    typedef char TCHAR;
                                                #endif  */


// Function prototypes
LRESULT CALLBACK WndProc (HWND, UINT, WPARAM, LPARAM) ;


/* Application entry point
   The WinMain function is the conventional name for the user-provided entry point
   for a Microsoft Windows-based application.  
   If the function succeeds, terminating when it receives a WM_QUIT message,
   it should return the exit value contained in that message's wParam parameter.
   If the function terminates before entering the message loop, it should return zero. */

int APIENTRY _tWinMain( HINSTANCE hInstance,        // handle to the current instance of the application
                        HINSTANCE hPrevInstance,    /* Handle to the previous instance of the application.
                                                       This parameter is always NULL.   */
                        LPTSTR szCmdLine,           /* Pointer to a null-terminated string specifying the command line
                                                       for the application, excluding the program name. */
                        int iCmdShow)               /* Specifies how the window is to be shown. 
                                                       This parameter can be one of the following values:                                                       
SW_HIDE - Hides the window and activates another window.
SW_MAXIMIZE - Maximizes the specified window.
SW_MINIMIZE - Minimizes the specified window and activates the next top-level window in the Z order.
SW_RESTORE - Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
SW_SHOW - Activates the window and displays it in its current size and position.
SW_SHOWMAXIMIZED - Activates the window and displays it as a maximized window.
SW_SHOWMINIMIZED - Activates the window and displays it as a minimized window.
SW_SHOWMINNOACTIVE - Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
SW_SHOWNA - Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.
SW_SHOWNOACTIVATE - Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except the window is not actived.
SW_SHOWNORMAL - Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.  */

{
    HWND        hwnd ;          // handler to a window
    MSG         msg ;           // the MSG structure contains message information from a thread's message queue
    WNDCLASSEX  wndclass ;      // the WNDCLASSEX structure contains window class information
    
    // Fill in the window class structure with parameters 
    // that describe the main window. 
 
    wndclass.cbSize        = sizeof (wndclass) ;                        // size of structure 
    wndclass.style         = CS_HREDRAW | CS_VREDRAW ;                  // redraw if size changes 
    wndclass.lpfnWndProc   = WndProc ;                                  // points to window procedure 
    wndclass.cbClsExtra    = 0 ;                                        // no extra class memory 
    wndclass.cbWndExtra    = 0 ;                                        // no extra window memory 
    wndclass.hInstance     = hInstance ;                                // handle to instance 
    wndclass.hIcon         = LoadIcon (NULL, IDI_APPLICATION) ;         // predefined application icon 
    wndclass.hCursor       = LoadCursor (NULL, IDC_ARROW) ;             // predefined arrow 
    wndclass.hbrBackground = (HBRUSH) GetStockObject (WHITE_BRUSH) ;    // white background brush 
    wndclass.lpszMenuName  = NULL ;                                     // name of menu resource 
    wndclass.lpszClassName = L"HelloWin" ;                              // name of window class 
    wndclass.hIconSm       = LoadIcon (NULL, IDI_APPLICATION) ;         // small class icon 
     
    // Register the window class
    RegisterClassEx (&wndclass) ;

    
    /*  This function creates an overlapped, pop-up, or child window. 
        It specifies the window class, window title, window style, 
        and (optionally) the initial position and size of the window 
        If the function succeeds, the return value is a handle to the new window.
        If the function fails, the return value is NULL.
        To get extended error information, call GetLastError.   */
    
    hwnd = CreateWindowEx ( WS_EX_TOPMOST,                  // specifies the extended style of the window
                            L"HelloWin",                    // window class name
                            L"The Hello Students Program",  // window caption
                            WS_OVERLAPPEDWINDOW,            // window style
                            CW_USEDEFAULT,                  // initial x position
                            CW_USEDEFAULT,                  // initial y position
                            CW_USEDEFAULT,                  // initial x size
                            CW_USEDEFAULT,                  // initial y size
                            NULL,                           // parent window handle
                            NULL,                           // window menu handle
                            hInstance,                      // program instance handle
		                    NULL) ;		                    // creation parameters

    // If the main window cannot be created, terminate the application
    if (!hwnd)
        return false;
        
    // Show the window and paint its contents
    ShowWindow (hwnd,           // handle to the window
                iCmdShow) ;     /* Specifies how the window is to be shown. This parameter is ignored
                                   the first time an application calls ShowWindow, if the program 
                                   that launched the application provides a STARTUPINFO structure.
                                   Otherwise, the first time ShowWindow is called, the value should be the value
                                   obtained by the WinMain function in its nCmdShow parameter.  */
                                   
    /* The UpdateWindow function updates the client area of the specified window by sending a WM_PAINT message
       to the window if the window's update region is not empty. The function sends a WM_PAINT message
       directly to the window procedure of the specified window, bypassing the application queue.
       If the update region is empty, no message is sent.   */
    UpdateWindow (hwnd) ;   // handle to the window to be updated

    /* Start the message loop   
       The system automatically creates a message queue for each thread. If the thread creates one or more windows,
       a message loop must be provided; this message loop retrieves messages from the thread's message queue and
       dispatches them to the appropriate window procedures. 
       Because the system directs messages to individual windows in an application, a thread must create
       at least one window before starting its message loop. Most applications contain a single thread
       that creates windows. A typical application registers the window class for its main window,
       creates and shows the main window, and then starts its message loop — all in the WinMain function.
       You create a message loop by using the GetMessage and DispatchMessage functions.
       If your application must obtain character input from the user, include the TranslateMessage function
       in the loop. */
    
    /* The GetMessage function retrieves a message from the calling thread's message queue.
       The function dispatches incoming sent messages until a posted message is available for retrieval.    
       If the function retrieves a message other than WM_QUIT, the return value is nonzero.
       If the function retrieves the WM_QUIT message, the return value is zero. 
       If there is an error, the return value is -1. For example, the function fails if hWnd
       is an invalid window handle or lpMsg is an invalid pointer.  */
    
    BOOL bRet;
    
    while( (bRet = GetMessage( &msg, NULL, 0, 0 )) != 0)    
    { 
        if (bRet == -1)
        {
            // handle the error and possibly exit
        }
        else
        {
            TranslateMessage(&msg); // translates virtual-key messages into character messages
            DispatchMessage(&msg);  /* Dispatches a message to a window procedure.
                                       It is typically used to dispatch a message retrieved by the GetMessage function. */
        }
    }  
    
    // Return the exit code to the system
    return msg.wParam ;
}


LRESULT CALLBACK WndProc (HWND hwnd,                    // handle to the window procedure that received the message
                          UINT iMsg,                    // specifies the message                            
                          WPARAM wParam, LPARAM lParam) /* Specifies additional message information. 
                                                           The content of this parameter depends on the value
                                                           of the Msg parameter. */
{
    HDC         hdc ;       // handle to a device context (DC)
    PAINTSTRUCT ps ;        /* The PAINTSTRUCT structure contains information for an application.
                               This information can be used to paint the client area of a window owned by
                               that application. */
    RECT        rect ;      /* The RECT structure defines a rectangle by the coordinates of its upper-left and
                               lower-right corners. */

    switch (iMsg) {
            
            /*  The WM_CREATE message is sent when an application requests that a window be created
                by calling the CreateWindowEx or CreateWindow function. 
                (The message is sent before the function returns.)
                The window procedure of the new window receives this message after the window is created,
                but before the window becomes visible. 
                A window receives this message through its WindowProc function. */
            
            case WM_CREATE :
                return 0 ;

            
            /* The WM_PAINT message is sent when the system or another application makes a request to paint
               a portion of an application's window. The message is sent when the UpdateWindow or RedrawWindow
               function is called, or by the DispatchMessage function when the application obtains a WM_PAINT
               message by using the GetMessage or PeekMessage function. 
               A window receives this message through its WindowProc function.  */
               
            case WM_PAINT :
                /* The BeginPaint function prepares the specified window for painting and
                   fills a PAINTSTRUCT structure with information about the painting. 
                   If the function succeeds, the return value is the handle to a display device
                   context for the specified window. If the function fails, the return value is NULL,
                   indicating that no display device context is available.  */


	            hdc = BeginPaint (hwnd,     // handle to the window to be repainted
	                              &ps) ;    // !!!POINTER!!! to the PAINTSTRUCT structure that will receive painting information

                    /* The GetClientRect function retrieves the coordinates of a window's client area.
                       The client coordinates specify the upper-left and lower-right corners of the client area.
                       Because client coordinates are relative to the upper-left corner of a window's client area,
                       the coordinates of the upper-left corner are (0,0). */
                    GetClientRect (hwnd,        // handle to the window whose client coordinates are to be retrieved
                                   &rect) ;     /* Pointer to a RECT structure that receives the client coordinates.
                                                   The left and top members are zero. The right and bottom members contain
                                                   the width and height of the window.  */
               
                    // function draws formatted text in the specified rectangle
                    DrawText (hdc,                                      // handle to the device context
                              L"Hello, students ! ! !",                 /* Pointer to the string that specifies the text to be drawn.
                                                                           If the nCount parameter is -1, the string must be null-terminated. */
                              -1,                                       /* Specifies the length in TCHARS of the string.
                                                                           If nCount is -1, then the lpString parameter is assumed to be
                                                                           a pointer to a null-terminated string and DrawText computes
                                                                           the character count automatically. */
                              &rect,                                    /* Pointer to a RECT structure that contains the rectangle
                                                                           (in logical coordinates) in which the text is to be formatted.   */
                              DT_SINGLELINE | DT_CENTER | DT_VCENTER) ; // specifies the method of formatting the text
                                                                                                                                                     
                              
                /* The EndPaint function marks the end of painting in the specified window.
                   This function is required for each call to the BeginPaint function, 
                   but only after painting is complete. */
                EndPaint (hwnd,     // handle to the window that has been repainted
                          &ps) ;    /* Pointer to a PAINTSTRUCT structure that contains the painting information
                                       retrieved by BeginPaint. */

                return 0 ;

        /* The WM_DESTROY message is sent when a window is being destroyed. It is sent to the window procedure
           of the window being destroyed after the window is removed from the screen. 
           This message is sent first to the window being destroyed and then to the child windows (if any)
           as they are destroyed. During the processing of the message, it can be assumed that all child windows
           still exist.
           A window receives this message through its WindowProc function.  */
           
        case WM_DESTROY :
            
            /* Use the PostQuitMessage function to exit a message loop. PostQuitMessage posts the WM_QUIT message
               to the currently executing thread. The thread's message loop terminates and returns control
               to the system when it encounters the WM_QUIT message. An application usually calls PostQuitMessage
               in response to the WM_DESTROY message.   */
           
            PostQuitMessage (0) ;   // posts the WM_QUIT message to the currently executing thread
            return 0 ;
    }

    /* The DefWindowProc function calls the default window procedure to provide default processing
       for any window messages that an application does not process. This function ensures that every message
       is processed. DefWindowProc is called with the same parameters received by the window procedure. */
    return DefWindowProc (hwnd, iMsg, wParam, lParam) ;
}