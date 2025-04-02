using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Common.ResponseModel
{
    public static class ResultExtensions
    {
        public static Response<TResult> AsResponse<TResult>(this TResult item)
        {
            return new Response<TResult> { Data = item };
        }

        public static Task<Response<TResult>> AsResponseAsync<TResult>(this TResult item)
        {
            return Task.FromResult(AsResponse(item));
        }
    }
}
