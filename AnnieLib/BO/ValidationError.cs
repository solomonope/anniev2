using System;

namespace  BitworkSystem.Annie
{
	public enum ErrorCode
	{
		NotSet = -1
	};
	public class ValidationError
	{

		public ErrorCode  ErrorCode {
			get;
			set;
		}

		public string ErrorMessage {
			get;
			set;
		}
		
	}
}

