using API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace API.Core {

    /// <summary>
    /// Sends an error report to support.
    /// </summary>
    public class ApiErrorReport {

        /// <summary>
        /// IcukApiController.
        /// </summary>
        private IcukApiController api;

        /// <summary>
        /// Error message.
        /// </summary>
        private string errorMsg = "";

        /// <summary>
        /// Stack trace.
        /// </summary>
        private string stackTrace = "None";

        /// <summary>
        /// Additional information.
        /// </summary>
        private string additional = "";

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="apiController">IcukApiController.</param>
		/// <param name="errorMsg">Error message.</param>
		public ApiErrorReport(IcukApiController apiController, string errorMsg) {
			this.api = apiController;
			this.errorMsg = errorMsg;
			return;
		}

		/// <summary>
		/// Overloaded constructor.
		/// </summary>
		/// <param name="apiController">IcukApiController</param>
		/// <param name="errorMsg">Error message.</param>
		/// <param name="stackTrace">Exception stackTrace.</param>
		public ApiErrorReport(IcukApiController apiController, string errorMsg, string stackTrace) {
			this.api = apiController;
			this.errorMsg = errorMsg;
			this.stackTrace = stackTrace;
			return;
		}

		/// <summary>
		/// Overloaded constructor.
		/// </summary>
		/// <param name="apiController">IcukApiController</param>
		/// <param name="errorMsg">Error message.</param>
		/// <param name="stackTrace">Exception stackTrace.</param>
		/// <param name="additional">Additional notes to add to the report.</param>
		public ApiErrorReport(IcukApiController apiController, string errorMsg, string stackTrace, string additional) {
			this.api = apiController;
			this.errorMsg = errorMsg;
			this.stackTrace = stackTrace;
			this.additional = "\n\n" + additional;
			return;
		}
    }
}