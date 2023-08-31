#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <stdio.h>
#include "ExportFuncs/ExportFuncs.h"

extern "C"
{
    __declspec(dllexport) void ExterFuncs(int hash, void** Import, void** Export);
}

void ExterFuncs(int hash, void** Import, void** Export)
{
    printf("Function Called\n");
    if (hash != 40000)
    {
        printf("ERROR HASH KEY INCORRECT");
        return;

    }


    *Import = &PrintConsole;
    Import[1] = &printnum;

    using FN = void(__cdecl)(const char* a);
    FN* func = (FN*)*Export;
    func("Called from c++");
}

















BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

