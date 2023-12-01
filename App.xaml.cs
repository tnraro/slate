using System.Configuration;
using System.Data;
using System.Media;
using System.Windows;
using System;
using System.Runtime.InteropServices;

namespace slate;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  public App()
  {
    InterceptKeys.Hook();
    InterceptKeys.Keydown += HandleKeyboard;
  }
  public static void PlaySound()
  {
    SoundPlayer player = new(@".\assets\pop.wav");
    player.Load();
    player.Play();
    player.Dispose();
  }
  void ExitApp(object sender, ExitEventArgs e)
  {
    InterceptKeys.Keydown -= HandleKeyboard;
    InterceptKeys.UnHook();
  }
  void HandleKeyboard(object? sender, KeyboardEventArgs args)
  {
    if (args.Code == 123 /* F12 */)
    {
      PlaySound();
    // MessageBox.Show(args.Code.ToString());
    }
  }
}

