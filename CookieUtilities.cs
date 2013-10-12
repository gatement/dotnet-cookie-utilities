using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jQueryMobileMVC.Code
{
	public class CookieUtilities
	{
		#region Plain cookie

		public static void SetCookie(HttpCookie cookie)
		{
			HttpContext.Current.Response.Cookies.Set(cookie);
		}

		public static void SetCookie(String key, String valueString)
		{
			HttpServerUtility serverUtility = HttpContext.Current.Server;

			key = serverUtility.UrlEncode(key);
			valueString = serverUtility.UrlEncode(valueString);

			HttpCookie cookie = new HttpCookie(key, valueString);

			SetCookie(cookie);
		}

		public static void SetCookie(String key, String valueString, DateTime expires)
		{
			HttpServerUtility serverUtility = HttpContext.Current.Server;

			key = serverUtility.UrlEncode(key);
			valueString = serverUtility.UrlEncode(valueString);

			HttpCookie cookie = new HttpCookie(key, valueString);
			cookie.Expires = expires;

			SetCookie(cookie);
		}

		public static HttpCookie GetCookie(String key)
		{
			key = HttpContext.Current.Server.UrlEncode(key);

			return (HttpContext.Current.Request.Cookies.Get(key));
		}

		public static String GetCookieValue(String key)
		{
			String valueString = GetCookie(key).Value;

			valueString = HttpContext.Current.Server.UrlDecode(valueString);

			return (valueString);
		}

		public static void RemoveCookie(String key)
		{
			key = HttpContext.Current.Server.UrlEncode(key);
			HttpCookie cookie = new HttpCookie(key, "anything");
			cookie.Expires = DateTime.Now.AddYears(-10);
			HttpContext.Current.Response.Cookies.Set(cookie);
		}

		#endregion

		#region DES encrypted cookie

		public static void SetDESEncryptedCookie(String key, String valueString)
		{
			key = Cryptography.EncryptDES(key);

			valueString = Cryptography.EncryptDES(valueString);

			SetCookie(key, valueString);
		}

		public static void SetDESEncryptedCookie(String key, String valueString, DateTime expires)
		{
			key = Cryptography.EncryptDES(key);

			valueString = Cryptography.EncryptDES(valueString);

			SetCookie(key, valueString, expires);
		}

		public static String GetDESEncryptedCookieValue(String key)
		{
			key = Cryptography.EncryptDES(key);
			String valueString = GetCookieValue(key);
			valueString = Cryptography.DecryptDES(valueString);
			return (valueString);
		}

		public static void RemoveDESEncryptedCookie(String key)
		{
			key = Cryptography.EncryptDES(key);

			RemoveCookie(key);
		}

		#endregion

		#region SetTripleDESEncryptedCookie

		public static void SetTripleDESEncryptedCookie(String key, String valueString)
		{
			key = Cryptography.EncryptTripleDES(key);

			valueString = Cryptography.EncryptTripleDES(valueString);

			SetCookie(key, valueString);
		}

		public static void SetTripleDESEncryptedCookie(String key, String valueString, DateTime expires)
		{
			key = Cryptography.EncryptTripleDES(key);

			valueString = Cryptography.EncryptTripleDES(valueString);

			SetCookie(key, valueString, expires);
		}

		public static String GetTripleDESEncryptedCookieValue(String key)
		{
			key = Cryptography.EncryptTripleDES(key);
			String valueString = GetCookieValue(key);
			valueString = Cryptography.DecryptTripleDES(valueString);
			return (valueString);
		}

		public static void RemoveTripleDESEncryptedCookie(String key)
		{
			key = Cryptography.EncryptTripleDES(key);

			RemoveCookie(key);
		}

		#endregion
	}
}