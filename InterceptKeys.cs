using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace slate;

public class KeyboardEventArgs(int code, int type)
{
  public readonly int Code = code;
  public readonly int Type = type;
}
public delegate void KeyboardEventHandler(object? sender, KeyboardEventArgs args);
public class InterceptKeys
{
  private static IntPtr hookId = IntPtr.Zero;
  private static readonly KeyboardProc proc = HookCallback;
  public static event KeyboardEventHandler? Keydown;
  public delegate IntPtr KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
  public static void Hook()
  {
    using Process currentProcess = Process.GetCurrentProcess();
    using ProcessModule currentModule = currentProcess.MainModule!;
    hookId = SetWindowsHookEx(13, proc, GetModuleHandle(currentModule.ModuleName), 0);
  }
  public static void UnHook()
  {
    UnhookWindowsHookEx(hookId);
  }
  private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
  {
    if (nCode >= 0 && wParam == 0x0100 /* WM_KEYDOWN */)
    {
      int code = Marshal.ReadInt32(lParam);
      Keydown?.Invoke(null, new KeyboardEventArgs(code, 0));
    }
    return CallNextHookEx(hookId, nCode, wParam, lParam);
  }
  [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  private static extern IntPtr SetWindowsHookEx(int idHook,
        KeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

  [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)]
  private static extern bool UnhookWindowsHookEx(IntPtr hhk);

  [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
      IntPtr wParam, IntPtr lParam);

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  private static extern IntPtr GetModuleHandle(string lpModuleName);
}
