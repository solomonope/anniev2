using System;

namespace  BitworkSystem.Annie
{
	public enum ErrorCode
	{
		NotSet = -1,
		NullObject
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

