using System;

namespace AssemblyCSharp
{
	public class Lang
	{
		public Lang ()
		{
		}

		public void checkNotNull(Object arg) {
			if(null == arg)
				throw new FormatException();
		}

		public void checkNotEmpty(string arg) {
			if(null == arg)
				throw new FormatException();
			if("" == arg)
				throw new FormatException();
			if(" " == arg)
				throw new FormatException();
		}
			
	}
}

