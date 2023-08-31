using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace AsyncAwaitWPF;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			Thread.Sleep(25);
			Progress.Value++;
		} //UI Updates finden am Main Thread statt, Main Thread wird blockiert
	}

	private void Button_Click1(object sender, RoutedEventArgs e)
	{
		Task.Run(() =>
		{
			Dispatcher.Invoke(() => Progress.Value = 0); //UI Updates sind nicht erlaubt von Side Threads/Tasks
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(25);
				Dispatcher.Invoke(() => Progress.Value++); //Dispatcher.Invoke(...): Führe den gegebenen Code auf dem UI Thread aus
			}
		});
	}

	private async void Button_Click2(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			await Task.Delay(25);
			Progress.Value++;
		}
	}

	private async void Button_Click3(object sender, RoutedEventArgs e)
	{
		using HttpClient client = new HttpClient();
		Task<HttpResponseMessage> responseTask = client.GetAsync(@"http://www.gutenberg.org/files/54700/54700-0.txt");
		Button1.IsEnabled = false;
		TB.Text = "Text wird geladen...";
		HttpResponseMessage resp = await responseTask;
		if (resp.IsSuccessStatusCode)
		{
			Task<string> textTask = resp.Content.ReadAsStringAsync();
			TB.Text = "Text wird ausgelesen...";
			await Task.Delay(250);
			string text = await textTask;
			TB.Text = text;
			Button1.IsEnabled = true;
		}
	}
}