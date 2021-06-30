using FizzBuzzApiCore.Models;
using System.Collections.Generic;

namespace FizzBuzzApiCore.Interfaces
{
	public interface IFizzBuzzService
	{
		public Result<List<string>> GetFizzBuzzResult(int n);
	}
}