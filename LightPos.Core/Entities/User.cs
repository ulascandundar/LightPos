using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Core.Entities;
public class User : BaseEntity
{
	public string UserName { get; set; }
	public string PhoneNumber { get; set; }
	public string PasswordHashed { get; set; }
}
