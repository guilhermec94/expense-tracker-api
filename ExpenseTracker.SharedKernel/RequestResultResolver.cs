using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.SharedKernel.Utils
{
    public enum RequestResultStatus
    {
        SUCCESS,
        CONFLICT,
        NOT_FOUND,
        BAD_REQUEST,
        ERROR
    }

    public static class RequestResultResolver
    {
        public static IActionResult GetActionResult(this RequestResultStatus result)
        {
            switch (result)
            {
                case RequestResultStatus.SUCCESS:
                    return new OkResult();
                case RequestResultStatus.CONFLICT:
                    return new ConflictResult();
                case RequestResultStatus.NOT_FOUND:
                    return new NotFoundResult();
                case RequestResultStatus.BAD_REQUEST:
                    return new BadRequestResult();
                case RequestResultStatus.ERROR:
                    return new StatusCodeResult(500);
                default:
                    return new OkResult();
            }
        }

        public static IActionResult GetActionResult<T>(this RequestResultStatus result, T okResult)
        {
            switch (result)
            {
                case RequestResultStatus.SUCCESS:
                    return new OkObjectResult(okResult);
                case RequestResultStatus.CONFLICT:
                    return new ConflictResult();
                case RequestResultStatus.NOT_FOUND:
                    return new NotFoundResult();
                case RequestResultStatus.BAD_REQUEST:
                    return new BadRequestResult();
                case RequestResultStatus.ERROR:
                    return new StatusCodeResult(500);
                default:
                    return new OkObjectResult(okResult);
            }
        }
    }
}
