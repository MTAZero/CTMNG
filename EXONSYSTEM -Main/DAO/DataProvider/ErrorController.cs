using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
	public class ErrorController
	{
		public int ErrorCode { get; set; }
		public string Message { get; set; }
		public ErrorController()
		{
			this.ErrorCode = Common.STATUS_ERROR;
			this.Message = string.Empty;
		}
		public ErrorController(int errorCode, string message)
		{
			this.ErrorCode = errorCode;
			this.Message = message;
		}
	}
}
