using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GettingDirty.Core.Repositories
{
	public interface IIsolatedStorageRepository
	{
		void SaveData<T>(T data, String fileName);
		T LoadData<T>(String fileName);
	}
}
