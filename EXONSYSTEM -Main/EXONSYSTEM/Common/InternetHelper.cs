using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EXONSYSTEM.Common
{
	public class InternetHelper
	{
		private static InternetHelper instance;
		public static InternetHelper Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new InternetHelper();
				}
				return instance;
			}
		}
		private InternetHelper() { }
       
		[DllImport("wininet.dll")]
		private extern static bool InternetGetConnectedState(out int description, int reservedValue);
		public bool IsConnectedToInternet()
		{
            int desc;
           InternetGetConnectedState(out desc, 0);
           return desc>0;
        }
	}
}
