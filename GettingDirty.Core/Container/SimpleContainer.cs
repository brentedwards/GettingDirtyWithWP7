﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Reflection;

namespace GettingDirty.Core.Container
{
	public class DuplicateRegistrationException : Exception
	{
		public DuplicateRegistrationException() { }
		public DuplicateRegistrationException(string message) : base(message) { }
		public DuplicateRegistrationException(string message, Exception inner) : base(message, inner) { }
	}

	public sealed class SimpleContainer : IContainer
	{
		private Dictionary<Type, Type> Types { get; set; }
		private Dictionary<Type, object> Instances { get; set; }

		public SimpleContainer()
		{
			Types = new Dictionary<Type, Type>();
			Instances = new Dictionary<Type, object>();
		}

		public void Register<TService, TClass>()
			where TClass : TService
		{
			if (IsAlreadyRegistered<TService>())
			{
				throw new DuplicateRegistrationException(string.Format("Service of Type '{0}' is already registered.", typeof(TService).Name));
			}

			Types.Add(typeof(TService), typeof(TClass));
		}

		public void RegisterInstance<TService>(TService instance)
		{
			if (IsAlreadyRegistered<TService>())
			{
				throw new DuplicateRegistrationException(string.Format("Service of Type '{0}' is already registered.", typeof(TService).Name));
			}

			Instances.Add(typeof(TService), instance);
		}

		public TService Resolve<TService>()
		{
			return (TService)Resolve(typeof(TService));
		}

		private object Resolve(Type type)
		{
			if (!Types.ContainsKey(type))
			{
				if (!Instances.ContainsKey(type))
				{
					throw new NotSupportedException(string.Format("No registration found for service of Type '{0}'.", type.Name));
				}
				else
				{
					return Instances[type];
				}
			}
			else
			{
				var createdType = Types[type];

				var constructors = createdType.GetConstructors();
				ConstructorInfo mostSpecificConstructor = null;
				foreach (var constructor in constructors)
				{
					if (mostSpecificConstructor == null || mostSpecificConstructor.GetParameters().Length < constructor.GetParameters().Length)
					{
						mostSpecificConstructor = constructor;
					}
				}

				var constructorParameters = new List<object>();
				foreach (var param in mostSpecificConstructor.GetParameters())
				{
					constructorParameters.Add(Resolve(param.ParameterType));
				}

				return Activator.CreateInstance(createdType, constructorParameters.ToArray());
			}
		}

		private bool IsAlreadyRegistered<T>()
		{
			return Instances.ContainsKey(typeof(T)) || Types.ContainsKey(typeof(T));
		}
	}
}
