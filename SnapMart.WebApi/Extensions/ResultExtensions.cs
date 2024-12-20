﻿//using SnapMart.Domain.Shared;
//using System.ComponentModel;

//namespace SnapMart.WebApi.Extensions
//{
//    public static class ResultExtensions
//    {
//        public static IResult ToProblemDetails(this Result result)
//        {
//            if(result.IsSuccess)
//            {
//                throw new InvalidOperationException();
//            }

//            return Results.Problem(
//                statusCode: GetStatusCode(result.Error.Type),
//                title: GetTitle(result.Error.Type),
//                type: "",
//                extensions: new Dictionary<string, object?> {
//                    { "errors", new[] { result } }
//                });

//            static int GetStatusCode(ErrorType errorType) =>
//            errorType switch
//            {

//                ErrorType.Validation => StatusCodes.Status400BadRequest,
//                ErrorType.NotFound => StatusCodes.Status404NotFound,
//                ErrorType.Conflict => StatusCodes.Status409Conflict,
//                _ => StatusCodes.Status500InternalServerError
//            };

//            static string GetTitle(ErrorType errorType) =>
//            errorType switch
//            {

//                ErrorType.Validation => "Bad Request",
//                ErrorType.NotFound => "Not Found",
//                ErrorType.Conflict => "Conflict",
//                _ => "Server Failure"
//            };
//        }


//    }
//}
