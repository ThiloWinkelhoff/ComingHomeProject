using System.Net;

namespace RemoteControl.Rest.Mediation;

public class CommandResponse<T>
{
    /// <summary>
    ///     Gets the time at which the command was completed.
    /// </summary>
    public readonly DateTime Completion = DateTime.UtcNow;

    /// <summary>
    ///     Gets or sets the HTTP status code indicating the result of the command
    ///     execution.
    /// </summary>
    public HttpStatusCode StatusCode { get; private set; }

    /// <summary>
    ///     Gets or sets an optional message providing additional information about the
    ///     command execution.
    /// </summary>
    public string? Message { get; private set; }

    /// <summary>
    ///     Gets or sets the result of the command execution.
    /// </summary>
    public T? Result { get; private set; }

    /// <summary>
    ///     Gets or sets an optional exception that may have occurred during command
    ///     execution.
    /// </summary>
    public Exception? Exception { get; private set; }

    /// <summary>
    ///     Creates a successful response with the <see cref="HttpStatusCode.OK" />
    ///     status.
    /// </summary>
    /// <param name="result">The result to return.</param>
    /// <returns>A <see cref="CommandResponse{T}" /> indicating success.</returns>
    public static CommandResponse<T> OkResponse(T result)
    {
        return new CommandResponse<T>
            { StatusCode = HttpStatusCode.OK, Result = result };
    }

    /// <summary>
    ///     Creates a successful response with the <see cref="HttpStatusCode.OK" />
    ///     status
    ///     and includes an additional message.
    /// </summary>
    /// <param name="result">The result to return.</param>
    /// <param name="message">An optional message providing additional information.</param>
    /// <returns>A <see cref="CommandResponse{T}" /> indicating success.</returns>
    public static CommandResponse<T> OkResponse(T result, string message)
    {
        return new CommandResponse<T>
            { StatusCode = HttpStatusCode.OK, Result = result, Message = message };
    }

    /// <summary>
    ///     Creates a response indicating that a resource was created, with the
    ///     <see cref="HttpStatusCode.Created" /> status.
    /// </summary>
    /// <param name="result">The result to return.</param>
    /// <returns>A <see cref="CommandResponse{T}" /> indicating resource creation.</returns>
    public static CommandResponse<T> CreatedResponse(T result)
    {
        return new CommandResponse<T>
            { StatusCode = HttpStatusCode.Created, Result = result };
    }

    /// <summary>
    ///     Creates a response indicating that a resource was created,
    ///     with the <see cref="HttpStatusCode.Created" /> status and an additional
    ///     message.
    /// </summary>
    /// <param name="result">The result to return.</param>
    /// <param name="message">An optional message providing additional information.</param>
    /// <returns>A <see cref="CommandResponse{T}" /> indicating resource creation.</returns>
    public static CommandResponse<T> CreatedResponse(T result, string message)
    {
        return new CommandResponse<T>
            { StatusCode = HttpStatusCode.Created, Result = result };
    }

    /// <summary>
    ///     Creates a response indicating a server error occurred,
    ///     with the <see cref="HttpStatusCode.InternalServerError" /> status.
    /// </summary>
    /// <param name="ex">The exception that occurred during command execution.</param>
    /// <returns>A <see cref="CommandResponse{T}" /> indicating a server error.</returns>
    public static CommandResponse<T> ServerErrorResponse(Exception ex)
    {
        return new CommandResponse<T>
            { StatusCode = HttpStatusCode.InternalServerError, Exception = ex };
    }

    /// <summary>
    ///     Creates a response indicating a server error occurred,
    ///     with the <see cref="HttpStatusCode.InternalServerError" /> status and an
    ///     additional message.
    /// </summary>
    /// <param name="ex">The exception that occurred during command execution.</param>
    /// <param name="message">An optional message providing additional information.</param>
    /// <returns>A <see cref="CommandResponse{T}" /> indicating a server error.</returns>
    public static CommandResponse<T> ServerErrorResponse(Exception ex, string message)
    {
        return new CommandResponse<T>
            { StatusCode = HttpStatusCode.InternalServerError, Exception = ex, Message = message };
    }

    /// <summary>
    ///     Creates a response indicating a bad request, with the
    ///     <see cref="HttpStatusCode.BadRequest" /> status.
    /// </summary>
    /// <param name="message">
    ///     An optional message providing details about the bad
    ///     request.
    /// </param>
    /// <returns>A <see cref="CommandResponse{T}" /> indicating a bad request.</returns>
    public static CommandResponse<T> BadRequestResponse(string message)
    {
        return new CommandResponse<T>
            { StatusCode = HttpStatusCode.BadRequest, Message = message };
    }

    /// <summary>
    ///     Creates a response indicating a bad request occurred,
    ///     with the <see cref="HttpStatusCode.BadRequest" /> status, an exception, and
    ///     a message.
    /// </summary>
    /// <param name="ex">The exception that occurred.</param>
    /// <param name="message">
    ///     An optional message providing details about the bad
    ///     request.
    /// </param>
    /// <returns>A <see cref="CommandResponse{T}" /> indicating a bad request.</returns>
    public static CommandResponse<T> BadRequestResponse(Exception ex, string message)
    {
        return new CommandResponse<T>
            { StatusCode = HttpStatusCode.BadRequest, Exception = ex, Message = message };
    }

    /// <summary>
    ///     Creates a response indicating that the requested resource was not found,
    ///     with the <see cref="HttpStatusCode.NotFound" /> status.
    /// </summary>
    /// <param name="exception">The exception associated with the not found response.</param>
    /// <param name="message">An optional message providing additional details.</param>
    /// <returns>
    ///     A <see cref="CommandResponse{T}" /> indicating that the resource was
    ///     not found.
    /// </returns>
    public static CommandResponse<T> NotFoundResponse(Exception exception, string message)
    {
        return new CommandResponse<T>
        {
            StatusCode = HttpStatusCode.NotFound,
            Exception = exception,
            Message = message
        };
    }

    /// <summary>
    ///     Creates a response indicating that the requested resource was not found,
    ///     with the <see cref="HttpStatusCode.NotFound" /> status and an additional
    ///     message.
    /// </summary>
    /// <param name="message">
    ///     An optional message providing details about the not found
    ///     resource.
    /// </param>
    /// <returns>
    ///     A <see cref="CommandResponse{T}" /> indicating that the resource was
    ///     not found.
    /// </returns>
    public static CommandResponse<T> NotFoundResponse(string message)
    {
        return new CommandResponse<T>
        {
            StatusCode = HttpStatusCode.NotFound,
            Message = message
        };
    }
}