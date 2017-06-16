//
//    Copyright 2017 KeyleXiao.
//    Contact to Me : Keyle_xiao@hotmail.com 
//
//   	Licensed under the Apache License, Version 2.0 (the "License");
//   	you may not use this file except in compliance with the License.
//   	You may obtain a copy of the License at
//
//   		http://www.apache.org/licenses/LICENSE-2.0
//
//   		Unless required by applicable law or agreed to in writing, software
//   		distributed under the License is distributed on an "AS IS" BASIS,
//   		WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   		See the License for the specific language governing permissions and
//   		limitations under the License.
//

using System;

namespace SmartDataViewer
{
	public class BaseConfigFiedEditorAttribute : Attribute
	{
		public static T GetCurrentAttribute<T>(object obj, bool inherited = true)
		{
			object[] o = obj.GetType().GetCustomAttributes(typeof(T), inherited);
			if (o == null || o.Length < 1)
			{
				return default(T);
			}
			return ((T)o[0]);
		}
	}

	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public sealed class ConfigEditorFieldAttribute : BaseConfigFiedEditorAttribute
	{
		public DefaultControlPropertity Setting { get; set; }

		public ConfigEditorFieldAttribute(int order = 0, bool can_editor = true, string display = "",
										  int width = 100, string outLinkEditor = "",
										  string outLinkSubClass = "", bool visibility = true,
										  string outLinkDisplay = ""
										 )
		{
			Setting = new DefaultControlPropertity();

			Setting.Order = order;
			Setting.Display = display;
			Setting.CanEditor = can_editor;
			Setting.Width = width;
			Setting.OutLinkEditor = outLinkEditor;
			Setting.OutLinkClass = outLinkSubClass;
			Setting.Visibility = visibility;
			Setting.OutLinkDisplay = outLinkDisplay;

		}
	}

	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	public sealed class ConfigEditorAttribute : BaseConfigFiedEditorAttribute
	{
		public DefaultEditorPropertity Setting { get; set; }


		public ConfigEditorAttribute()
		{
			Setting = new DefaultEditorPropertity();
			Setting.EditorTitle = string.Empty;
			Setting.OutputPath = string.Empty;
			Setting.LoadPath = string.Empty;
			Setting.DisableSave = false;
			Setting.DisableCreate = false;
			Setting.DisableSearch = false;
		}

		public ConfigEditorAttribute(string editor_title = "",
									 string load_path = "",
									 string output_path = "",
									 bool disableSearch = false,
									 bool disableSave = false,
									 bool disableCreate = false)
		{
			Setting = new DefaultEditorPropertity();
			Setting.EditorTitle = editor_title;
			Setting.OutputPath = output_path;
			Setting.LoadPath = load_path;
			Setting.DisableSave = disableSave;
			Setting.DisableCreate = disableCreate;
			Setting.DisableSearch = disableSearch;
		}
	}
}