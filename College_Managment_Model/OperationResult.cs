using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace College_Management_Model
{
    public enum OperationState
    {
        Success,
        Error,
        Warning
    }

    /// <summary>
    /// 	The data contracted operation result class of closed generic.
    /// </summary>
    /// <typeparam name = "TResult">The type of data expected for the returning result.</typeparam>
    [DataContract]
    public class OperationResult<TResult>
    {
        /// <summary>
        /// 	The operation result data.
        /// </summary>
        [DataMember]
        [JsonProperty(PropertyName = "Data")]
        public TResult Data { get; set; }

        /// <summary>
        /// 	An indicator of the operation suceess. False means no errors.
        /// </summary>
        [DataMember]
        [JsonProperty(PropertyName = "State")]
        public OperationState State { get; set; } 
        
        [DataMember]
        [JsonProperty(PropertyName = "SuccessMessage")]
        public string SuccessMessage { get; set; }

        /// <summary>
        /// 	A string representing messages from the operation.
        /// </summary>
        [DataMember]
        [JsonProperty(PropertyName = "ErrorMessage")]
        public string ErrorMessage { get; set; }

        //[DataMember]
        //[JsonProperty(PropertyName = "Messages")]
        //public Dictionary<OperationState,string> Messages { get; set; }

        //[DataMember]
        //[JsonProperty(PropertyName = "StackTraces")]
        //public List<string> StackTraces { get; set; }
        #region Ctors

        /// <summary>
        /// 	Initializes a new instance of the <see cref = "OperationResult{TResult}" /> class.
        /// </summary>
        public OperationResult()
        {
            //Messages = new Dictionary<OperationState, string>();
          //  StackTraces = new List<string>();
        }

        public OperationResult(string error)
            : this()
        {
            State = OperationState.Error;
           // Messages.Add(OperationState.Error,error);
        }

        public OperationResult(Exception e, bool includeStackTrace = false)
            : this()
        {
            State = OperationState.Error;
            if (e != null)
            {
                ErrorMessage = e.Message;
                BuildException(e, includeStackTrace);
            }
        }

        public OperationResult(OperationResult<TResult> operationResult)
            : this()
        {
            Data = operationResult.Data;
            State = operationResult.State;
            SuccessMessage = operationResult.SuccessMessage;
            ErrorMessage = operationResult.ErrorMessage;
           // Messages = operationresult.ErrorMessages;
            //StackTraces = operationResult.StackTraces;
        }

        public OperationResult(TResult result, Exception e)
            : this()
        {
            Data = result;
            State = OperationState.Error;
            ErrorMessage = e.Message;
            BuildException(e, false);
        }

        public OperationResult(Dictionary<OperationState,string> errors)
            : this()
        {
            //Messages = errors;
        }

        #endregion
        #region Private methods
        private void BuildException(Exception e, bool includeStackTrace)
        {
            if (e == null)
                return;

            //AddError(e.Message);
            //if (includeStackTrace)
            //    StackTraces.Add(e.StackTrace);
            if (e.InnerException != null)
                BuildException(e.InnerException, includeStackTrace);
        }
        #endregion
        #region Public Methods
        public void AddException(Exception e, bool includeStackTrace)
        {
            if (e == null)
                return;
            //AddError(e.Message);
            //if (includeStackTrace)
            //    StackTraces.Add(e.StackTrace);
            if (e.InnerException != null)
                BuildException(e.InnerException, includeStackTrace);
        }

        public void AddError(string message)
        {
            //if (Messages.Any(x=>x.Key == OperationState.Error)) return;
            //Messages.Add(OperationState.Error, message);
        }

        public void AddWarning(string message)
        {
            //if (Messages.Any(x => x.Key == OperationState.Warning)) return;
            //Messages.Add(OperationState.Warning, message);
        }
        #endregion
    }
}
