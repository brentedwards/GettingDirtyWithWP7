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
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;

namespace GettingDirty.Core.Repositories
{
	public class IsolatedStorageRepository : IIsolatedStorageRepository
	{
		public void SaveData<TData>(TData data, string fileName)
		{
			// TODO: 1. SaveData
		}

		public TData LoadData<TData>(string fileName)
		{
			// TODO: 2. LoadData
			return default(TData);
		}
	}
}
