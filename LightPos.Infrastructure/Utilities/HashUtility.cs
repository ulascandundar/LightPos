using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Infrastructure.Utilities;
public static class HashUtility
{
	public static string CalculateSHA256Hash(string input)
	{
		using (var sha256 = SHA256.Create())
		{
			byte[] inputBytes = Encoding.UTF8.GetBytes(input);
			byte[] hashBytes = sha256.ComputeHash(inputBytes);

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hashBytes.Length; i++)
			{
				sb.Append(hashBytes[i].ToString("X2"));
			}

			return sb.ToString();
		}
	}
}
