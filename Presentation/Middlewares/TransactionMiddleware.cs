using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Presentation.Middlewares
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly Context _context;
        private readonly ILogger<TransactionMiddleware> _logger;

        public TransactionMiddleware(Context context, ILogger<TransactionMiddleware> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!IsWriteMethod(context.Request.Method))
            {
                await next(context);
                return;
            }

            await using var transaction = await _context.Database
                .BeginTransactionAsync(IsolationLevel.ReadCommitted, context.RequestAborted);

            try
            {
                await next(context);

                if (context.Response.StatusCode >= 400)
                {
                    await transaction.RollbackAsync(context.RequestAborted);
                    return;
                }

                await transaction.CommitAsync(context.RequestAborted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during the transaction. Rolling back.");
                await transaction.RollbackAsync(context.RequestAborted);
                throw;
            }
        }
        private static bool IsWriteMethod(string method) =>
                HttpMethods.IsPost(method) ||
                HttpMethods.IsPut(method) ||
                HttpMethods.IsPatch(method) ||
                HttpMethods.IsDelete(method);
    }
}