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
			using (var storageFile = IsolatedStorageFile.GetUserStoreForApplication())
			{
				using (var fileStream = storageFile.CreateFile(fileName))
				{
					var serializer = new XmlSerializer(typeof(TData));
					serializer.Serialize(fileStream, data);
				}
			}
		}

		public TData LoadData<TData>(string fileName)
		{
			TData data = default(TData);
			using (var storageFile = IsolatedStorageFile.GetUserStoreForApplication())
			{
				if (storageFile.FileExists(fileName))
				{
					using (var fileStream = storageFile.OpenFile(fileName, FileMode.Open))
					{
						var serializer = new XmlSerializer(typeof(TData));
						var obj = serializer.Deserialize(fileStream);

						if (obj != null && obj is TData)
						{
							data = (TData)obj;
						}
					}
				}
			}

			if (Object.Equals(data, default(TData)))
			{
				data = Activator.CreateInstance<TData>();
			}

			return data;
		}
	}
}
