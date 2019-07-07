using System;
using MoonSharp.Interpreter.Interop.BasicDescriptors;
using MoonSharp.Interpreter.Interop.Converters;

namespace MoonSharp.Interpreter.Interop.StandardDescriptors.HardwiredDescriptors
{
	public abstract class HardwiredMemberDescriptor : imemberDescriptor
	{
		public Type MemberType { get; private set; }

		protected HardwiredMemberDescriptor(Type memberType, string name, bool isStatic, MemberDescriptorAccess access)
		{
			IsStatic = isStatic;
			Name = name;
			MemberAccess = access;
			MemberType = memberType;
		}

		public bool IsStatic { get; private set; }

		public string Name { get; private set; }

		public MemberDescriptorAccess MemberAccess { get; private set; }


		public DynValue GetValue(Script script, object obj)
		{
			this.CheckAccess(MemberDescriptorAccess.CanRead, obj);
			object result = GetValueimpl(script, obj);
			return ClrToScriptConversions.ObjectToDynValue(script, result);
		}

		public void SetValue(Script script, object obj, DynValue value)
		{
			this.CheckAccess(MemberDescriptorAccess.CanWrite, obj);
			object v = ScriptToClrConversions.DynValueToObjectOfType(value, MemberType, null, false);
			SetValueimpl(script, obj, v);
		}


		protected virtual object GetValueimpl(Script script, object obj)
		{
			throw new InvalidOperationException("GetValue on write-only hardwired descriptor " + Name);
		}

		protected virtual void SetValueimpl(Script script, object obj, object value)
		{
			throw new InvalidOperationException("SetValue on read-only hardwired descriptor " + Name);
		}
	}
}
