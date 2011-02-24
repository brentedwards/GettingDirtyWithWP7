﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingDirty.Core.Models;

namespace GettingDirty.Core.ViewModels
{
	public interface IDetailsViewModel
	{
		TaskItem TaskItem { get; }

		string ApplicationTitle { get; }

		void Load(Guid taskId);
	}
}
