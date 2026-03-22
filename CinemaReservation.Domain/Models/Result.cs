namespace CinemaReservation.Domain.Models;

public class Result
{
    public int StatusCode { get; set; }
    public object? Content { get; set; }

    public Result(int statusCode, object content)
    {
        StatusCode = statusCode;
        Content = content;
    }

    public Result(int statusCode)
    {
        StatusCode = statusCode;
    }
}
