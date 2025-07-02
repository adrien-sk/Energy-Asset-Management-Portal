using System.Diagnostics.CodeAnalysis;

namespace EnergyPortal.Domain.Common;

public class Result
{
	public Result(bool isSuccess, string error)
	{
		if (isSuccess && error != string.Empty ||
			!isSuccess && error == string.Empty)
		{
			throw new ArgumentException("Invalid error", error);
		}

		IsSuccess = isSuccess;
		Error = error;
	}

	public bool IsSuccess { get; }

	public bool IsFailure => !IsSuccess;

	public string Error { get; }

	public static Result Success() => new(true, string.Empty);

	public static Result<TValue> Success<TValue>(TValue value) =>
		new(value, true, string.Empty);

	public static Result Failure(string error) => new(false, error);

	public static Result<TValue> Failure<TValue>(string error) =>
		new(default, false, error);
}

public class Result<TValue> : Result
{
	private readonly TValue? _value;

	public Result(TValue? value, bool isSuccess, string error)
		: base(isSuccess, error)
	{
		_value = value;
	}

	[NotNull]
	public TValue Value => IsSuccess
		? _value!
		: throw new InvalidOperationException("The value of a failure result can't be accessed.");

	public static implicit operator Result<TValue>(TValue? value) =>
		value is not null ? Success(value) : Failure<TValue>(string.Empty);

	public static Result<TValue> ValidationFailure(string error) =>
		new(default, false, error);
}