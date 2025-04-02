using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Common.ResponseModel
{
    public class AddResponse
    {
        /// <summary>
        /// The unique identifier of the entity that was added.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// An optional message for the Add response
        /// </summary>
        public string Message { get; set; }
    }
}
