using FizzBuzzApiCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FizzBuzzUnitTests
{
	[TestClass]
	public class UnitTestsFizzBuzzService
	{
		// work with one instance of the service class
		// great for individual unit tests or running all of them at once, single instance
		private readonly FizzBuzzService _fizzBuzzService;

		public UnitTestsFizzBuzzService()
		{
			_fizzBuzzService = new FizzBuzzService();
		}

		[TestMethod]
		public void FizzBuzzService_SuccessWithValue1()
		{
			var n = 1;
			var result = _fizzBuzzService.GetFizzBuzzResult(n);

			Assert.AreEqual(result.Success, true);
			Assert.AreEqual(result.Data.Count, 1);
			Assert.AreEqual(result.Data.First(), "1");
		}

		[TestMethod]
		public void FizzBuzzService_SuccessWithValue25()
		{
			var n = 25;
			var result = _fizzBuzzService.GetFizzBuzzResult(n);

			Assert.AreEqual(result.Success, true);
			Assert.AreEqual(result.Data.Count, 25);
			Assert.AreEqual(result.Data.Last(), "Buzz");
		}

		[TestMethod]
		public void FizzBuzzService_SuccessWithValue100()
		{
			var n = 100;
			var result = _fizzBuzzService.GetFizzBuzzResult(n);

			Assert.AreEqual(result.Success, true);
			Assert.AreEqual(result.Data.Count, 100);
			Assert.AreEqual(result.Data.Last(), "Buzz");
		}

		[TestMethod]
		public void FizzBuzzService_FailureWithValue0()
		{
			var n = 0;
			var result = _fizzBuzzService.GetFizzBuzzResult(n);

			Assert.AreEqual(result.Data.Count, 0);
			Assert.AreEqual(result.Success, false);
		}
	}
}