using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingDirty.Core.Container
{
	public interface IContainer
	{
		void Register<TService, TClass>() where TClass : TService;
		void RegisterInstance<TService>(TService instance);

		TService Resolve<TService>();
	}
}
